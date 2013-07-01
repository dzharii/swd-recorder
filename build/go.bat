set SlnPath=..\SwdPageRecorder\SwdPageRecorder.sln
set BinPath=..\Bin
set SwdUiPath=%BinPath%\SwdPageRecorder.UI

@%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild %SlnPath% /t:clean
@%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild %SlnPath%

rd SwdPageRecorder_Latest /Q /S
md SwdPageRecorder_Latest

ilmerge\ILMerge.exe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0" /t:winexe /out:SwdPageRecorder_Latest\SwdPageRecorder.exe %SwdUiPath%\SwdPageRecorder.UI.exe  %SwdUiPath%\HtmlAgilityPack.dll %SwdUiPath%\Newtonsoft.Json.dll %SwdUiPath%\SwdPageRecorder.WebDriver.dll %SwdUiPath%\WebDriver.dll %SwdUiPath%\WebDriver.Support.dll

xcopy %SwdUiPath%\JavaScript  SwdPageRecorder_Latest\JavaScript /e/y/i
copy ..\license.md SwdPageRecorder_Latest\license.txt /y



