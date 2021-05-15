[uri[]]$links = @(
    "https://download.microsoft.com/download/2/4/3/24375141-E08D-4803-AB0E-10F2E3A07AAA/AccessDatabaseEngine.exe",
    "https://download.microsoft.com/download/2/4/3/24375141-E08D-4803-AB0E-10F2E3A07AAA/AccessDatabaseEngine_X64.exe"
)
[System.IO.DirectoryInfo]$tempFolder = Join-Path $PSScriptRoot "temp"
if ($tempFolder.Exists) {
    Remove-Item -Recurse -Force $tempFolder
}
. { mkdir $tempFolder } | Out-Null

foreach ($link in $links) {
    [System.IO.FileInfo]$fileInfo = Join-Path $PSScriptRoot ($link.Segments | Select-Object -Last 1)

    if (-not $fileInfo.Exists) {
        Write-Host "Initiating download of file $($fileInfo.Name)..." -ForegroundColor Green
        Invoke-WebRequest -Uri $link -OutFile $fileInfo
        Write-Host "✔ Download of file $($fileInfo.Name) is finished" -ForegroundColor Green
    }
    else {
        Write-Host "Skipping download since $($fileInfo.Name) already exists." -ForegroundColor Yellow
    }

    [string]$id = [system.IO.Path]::GetFileNameWithoutExtension($fileInfo.Name)
    [System.IO.DirectoryInfo]$exeTempFolder = Join-Path $tempFolder $id "exe"
    . { mkdir $exeTempFolder } | Out-Null

    [System.IO.FileInfo]$exelogFile = Join-Path $exeTempFolder "$id.log"

    Start-Process -Wait -FilePath "$($fileInfo.FullName)" -ArgumentList "/extract:$($exeTempFolder.FullName)", "/log:$($exelogFile.FullName)", "/quiet", "/passive", "/norestart"
    
    [System.IO.FileInfo]$aceRedistFileInfo = Join-Path $exeTempFolder "AceRedist.msi"
    Write-Host $aceRedistFileInfo
    if (-not $aceRedistFileInfo.Exists) {
        [string]$errorMessage = "❌  Extraction has failed..."
        Write-Host $errorMessage -ForegroundColor Red
        throw $errorMessage
    }

    [System.IO.DirectoryInfo]$msiTempFolder = Join-Path $tempFolder $id "msi"
    . { mkdir $msiTempFolder } | Out-Null
    [System.IO.FileInfo]$msilogFile = Join-Path $msiTempFolder "$id.log"

    Start-Process -Wait msiexec -ArgumentList "/a", "$($aceRedistFileInfo.FullName)", "TARGETDIR=`"$($msiTempFolder.FullName)`"", "/l*v", "$($msilogFile.FullName)"
}
