@echo OFF
echo Stopping old service version...
net stop "AntiWannaCryMutex"
echo Uninstalling old service version...
sc delete "AntiWannaCryMutex"

echo Installing service...
copy AntiWannaCryMutex.exe c:\
sc create "AntiWannaCryMutex" binpath= "c:\AntiWannaCryMutex.exe" start= auto
echo Starting server complete
pause