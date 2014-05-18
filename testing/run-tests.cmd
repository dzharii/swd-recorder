set RUNNER="C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
set PSEXEC="%~dp0psexec.exe" \\localhost -i -w "%~dp0..\Bin"

@cd /D "%~dp0..\Bin"

@REM %PSEXEC% %RUNNER% "SwdPageRecorder.Tests.dll" /InIsolation /Framework:Framework40 /logger:trx
%RUNNER% "SwdPageRecorder.Tests.dll" /InIsolation /Framework:Framework40 /logger:trx
