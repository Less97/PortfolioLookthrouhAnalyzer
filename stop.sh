#!/bin/bash

# Portfolio Analyzer Stop Script
# This script stops both the API and Web projects

echo "🛑 Stopping Portfolio Analyzer..."
echo ""

SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# Read PIDs
if [ -f "$SCRIPT_DIR/.api.pid" ]; then
    API_PID=$(cat "$SCRIPT_DIR/.api.pid")
    echo "Stopping API (PID: $API_PID)..."
    kill $API_PID 2>/dev/null || echo "   API already stopped"
    rm "$SCRIPT_DIR/.api.pid"
fi

if [ -f "$SCRIPT_DIR/.web.pid" ]; then
    WEB_PID=$(cat "$SCRIPT_DIR/.web.pid")
    echo "Stopping Web (PID: $WEB_PID)..."
    kill $WEB_PID 2>/dev/null || echo "   Web already stopped"
    rm "$SCRIPT_DIR/.web.pid"
fi

# Also kill any remaining dotnet processes for these projects
echo ""
echo "Cleaning up any remaining processes..."
pkill -f "PortfolioAnalyzer.Api" 2>/dev/null
pkill -f "PortfolioAnalyzer.Web" 2>/dev/null

echo ""
echo "✅ Portfolio Analyzer stopped!"
