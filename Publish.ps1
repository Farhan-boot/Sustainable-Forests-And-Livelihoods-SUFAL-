$countNumber = Read-Host "Enter the publish count number"

$publishFolder = "publish\publish_$countNumber"

# Initialize an array to store error messages
$errors = @()

Write-Host "Publishing project: Web.Core"
Write-Host "Please wait while publishing"
cd PTSL.GENERIC.Web.Core && dotnet publish -c Release -o $publishFolder > $null 2>&1

if ($LASTEXITCODE -ne 0) {
    $errors += "Error publishing Web.Core"
}

Write-Host "Publishing project: API"
Write-Host "Please wait while publishing"
cd ..\PTSL.GENERIC.Api && dotnet publish -c Release -o $publishFolder > $null 2>&1

if ($LASTEXITCODE -ne 0) {
    $errors += "Error publishing API"
}

cd ..

# Display any errors that occurred
if ($errors.Count -gt 0) {
    Write-Host "Errors occurred during publishing:"
    foreach ($error in $errors) {
        Write-Host $error
    }
} else {
    Write-Host "Publishing completed successfully."
    start PTSL.GENERIC.Web.Core\$publishFolder
    start PTSL.GENERIC.Api\$publishFolder
}
