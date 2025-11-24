# Portfolio Analyzer - Quick Start

## 🚀 Starting the Application

### macOS / Linux:
```bash
./start.sh
```

### Windows:
```cmd
start.bat
```

The script will:
1. ✅ Start the API service (port 7000)
2. ✅ Start the Web application (port 5001)
3. ✅ Automatically open your browser to https://localhost:5001
4. ✅ Show you where the logs are stored

## 🛑 Stopping the Application

### macOS / Linux:
```bash
./stop.sh
```

### Windows:
Close the command prompt windows that were opened by `start.bat`

## 📋 What's Running

- **Web Dashboard**: https://localhost:5001
- **API Backend**: https://localhost:7000
- **API Swagger**: https://localhost:7000/swagger

## 📝 Logs

Logs are stored in the `logs/` directory:
- `logs/api.log` - API service logs
- `logs/web.log` - Web application logs

## 🔧 Manual Start (Alternative)

If the scripts don't work, you can start manually:

**Terminal 1 - API:**
```bash
cd src/PortfolioAnalyzer.Api
dotnet run
```

**Terminal 2 - Web:**
```bash
cd src/PortfolioAnalyzer.Web
dotnet run
```

## ⚠️ Troubleshooting

**Port already in use?**
```bash
# macOS/Linux - Find and kill process on port 7000
lsof -ti:7000 | xargs kill -9
lsof -ti:5001 | xargs kill -9

# Windows - Find and kill process on port 7000
netstat -ano | findstr :7000
taskkill /PID <PID> /F
```

**Certificate errors?**
```bash
dotnet dev-certs https --trust
```

## 🎉 First Time Setup

1. Make sure .NET 8 SDK is installed:
   ```bash
   dotnet --version
   ```

2. Restore packages (first time only):
   ```bash
   dotnet restore
   ```

3. Run the startup script:
   ```bash
   ./start.sh
   ```

That's it! The Portfolio Analyzer will open automatically in your browser.
