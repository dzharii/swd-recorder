@echo off
@echo [1/7] Building SwdPageRecorder...

@echo [2/7]    Sharpening knives....
@rem Global variables

set SlnPath=..\SwdPageRecorder\SwdPageRecorder.sln
set BinPath=..\Bin
set SwdUiPath=%BinPath%\SwdPageRecorder.UI

set STDOUT_DEFAULT=nul
@rem =====================

echo Hello! >%STDOUT_DEFAULT%

@echo [3/7]    Vacuuming a room...
@rem Build/output cleanup

@%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild %SlnPath% /t:clean >>%STDOUT_DEFAULT%
@%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild %SlnPath% >>%STDOUT_DEFAULT%

IF EXIST "SwdPageRecorder_Latest" rd SwdPageRecorder_Latest /Q /S  >>%STDOUT_DEFAULT%
md SwdPageRecorder_Latest >>%STDOUT_DEFAULT%

@rem =====================

@echo [4/7]    Cheving a gum...
@rem !!! Merge all dll files (except WebDriver.dll)  into executable file
set MERGE_LIBS1=%SwdUiPath%\HtmlAgilityPack.dll %SwdUiPath%\Newtonsoft.Json.dll %SwdUiPath%\SwdPageRecorder.WebDriver.dll
set MERGE_LIBS2=%SwdUiPath%\RazorEngine.dll %SwdUiPath%\System.Web.Razor.dll %SwdUiPath%\NLog.dll

ilmerge\ILMerge.exe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0" /t:winexe /out:SwdPageRecorder_Latest\SwdPageRecorder.exe %SwdUiPath%\SwdPageRecorder.UI.exe  %MERGE_LIBS1% %MERGE_LIBS2% >>%STDOUT_DEFAULT%

@REM Remove SwdPageRecorder.pdb
del /F /Q SwdPageRecorder_Latest\SwdPageRecorder.pdb

@rem =====================

@echo [5/7]    Shovelling coal into the build...
@REM  Copy license, javascript files, code templates and WebDriver.dll

xcopy %SwdUiPath%\JavaScript  SwdPageRecorder_Latest\JavaScript /e/y/i >>%STDOUT_DEFAULT%
xcopy %SwdUiPath%\CodeTemplates  SwdPageRecorder_Latest\CodeTemplates /e/y/i >>%STDOUT_DEFAULT%
copy %SwdUiPath%\NLog.config SwdPageRecorder_Latest\*.* /y >>%STDOUT_DEFAULT%

copy ..\license.md SwdPageRecorder_Latest\license.txt /y >>%STDOUT_DEFAULT%

@REM # Copy WebDriver DLL files

copy %SwdUiPath%\WebDriver.dll SwdPageRecorder_Latest\*.* /y >>%STDOUT_DEFAULT%

@REM #~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~#~

@echo [6/7]    Cutting the edges...
@REM Compressing the build folder

@REM TODO!!!

@echo [7/7] Build completed.

