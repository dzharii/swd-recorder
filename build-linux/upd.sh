cd ../SwdPageRecorder/packages
mono --runtime=v4.0 ../.nuget/NuGet.exe install ../SwdPageRecorder.UI/packages.config
mono --runtime=v4.0 ../.nuget/NuGet.exe install ../SwdPageRecorder.WebDriver/packages.config
mono --runtime=v4.0 ../.nuget/NuGet.exe install ../SwdPageRecorder.Sample.Tests/packages.config  

cd ../../build-linux
