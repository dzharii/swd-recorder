@echo OFF
pushd %~dp0
set SELENIUM_HOME=%CD:\=/%
set HTTP_PORT=4444
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
set HUB_CONFIG=hub.json
set LOGFILE=hub.log

type NUL > %LOGFILE%


REM 
REM Error occurred during initialization of VM
REM The size of the object heap + VM data exceeds the maximum representable size
REM Error occurred during initialization of VM
REM Could not reserve enough space for object heap
REM Could not create the Java virtual machine.
REM Then
REM This setting needs adjustment.
REM 

REM set LAUNCHER_OPTS=-XX:PermSize=512M -XX:MaxPermSize=1028M -Xmn128M -Xms512M -Xmx1024M
set LAUNCHER_OPTS=-XX:MaxPermSize=1028M -Xmn128M
REM java %LAUNCHER_OPTS% -jar selenium-server-standalone-%SELENIUM_VERSION%.jar -port %HTTP_PORT% -role hub

java %LAUNCHER_OPTS% ^
-classpath %SELENIUM_HOME%/log4j-1.2.17.jar;%SELENIUM_HOME%/selenium-server-standalone-%SELENIUM_VERSION%.jar; ^
-Dlog4j.configuration=hub.log4j.properties ^
org.openqa.grid.selenium.GridLauncher ^
-port %HTTP_PORT% ^
-role hub ^
-ensureCleanSession true ^
-trustAllSSLCertificates true ^
-maxSession 20 ^
-newSessionWaitTimeout 600000 ^
-hubConfig %HUB_CONFIG% ^

REM Keep the Blank line above intact
goto :EOF

REM To run the hub servlet, add the jar to the list and the main class via -servlets e.g.
REM Note to match the class name of the servlet

java %LAUNCHER_OPTS% ^
-classpath %SELENIUM_HOME%/log4j-1.2.17.jar;^
%SELENIUM_HOME%/ConsoleServlet-1.0-SNAPSHOT.jar;^
%SELENIUM_HOME%/json-20080701.jar;^
%SELENIUM_HOME%/selenium-server-standalone-%SELENIUM_VERSION%.jar; ^
-Dlog4j.configuration=hub.log4j.properties ^
org.openqa.grid.selenium.GridLauncher ^
-port %HTTP_PORT% ^
-role hub ^
-ensureCleanSession true ^
-trustAllSSLCertificates true ^
-maxSession 20 ^
-newSessionWaitTimeout 600000 ^
-servlets com.mycompany.app.MyConsoleServlet ^

REM Keep the Blank line above intact


REM http://www.deepshiftlabs.com/sel_blog/?p=2155&&lang=en-us
REM http://grokbase.com/t/gg/webdriver/1282vm4ej0/how-to-set-the-command-line-switches-for-iedriverserver-exe-when-running-it-along-with-grid-node 
REM http://stackoverflow.com/questions/1140358/how-to-initialize-log4j-properly
REM http://logging.apache.org/log4j/1.2/manual.html
REM https://groups.google.com/forum/#!topic/selenium-users/MaGHl-qRI38
