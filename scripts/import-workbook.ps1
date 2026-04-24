<#
.SYNOPSIS
  Logs into the POS API and uploads your Excel workbook or CSV (same headers; commits import).

  Requires curl.exe (included in Windows 10+).

.EXAMPLE
  .\import-workbook.ps1 -FilePath "$env:USERPROFILE\OneDrive\Documents\products.xlsx" -Email "you@company.com" -Password "YourSecure!Pass"

.EXAMPLE
  CSV (same columns as Excel):
  .\import-workbook.ps1 -FilePath ".\samples\products.csv" -Email "you@company.com" -Password "YourSecure!Pass"

.EXAMPLE
  Preview only (no database write):
  .\import-workbook.ps1 -FilePath ".\samples\products.xlsx" -Email "you@company.com" -Password "YourSecure!Pass" -PreviewOnly
#>
param(
  [Parameter(Mandatory = $true)]
  [Alias("ExcelPath")]
  [string] $FilePath,
  [Parameter(Mandatory = $true)]
  [string] $Email,
  [Parameter(Mandatory = $true)]
  [string] $Password,
  [string] $BaseUrl = "http://localhost:8080",
  [string] $SheetName = "",
  [switch] $PreviewOnly
)

$ErrorActionPreference = "Stop"
$BaseUrl = $BaseUrl.TrimEnd("/")

if (-not (Test-Path -LiteralPath $FilePath)) {
  throw "File not found: $FilePath"
}

$ext = [System.IO.Path]::GetExtension($FilePath).ToLowerInvariant()
if ($ext -notin @(".xlsx", ".xlsm", ".csv")) {
  throw "Use .xlsx, .xlsm, or .csv (got $ext)."
}

$curl = Get-Command curl.exe -ErrorAction SilentlyContinue
if (-not $curl) {
  throw "curl.exe not found. Install Windows curl or use the Import page in the web UI."
}

$loginBody = @{ email = $Email; password = $Password } | ConvertTo-Json
$login = Invoke-RestMethod -Uri "$BaseUrl/api/auth/login" -Method Post -ContentType "application/json" -Body $loginBody
$token = $login.token
if (-not $token) { throw "Login failed (no token returned)." }

$commit = if ($PreviewOnly) { "false" } else { "true" }
$resolved = (Resolve-Path -LiteralPath $FilePath).Path

# curl -F sends multipart; @ path must be curl's native path format on Windows
$args = @(
  "-s", "-S",
  "-H", "Authorization: Bearer $token",
  "-F", "file=@$resolved",
  "-F", "sheetName=$SheetName",
  "-F", "commit=$commit",
  "$BaseUrl/api/imports/workbook"
)

$out = & curl.exe @args
if ($LASTEXITCODE -ne 0) {
  throw "curl failed with exit $LASTEXITCODE"
}

Write-Output $out
try {
  $obj = $out | ConvertFrom-Json
  if ($obj.imported) { Write-Host "Imported rows: $($obj.imported)" }
  if ($obj.preview) { Write-Host "Preview row count: $($obj.preview.Count)" }
  if ($obj.warnings) { $obj.warnings | ForEach-Object { Write-Warning $_ } }
} catch {
  # response may not be JSON
}
