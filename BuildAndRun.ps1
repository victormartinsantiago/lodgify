# ====================================================================================
# This scripts builds and a docker using the Docker file located at the same directory.
# Image name and tag can be configured using the below params.
# After a successful build, the script spins up a new container on the specified hostPort
# ======================================================================================

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$ImageName="vacationrental"
$Tag="local"
$HostPort="5000"
$ContainerPort="80"

Write-Host "Build docker image for VacationRental.Contact.Api"
Write-Host " * Image => $ImageName`:$Tag"
Write-Host " * Host Port => $HostPort"

docker build . -t $ImageName`:$Tag

if (-not $?) { throw "Docker image could not be generated" }

Write-Host "Starting container on port $HostPort"

docker run -d -p $HostPort`:$ContainerPort $ImageName`:$Tag

Write-Host "Container started"
Write-Host "App is running on http://localhost:$HostPort/swagger"