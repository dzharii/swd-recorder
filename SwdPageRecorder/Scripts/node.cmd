@echo OFF
setlocal
pushd %~dp0
set SELENIUM_HOME=%CD:\=/%

set NODE_HOST=%1
set NODE_HTTP_PORT=%2

if "%NODE_HTTP_PORT%" equ "" set NODE_HTTP_PORT=5555
REM NOTE - DNS may not be available
if "%NODE_HOST%" equ "" set NODE_HOST=%COMPUTERNAME%
if "%HUB_HOST%" equ "" set HUB_HOST=127.0.0.1
set HUB_HTTP_PORT=4444

set HTTPS_PORT=-1


set SELENIUM_VERSION=2.44.0
set GROOVY_VERSION=2.3.8
set JAVA_VERSION=1.6.0_45
set MAVEN_VERSION=3.2.1
set JAVA_HOME=c:\java\jdk%JAVA_VERSION%
set GROOVY_HOME=c:\java\groovy-%GROOVY_VERSION%
set M2_HOME=c:\java\apache-maven-%MAVEN_VERSION%
set M2=%M2_HOME%\bin
set MAVEN_OPTS=-Xms256m -Xmx512m

PATH=%JAVA_HOME%\bin;%PATH%;%GROOVY_HOME%\bin;%M2%

PATH=%PATH%;c:\Program Files\Mozilla Firefox

IF "%PROCESSOR_ARCHITECTURE%"=="x86" GOTO :PATH_x86
PATH=%PATH%;%ProgramFiles(x86)%\Google\Chrome\Application
PATH=%PATH%;%ProgramFiles(x86)%\Mozilla Firefox
PATH=%PATH%;%ProgramFiles(x86)%\Internet Explorer
GOTO :END_PATH
:PATH_x86
REM Browsers are installed in WOW6432
PATH=%PATH%;%ProgramFiles%\Google\Chrome\Application
PATH=%PATH%;%ProgramFiles%\Mozilla Firefox
PATH=%PATH%;%ProgramFiles%\Internet Explorer
GOTO :END_PATH
:END_PATH
PATH=%PATH%;%LOCALAPPDATA%\Mozilla Firefox

where.exe firefox.exe
where.exe chrome.exe
where.exe chromedriver.exe
where.exe iexplore.exe

CHOICE /T 1 /C ync /CS /D y



set MAX_MEMORY=-Xmx256m
set STACK_SIZE=-Xss8m

rem Need to keep 1.7 and 1.6 both installed
set HUB_URL=http://127.0.0.1:4444/grid/register

REM cannot use paths
set NODE_CONFIG=NODE.json

set LAUNCHER_OPTS=-XX:MaxPermSize=1028M -Xmn128M
set LAUNCHER_OPTS=%MAX_MEMORY% %STACK_SIZE%

REM java %LAUNCHER_OPTS% ^
REM -jar selenium-server-standalone-%SELENIUM_VERSION%.jar ^

set LOGFILE=node.log
type NUL  > %LOGFILE%

java %LAUNCHER_OPTS% ^
-classpath %SELENIUM_HOME%/log4j-1.2.17.jar;%SELENIUM_HOME%/selenium-server-standalone-%SELENIUM_VERSION%.jar; ^-Dlog4j.configuration=node.log4j.properties ^
org.openqa.grid.selenium.GridLauncher ^
-role node ^
-host %NODE_HOST% ^
-port %NODE_HTTP_PORT% ^
-hub http://%HUB_HOST%:%HUB_HTTP_PORT%/hub/register ^
-Dwebdriver.ie.driver=%SELENIUM_HOME%/IEDriverServer.exe ^
-Dwebdriver.chrome.driver=%SELENIUM_HOME%/chromedriver.exe ^
-nodeConfig %NODE_CONFIG%  ^
-browserTimeout 120000 -timeout 120000 ^
-ensureCleanSession true ^
-trustAllSSLCertificates 

REM Keep the Blank line above intact
goto :EOF
REM http://www.deepshiftlabs.com/sel_blog/?p=2155&&lang=en-us
REM http://grokbase.com/t/gg/webdriver/1282vm4ej0/how-to-set-the-command-line-switches-for-iedriverserver-exe-when-running-it-along-with-grid-node 
REM http://seleniumonlinetrainingexpert.wordpress.com/2012/12/11/how-do-i-start-the-internet-explorer-webdriver-for-selenium/