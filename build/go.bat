@echo off
@echo Building SwdPageRecorder...

set SlnPath=..\SwdPageRecorder\SwdPageRecorder.sln
set BinPath=..\Bin
set SwdUiPath=%BinPath%\SwdPageRecorder.UI

set STDOUT_DEFAULT=nul
echo Hello! >%STDOUT_DEFAULT%

@%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild %SlnPath% /t:clean >>%STDOUT_DEFAULT%
@%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild %SlnPath% >>%STDOUT_DEFAULT%

rd SwdPageRecorder_Latest /Q /S  >>%STDOUT_DEFAULT%
md SwdPageRecorder_Latest >>%STDOUT_DEFAULT%

set MERGE_LIBS1=%SwdUiPath%\HtmlAgilityPack.dll %SwdUiPath%\Newtonsoft.Json.dll %SwdUiPath%\SwdPageRecorder.WebDriver.dll %SwdUiPath%\WebDriver.dll %SwdUiPath%\WebDriver.Support.dll
set MERGE_LIBS2=%SwdUiPath%\RazorEngine.dll %SwdUiPath%\System.Web.Razor.dll

ilmerge\ILMerge.exe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0" /t:winexe /out:SwdPageRecorder_Latest\SwdPageRecorder.exe %SwdUiPath%\SwdPageRecorder.UI.exe  %MERGE_LIBS1% %MERGE_LIBS2% >>%STDOUT_DEFAULT%

xcopy %SwdUiPath%\JavaScript  SwdPageRecorder_Latest\JavaScript /e/y/i >>%STDOUT_DEFAULT%
xcopy %SwdUiPath%\CodeTemplates  SwdPageRecorder_Latest\CodeTemplates /e/y/i >>%STDOUT_DEFAULT%

copy ..\license.md SwdPageRecorder_Latest\license.txt /y >>%STDOUT_DEFAULT%

@echo Build completed.



