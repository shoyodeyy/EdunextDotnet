# PowerShell script to apply migration SQL script
# This script will execute the SQL migration directly

$connectionString = "Server=localhost;Database=Edunext;Trusted_Connection=True;TrustServerCertificate=True"
$sqlScript = Get-Content -Path "AddQuantityToMenuItem.sql" -Raw

try {
    $connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
    $connection.Open()
    
    $command = New-Object System.Data.SqlClient.SqlCommand($sqlScript, $connection)
    $command.CommandTimeout = 30
    
    $result = $command.ExecuteNonQuery()
    
    Write-Host "Migration applied successfully!" -ForegroundColor Green
    $connection.Close()
}
catch {
    Write-Host "Error applying migration: $_" -ForegroundColor Red
    if ($connection.State -eq 'Open') {
        $connection.Close()
    }
}



