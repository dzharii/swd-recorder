@echo off
set PROJECT_ROOT=%cd%\..

set TESTING_FOLDER=%cd%

set NUNIT=%TESTING_FOLDER%\nunit\nunit-console.exe

set TESTS_DLL_FOLDER=%PROJECT_ROOT%\Bin\SwdPageRecorder.Tests

"%NUNIT%" "%TESTS_DLL_FOLDER%\SwdPageRecorder.Tests.dll"
