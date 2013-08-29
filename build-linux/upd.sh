#!/bin/bash

unset CDPATH
cd `dirname ${BASH_SOURCE[0]}`/../SwdPageRecorder/packages

mono --runtime=v4.0 ../.nuget/NuGet.exe install ../SwdPageRecorder.UI/packages.config
mono --runtime=v4.0 ../.nuget/NuGet.exe install ../SwdPageRecorder.WebDriver/packages.config
mono --runtime=v4.0 ../.nuget/NuGet.exe install ../SwdPageRecorder.Sample.Tests/packages.config  
