using AccessToSQLite.Core;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessToSQLite.UI
{
    public partial class MainForm : Form
    {
        private readonly AccessExportOptions options;

        public MainForm(AccessExportOptions options) : this()
        {
            this.options = options;
            RefreshForm();
        }

        private MainForm()
        {
            InitializeComponent();

            var assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Text = $@"AccessToSQLite v{fvi.FileMajorPart}.{fvi.FileMinorPart}.{fvi.FileBuildPart}";
        }

        private void RefreshForm()
        {
            txtAccessFileName.Text = options.AccessFileName;
            txtAccessPassword.Text = options.AccessPassword;
            txtSQLiteFileName.Text = options.SqLiteFileName;

            btnExport.Enabled = options.CanExport;

            grpImport.Enabled = !options.Executing;
            grpExport.Enabled = !options.Executing;
        }

        private void BtnAccessSelect_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = @"Access Files (*.mdb)|*.mdb|All files (*.*)|*.*"
            })
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    options.AccessFileName = dialog.FileName;
                    RefreshForm();
                }
            }
        }

        private void BtnSQLiteSelect_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = @"SQLite Files (*.sqlite3)|*.sqlite3|All files (*.*)|*.*",
                InitialDirectory = options.SqLiteInitialDirectory,
                FileName = options.SqLiteDefaultFileName,
            })
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    options.SqLiteFileName = dialog.FileName;
                    RefreshForm();
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            options.Executing = true;
            RefreshForm();

            rtxLogs.Clear();
            rtxLogs.Text += @"Export Started";

            Task.Factory.StartNew(() =>
            {
                var export = new Export(options);
                return export.Execute();
            })
            .ContinueWith(t =>
            {
                switch (t.Result)
                {
                    case ExportResult.Success:
                        rtxLogs.Text += @"\nExport Complete";
                        break;
                    case ExportResult.PasswordInvalid:
                        rtxLogs.Text += @"\nPassword Invalid";
                        break;
                    case ExportResult.ImportError:
                        rtxLogs.Text += @"\nImport Error";
                        break;
                }

                options.Executing = false;
                RefreshForm();

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void TxtAccessPassword_TextChanged(object sender, EventArgs e)
        {
            options.AccessPassword = txtAccessPassword?.Text;
        }
    }
}
