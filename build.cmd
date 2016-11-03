@ECHO OFF
SETLOCAL

FOR /f "delims=" %%i in ('git rev-list --count HEAD') DO SET COMMITCOUNT=00%%i
SET VERSION_SUFFIX=%COMMITCOUNT:~-3%

dotnet restore
IF ERRORLEVEL 1 EXIT /B %ERRORLEVEL%

dotnet build **\project.json
IF ERRORLEVEL 1 EXIT /B %ERRORLEVEL%

dotnet test src\Microsoft.Build.CommandLine.Arguments.UnitTests\project.json
IF ERRORLEVEL 1 EXIT /B %ERRORLEVEL%

dotnet pack src\Microsoft.Build.CommandLine.Arguments\project.json --version-suffix=%VERSION_SUFFIX% -c Release
IF ERRORLEVEL 1 EXIT /B %ERRORLEVEL%