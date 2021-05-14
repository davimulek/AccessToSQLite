[uri[]]$links = @(
    "https://download.microsoft.com/download/2/4/3/24375141-E08D-4803-AB0E-10F2E3A07AAA/AccessDatabaseEngine.exe",
    "https://download.microsoft.com/download/2/4/3/24375141-E08D-4803-AB0E-10F2E3A07AAA/AccessDatabaseEngine_X64.exe"
)

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
    [System.IO.DirectoryInfo]$tempFolder = Join-Path $PSScriptRoot $id
    if ($tempFolder.Exists) {
        . { Remove-Item -Force -Recurse $tempFolder } | Out-Null
    }

    . { mkdir $tempFolder } | Out-Null

    [System.IO.FileInfo]$logFile = Join-Path $tempFolder "$id.log"

    Start-Process -Wait -FilePath "$($fileInfo.FullName)" -ArgumentList "/extract:$($tempFolder.FullName)", "/log:$($logFile.FullName)", "/quiet", "/passive", "/norestart"
    
    [System.IO.FileInfo]$aceRedistFileInfo = Join-Path $tempFolder "AceRedist.msi"
    Write-Host $aceRedistFileInfo
    if (-not $aceRedistFileInfo.Exists) {
        [string]$errorMessage = "❌  Extraction has failed..."
        Write-Host $errorMessage -ForegroundColor Red
        throw $errorMessage
    }

    Start-Process -Wait msiexec -ArgumentList "/a", "$($aceRedistFileInfo.FullName)", "/qb", "TARGETDIR=`"$($tempFolder.FullName)`"", "/l*v", "$($logFile.FullName)"
}
