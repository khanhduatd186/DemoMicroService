param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../"
### Apps Folders
$blazorAppFolder = Join-Path $slnFolder "apps/blazor/src/DemoMicroService.Blazor"
$authserverFolder = Join-Path $slnFolder "apps/auth-server/src/DemoMicroService.AuthServer"
$publicWebFolder = Join-Path $slnFolder "apps/public-web/src/DemoMicroService.PublicWeb"

### Microservice Folders
$identityServiceFolder = Join-Path $slnFolder "services/identity/src/DemoMicroService.IdentityService.HttpApi.Host"
$administrationServiceFolder = Join-Path $slnFolder "services/administration/src/DemoMicroService.AdministrationService.HttpApi.Host"
$saasServiceFolder = Join-Path $slnFolder "services/saas/src/DemoMicroService.SaasService.HttpApi.Host"
$productServiceFolder = Join-Path $slnFolder "services/product/src/DemoMicroService.ProductService.HttpApi.Host"

### Gateway Folders
$webGatewayFolder = Join-Path $slnFolder "gateways/web/src/DemoMicroService.WebGateway"
$webPublicGatewayFolder = Join-Path $slnFolder "gateways/web-public/src/DemoMicroService.PublicWebGateway"

### DB Migrator Folder
$dbmigratorFolder = Join-Path $slnFolder "shared/DemoMicroService.DbMigrator"

Write-Host "*** BUILDING DB MIGRATOR ***" -ForegroundColor Green
Set-Location $dbmigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/demomicroservice-db-migrator:$version .

Write-Host "===== BUILDING MICROSERVICES =====" -ForegroundColor Yellow 
### IDENTITY-SERVICE
Write-Host "*** BUILDING IDENTITY-SERVICE ***" -ForegroundColor Green
Set-Location $identityServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/demomicroservice-service-identity:$version .

### ADMINISTRATION-SERVICE
Write-Host "*** BUILDING ADMINISTRATION-SERVICE ***" -ForegroundColor Green
Set-Location $administrationServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/demomicroservice-service-administration:$version .

### SAAS-SERVICE
Write-Host "*** BUILDING SAAS-SERVICE ***" -ForegroundColor Green
Set-Location $saasServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/demomicroservice-service-saas:$version .

### PRODUCT-SERVICE
Write-Host "*** BUILDING PRODUCT-SERVICE ***" -ForegroundColor Green
Set-Location $productServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/demomicroservice-service-product:$version .
Write-Host "===== COMPLETED BUILDING MICROSERVICES =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING GATEWAYS =====" -ForegroundColor Yellow 
### WEB-GATEWAY
Write-Host "*** BUILDING WEB-GATEWAY ***" -ForegroundColor Green
Set-Location $webGatewayFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/demomicroservice-gateway-web:$version .

### PUBLICWEB-GATEWAY
Write-Host "*** BUILDING WEB-PUBLIC-GATEWAY ***" -ForegroundColor Green
Set-Location $webPublicGatewayFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/demomicroservice-gateway-web-public:$version .
Write-Host "===== COMPLETED BUILDING GATEWAYS =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### AUTH-SERVER
Write-Host "*** BUILDING AUTH-SERVER ***" -ForegroundColor Green
Set-Location $authserverFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/demomicroservice-app-authserver:$version .

### PUBLIC-WEB
Write-Host "*** BUILDING WEB-PUBLIC ***" -ForegroundColor Green
Set-Location $publicWebFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/demomicroservice-app-public-web:$version .
### Blazor WEB App
if (Test-Path -Path $blazorAppFolder) {
    Write-Host "*** BUILDING BLAZOR WEB APPLICATION ***" -ForegroundColor Green
    Set-Location $blazorAppFolder
    dotnet publish -c Release -p:PublishTrimmed=false
    docker build -f Dockerfile.local -t mycompanyname/demomicroservice-app-blazor:$version .
}
Write-Host "===== COMPLETED BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### ALL COMPLETED
Write-Host "ALL COMPLETED" -ForegroundColor Green
Set-Location $currentFolder