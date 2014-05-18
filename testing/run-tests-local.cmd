@set RUNNER="C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
@cd /D "%~dp0..\Bin"

%RUNNER% "SwdPageRecorder.Tests.dll" /InIsolation /Framework:Framework40 /logger:trx /Settings:Local.RunSettings
