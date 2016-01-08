@echo off
@echo [1/8] Building SwdPageRecorder...

@echo [2/8]    Sharpening knives....
@rem Global variables

set SlnPath=..\SwdPageRecorder\SwdPageRecorder.sln
set SwdUiPath=..\Bin

set EnableNuGetPackageRestore=true

set STDOUT_DEFAULT=build.log
@rem =====================

echo Hello! >%STDOUT_DEFAULT%

@echo [3/8]    Vacuuming a room...
@rem Build/output cleanup



@call "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" %SlnPath% /t:clean >>%STDOUT_DEFAULT%
if %errorlevel% neq 0 (
    echo ERROR: MSbuild: Compilation / Build Error
    exit /b %errorlevel%
)
@call "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" %SlnPath% >>%STDOUT_DEFAULT%
if %errorlevel% neq 0 (
    echo ERROR: MSbuild: Compilation / Build Error
    exit /b %errorlevel%
)

IF EXIST "SwdPageRecorder_Latest" rd SwdPageRecorder_Latest /Q /S  >>%STDOUT_DEFAULT%
md SwdPageRecorder_Latest >>%STDOUT_DEFAULT%

@rem =====================

@echo [4/8]    Doing some morning exercises...
@Rem 

@REM empty step

@Rem 
@echo [5/8]    Cheving a gum...
@rem !!! Merge all dll files (except WebDriver.dll)  into executable file
set MERGE_LIBS1=%SwdUiPath%\HtmlAgilityPack.dll %SwdUiPath%\Newtonsoft.Json.dll %SwdUiPath%\SwdPageRecorder.WebDriver.dll %SwdUiPath%\SwdPageRecorder.ConfigurationManagement.dll
set MERGE_LIBS2=%SwdUiPath%\RazorEngine.dll %SwdUiPath%\System.Web.Razor.dll %SwdUiPath%\NLog.dll %SwdUiPath%\FastColoredTextBox.dll
set MERGE_LIBS3=%SwdUiPath%\ClearScript.dll 





call ilmerge\ILMerge.exe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5" /t:winexe /out:SwdPageRecorder_Latest\SwdPageRecorder.exe %SwdUiPath%\SwdPageRecorder.UI.exe  %MERGE_LIBS1% %MERGE_LIBS2% %MERGE_LIBS3% >>%STDOUT_DEFAULT%

if %errorlevel% neq 0 (
    echo ERROR: ILMerge Error
    exit /b %errorlevel%
)

@REM Remove SwdPageRecorder.pdb
del /F /Q SwdPageRecorder_Latest\SwdPageRecorder.pdb

@rem =====================

@echo [6/8]    Shovelling coal into the build...
@REM  Copy license, javascript files, code templates and WebDriver.dll

@echo Copy JavaScript scripts
xcopy %SwdUiPath%\JavaScript  SwdPageRecorder_Latest\JavaScript /e/y/i >>%STDOUT_DEFAULT%

@echo Copy Code Templates
xcopy %SwdUiPath%\CodeTemplates  SwdPageRecorder_Latest\CodeTemplates /e/y/i >>%STDOUT_DEFAULT%

@echo Copy JavaScript Snippets
xcopy %SwdUiPath%\Snippets  SwdPageRecorder_Latest\Snippets /e/y/i >>%STDOUT_DEFAULT%

@echo Copy Nlog configuration file
copy %SwdUiPath%\NLog.config SwdPageRecorder_Latest\*.* /y >>%STDOUT_DEFAULT%

@echo Copy license file
copy ..\license.md SwdPageRecorder_Latest\license.txt /y >>%STDOUT_DEFAULT%

@echo Copy Selenium Start batch file
copy %SwdUiPath%\start_selenium_server.bat SwdPageRecorder_Latest\start_selenium_server.bat /y >>%STDOUT_DEFAULT%

@echo .NET Application Configuration file
copy %SwdUiPath%\SwdPageRecorder.UI.exe.config SwdPageRecorder_Latest\SwdPageRecorder.exe.config /y >>%STDOUT_DEFAULT%

@echo Copy Samples
copy %SwdUiPath%\sample_ParserWebElements.js SwdPageRecorder_Latest\*.* /y >>%STDOUT_DEFAULT%
copy %SwdUiPath%\sample_ParserWebElements.lib.json2.js SwdPageRecorder_Latest\*.* /y >>%STDOUT_DEFAULT%

@echo SWD Recorder configuration files and browser profiles
copy %SwdUiPath%\_defaultConfiguration.json SwdPageRecorder_Latest\*.* /y >>%STDOUT_DEFAULT%
copy %SwdUiPath%\myConfiguration.json SwdPageRecorder_Latest\*.* /y >>%STDOUT_DEFAULT%
xcopy %SwdUiPath%\profiles  SwdPageRecorder_Latest\profiles /e/y/i >>%STDOUT_DEFAULT%

@echo Copy -- DONE

@echo create empty folder for Screenshots
md SwdPageRecorder_Latest\Screenshots

@REM # Copy WebDriver DLL files

copy %SwdUiPath%\WebDriver.dll SwdPageRecorder_Latest\*.* /y >>%STDOUT_DEFAULT%

@REM #~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~

@echo [7/8]    Cutting the edges...
@REM Compressing the build folder

@REM TODO!!!

@echo [8/8] Build completed.

