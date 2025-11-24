@echo off
REM Portfolio Analyzer Startup Script for Windows
echo Starting Portfolio Analyzer...
echo.

cd src\PortfolioAnalyzer.Api
start "API Service" cmd /k "dotnet run"
timeout /t 3 /nobreak >nul

cd ..\PortfolioAnalyzer.Web
start "Web Application" cmd /k "dotnet run"

echo.
echo Portfolio Analyzer is starting...
echo.
echo Dashboard: https://localhost:5001
echo API:       https://localhost:7000
echo.
echo Close the cmd windows to stop the services.
echo.
timeout /t 3 /nobreak >nul
start https://localhost:5001

pause
