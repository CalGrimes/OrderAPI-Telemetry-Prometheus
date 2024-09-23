# Start the Docker containers
docker-compose up -d

# Wait for a few seconds to ensure the containers are up and running
Start-Sleep -Seconds 10

# Extract the logs from the aspire-dashboard container
$logs = docker logs aspire-dashboard

# Filter the logs to find the Aspire token
$token = $logs | Select-String -Pattern "Login to the dashboard at "

$token = $token -replace '.*Login to the dashboard at ', ''

$token = $token -replace '0.0.0.0', 'localhost'

# Output the token
if ($token) {
    Write-Output "Open Aspire Dashboard at: $($token)"
    Write-Output "Open OrderAPI at http://localhost:5000/swagger/index.html"
    Write-Output "Open Prometheus at http://localhost:9090"
} else {
    Write-Output "Aspire Token not found in the logs."
}