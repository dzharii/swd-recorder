@set IE=-Dwebdriver.ie.driver="%cd%\IEDriverServer.exe"
@set CHROME=-Dwebdriver.chrome.driver="%cd%\chromedriver.exe"
start java %CHROME% %IE% -jar selenium-server-standalone-2.35.0.jar