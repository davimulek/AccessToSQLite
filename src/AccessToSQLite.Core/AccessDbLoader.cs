/* 
 * Microsoft Access Database DataSet Loader for .NET
 * Version 20150511
 *
 * Created by SiZiOUS
 * sizious (at) gmail (dot) com - @sizious - www.sizious.com - fb.com/sizious
 *
 * Licensed under the WTFPL licence
 * See http://www.wtfpl.net/txt/copying/
 */

using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace AccessToSQLite.Core
{
    /// <summary>
    /// Useful utilities for Microsoft Access Database files.
    /// </summary>
    public static class AccessDbLoader
    {
        /// <summary>
        /// Loads a Microsoft Access Database file into a DataSet object.
        /// The file can be the in the newer ACCDB format or MDB legacy format.
        /// </summary>
        /// <param name="fileName">The file name to load.</param>
        /// <returns>A DataSet object with the Tables object populated with the contents of the specified Microsoft Access Database.</returns>
        public static DataSet LoadFromFile(string fileName, string password = null)
        {
            var result = new DataSet();

            // For convenience, the DataSet is identified by the name of the loaded file (without extension).
            result.DataSetName = Path.GetFileNameWithoutExtension(fileName)?.Replace(" ", "_");

            // Compute the ConnectionString (using the OLEDB v12.0 driver compatible with ACCDB and MDB files)
            fileName = Path.GetFullPath(fileName);

            var connString = $"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\"{fileName}\"; Jet OLEDB:Database Password={password};";

            // Opening the Access connection
            using (var conn = new OleDbConnection(connString))
            {
                conn.Open();

                // Getting all user tables present in the Access file (Msys* tables are system thus useless for us)
                var schema = conn.GetSchema("Tables");
                var tableNameList = schema.AsEnumerable().Select(dr => dr.Field<string>("TABLE_NAME")).Where(dr => !dr.StartsWith("MSys")).ToList();

                // Getting the data for every user tables
                foreach (var tableName in tableNameList)
                {
                    using (var oleDbCommand = new OleDbCommand($"SELECT * FROM [{tableName}]", conn))
                    using (var oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand))
                    {
                        // Saving all tables in our result DataSet.
                        var dataTable = new DataTable($"[{tableName}]");
                        oleDbDataAdapter.Fill(dataTable);
                        result.Tables.Add(dataTable);
                    }
                }
            }

            // Return the filled DataSet
            return result;
        }
    }
}