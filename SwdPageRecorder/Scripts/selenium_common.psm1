
<#
.SYNOPSIS
	Start Selenium
.DESCRIPTION
	Start Selenium
	
.EXAMPLE
    $selenium = launch_selenium -browser 'chrome' -hub_host -hub_port
    Will launch the selenium java hub and slave locally
.LINK

	
.NOTES
	VERSION HISTORY
	2015/06/07 Initial Version
#>
function launch_selenium {
  param(
    [string]$browser = '',
    [switch]$grid,
    [int]$version,
    [string]$shared_assemblies_path = 'c:\developer\sergueik\csharp\SharedAssemblies',
    [string[]]$shared_assemblies = @(
      'WebDriver.dll',
      'WebDriver.Support.dll',
      'nunit.framework.dll'
    ),
    [string]$hub_host = '127.0.0.1',
    [string]$hub_port = '4444',
    [bool]$use_remote_driver = $false,
    [switch]$debug
  )

  $use_remote_driver = [bool]$PSBoundParameters['grid'].IsPresent

  # SHARED_ASSEMBLIES_PATH environment overrides parameter, for Team City
  if (($env:SHARED_ASSEMBLIES_PATH -ne $null) -and ($env:SHARED_ASSEMBLIES_PATH -ne '')) {
    $shared_assemblies_path = $env:SHARED_ASSEMBLIES_PATH
  }

  $driver_folder_path = 'c:\java\selenium'
  # SELENIUM_DRIVERS_PATH environment overrides parameter, for Team City
  if (($env:SELENIUM_DRIVERS_PATH -ne $null) -and ($env:SELENIUM_DRIVERS_PATH -ne '')) {
    $driver_folder_path = $env:SELENIUM_DRIVERS_PATH
  }

  pushd $shared_assemblies_path

  $shared_assemblies | ForEach-Object {
    if ($host.Version.Major -gt 2) {
      Unblock-File -Path $_;
    }
    Write-Debug $_
    Add-Type -Path $_
  }
  popd

  $uri = [System.Uri](('http://{0}:{1}/wd/hub' -f $hub_host,$hub_port))
  if ($DebugPreference -eq 'Continue') {
    if ($use_remote_driver) {
      Write-Host 'Using remote driver'
    } else {
      Write-Host 'Using standalone driver'
    }
  }

  $selenium = $null
  if ($browser -ne $null -and $browser -ne '') {
    if ($use_remote_driver) {

      try {
        $connection = (New-Object Net.Sockets.TcpClient)
        $connection.Connect($hub_host,[int]$hub_port)
        Write-Debug 'Grid is already running'

        $connection.Close()
      } catch {
        Write-Debug 'Launching grid'
        Start-Process -FilePath "C:\Windows\System32\cmd.exe" -ArgumentList "start cmd.exe /c c:\java\selenium\hub.cmd"
        Start-Process -FilePath "C:\Windows\System32\cmd.exe" -ArgumentList "start cmd.exe /c c:\java\selenium\node.cmd"
        Start-Sleep -Millisecond 5000
      }

    } else {
      # launching Selenium jar in  standalone is not needed

      # adding driver folder to the path environment
      if (!(Test-Path $driver_folder_path))
      {
        throw "Folder ${driver_folder_path} does not Exist, cannot be added to $env:PATH"
      }

      # See if the new folder is already in the path.
      if ($env:PATH | Select-String -SimpleMatch $driver_folder_path)
      { Write-Debug "Folder ${driver_folder_path} already within `$env:PATH"

      }

      # Set the new PATH environment
      $env:PATH = $env:PATH + ';' + $driver_folder_path
    }


    Write-Debug "Launching ${browser}"

    if ($browser -match 'firefox') {
      if ($use_remote_driver) {

        $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::Firefox()
        $selenium = New-Object OpenQA.Selenium.Remote.RemoteWebDriver ($uri,$capability)

      } else {

        #  $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::Firefox()

        [object]$profile_manager = New-Object OpenQA.Selenium.Firefox.FirefoxProfileManager

        [OpenQA.Selenium.Firefox.FirefoxProfile]$selected_profile_object = $profile_manager.GetProfile($profile)
        [OpenQA.Selenium.Firefox.FirefoxProfile]$selected_profile_object = New-Object OpenQA.Selenium.Firefox.FirefoxProfile ($profile)
        $selected_profile_object.setPreference('general.useragent.override',"Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/34.0")
        $selenium = New-Object OpenQA.Selenium.Firefox.FirefoxDriver ($selected_profile_object)
        [OpenQA.Selenium.Firefox.FirefoxProfile[]]$profiles = $profile_manager.ExistingProfiles

        # [NUnit.Framework.Assert]::IsInstanceOfType($profiles , new-object System.Type( FirefoxProfile[]))
        [NUnit.Framework.StringAssert]::AreEqualIgnoringCase($profiles.GetType().ToString(),'OpenQA.Selenium.Firefox.FirefoxProfile[]')
      }
    }
    elseif ($browser -match 'chrome') {

      if ($use_remote_driver) {
        $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::Chrome()
        $selenium = New-Object OpenQA.Selenium.Remote.RemoteWebDriver ($uri,$capability)
      } else {
        # TODO: path to  chromedriver.exe

        # override

        # Oveview of extensions 
        # https://sites.google.com/a/chromium.org/chromedriver/capabilities

        $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::Chrome()
        # Profile creation
        # https://support.google.com/chrome/answer/142059?hl=en
        # http://www.labnol.org/software/create-family-profiles-in-google-chrome/4394/
        # using Profile 
        # http://superuser.com/questions/377186/how-do-i-start-chrome-using-a-specified-user-profile/377195#377195


        # origin:
        # http://stackoverflow.com/questions/20401264/how-to-access-network-panel-on-google-chrome-developer-toools-with-selenium

        [OpenQA.Selenium.Chrome.ChromeOptions]$options = New-Object OpenQA.Selenium.Chrome.ChromeOptions

        $options.addArguments('start-maximized')
        # no-op option - re-enforcing the default setting
        $options.addArguments(('user-data-dir={0}' -f ("${env:LOCALAPPDATA}\Google\Chrome\User Data" -replace '\\','/')))
        # if you like to specify another profile parent directory:
        # $options.addArguments('user-data-dir=c:/TEMP'); 

        $options.addArguments('--profile-directory=Default')

        [OpenQA.Selenium.Remote.DesiredCapabilities]$capabilities = [OpenQA.Selenium.Remote.DesiredCapabilities]::Chrome()
        $capabilities.setCapability([OpenQA.Selenium.Chrome.ChromeOptions]::Capability,$options)

        $selenium = New-Object OpenQA.Selenium.Chrome.ChromeDriver ($options)
      }



    }
    elseif ($browser -match 'ie') {
      $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::InternetExplorer()
      if ($version -ne $null -and $version -ne 0) {
        $capability.setCapability("version",$version.ToString());
      }

      $selenium = New-Object OpenQA.Selenium.Remote.RemoteWebDriver ($uri,$capability)
    }
    elseif ($browser -match 'safari') {
      $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::Safari()

      $selenium = New-Object OpenQA.Selenium.Remote.RemoteWebDriver ($uri,$capability)
    }
    else {
      throw "unknown browser choice:${browser}"
    }
  } else {
    $phantomjs_useragent = 'Mozilla/5.0 (Windows NT 6.1) AppleWebKit/534.34 (KHTML, like Gecko) PhantomJS/1.9.7 Safari/534.34'
    Write-Host 'Running on phantomjs'
    $headless = $true
    $phantomjs_executable_folder = "C:\tools\phantomjs-2.0.0\bin"
    $selenium = New-Object OpenQA.Selenium.PhantomJS.PhantomJSDriver ($phantomjs_executable_folder)
    $selenium.Capabilities.setCapability('ssl-protocol','any')
    $selenium.Capabilities.setCapability('ignore-ssl-errors',$true)
    $selenium.Capabilities.setCapability('takesScreenshot',$true)
    $selenium.Capabilities.setCapability('userAgent',$phantomjs_useragent)
    $options = New-Object OpenQA.Selenium.PhantomJS.PhantomJSOptions
    $options.AddAdditionalCapability('phantomjs.executable.path',$phantomjs_executable_folder)
  }

  return $selenium
}

<#
.SYNOPSIS
	Stops Selenium
.DESCRIPTION
	Stops Selenium
	
.EXAMPLE
    cleanup ([ref]$selenium)
    Will tell selenium to stop the browser window 
.LINK
	
	
.NOTES

	VERSION HISTORY
	2015/06/07 Initial Version
#>


function cleanup
{
  param(
    [System.Management.Automation.PSReference]$selenium_ref
  )
  try {
    $selenium_ref.Value.Close()
    $selenium_ref.Value.Quit()
  } catch [exception]{
    # Ignore errors if unable to close the browser
    Write-Output (($_.Exception.Message) -split "`n")[0]

  }
}


<#
.SYNOPSIS
	Sets default timeouts with current Selenium session
.DESCRIPTION
	Sets default timeouts with current Selenium session
	
.EXAMPLE
    set_timeouts ([ref]$selenium) [-exlicit <explicit timeout>] [-page_load <page load timeout>] [-script <script timeout>]
    
.LINK
	
	
.NOTES

	VERSION HISTORY
	2015/06/21 Initial Version
#>


function set_timeouts {
  param(
    [System.Management.Automation.PSReference]$selenium_ref,
    [int]$explicit = 10,
    [int]$page_load = 10,
    [int]$script = 10
  )

  [void]($selenium_ref.Value.Manage().timeouts().ImplicitlyWait([System.TimeSpan]::FromSeconds($explicit)))
  [void]($selenium_ref.Value.Manage().timeouts().SetPageLoadTimeout([System.TimeSpan]::FromSeconds($pageload)))
  [void]($selenium_ref.Value.Manage().timeouts().SetScriptTimeout([System.TimeSpan]::FromSeconds($script)))

}


<#
.SYNOPSIS
	Loads calller-provided list of .net assembly dlls or fails with a custom exception
	
.DESCRIPTION
	Loads calller-provided list of .net assembly dlls or fails with a custom exception    
.EXAMPLE
	load_shared_assemblies -shared_assemblies_path 'c:\tools' -shared_assemblies @('WebDriver.dll','WebDriver.Support.dll','nunit.framework.dll')
.LINK 
	
	
.NOTES

	VERSION HISTORY
	2015/06/22 Initial Version
#>

function load_shared_assemblies {

  param(
    [string]$shared_assemblies_path = 'c:\developer\sergueik\csharp\SharedAssemblies',

    [string[]]$shared_assemblies = @(
      'WebDriver.dll',
      'WebDriver.Support.dll',
      'nunit.core.dll',
      'nunit.framework.dll'
    )
  )

  pushd $shared_assemblies_path

  $shared_assemblies | ForEach-Object { Unblock-File -Path $_; Add-Type -Path $_ }
  popd
}


<#
.SYNOPSIS
	Loads calller-provided list of .net assembly dlls with specific versions or fails with a custom exception
.DESCRIPTION
	Loads calller-provided list of .net assembly dlls with specific versions or fails with a custom exception
	
.EXAMPLE
	load_shared_assemblues_demand_versions -shared_assemblies_path 'c:\tools'    
.LINK
	
	
.NOTES

	VERSION HISTORY
	2015/06/22 Initial Version
#>

function load_shared_assemblues_demand_versions {
  param(
    [string]$shared_assemblies_path = 'c:\developer\sergueik\csharp\SharedAssemblies',
    $shared_assemblies = @{
      'WebDriver.dll' = 2.44;
      'WebDriver.Support.dll' = '2.44';
      'nunit.core.dll' = $null;
      'nunit.framework.dll' = $null;
    }
  )

  pushd $shared_assemblies_path
  $shared_assemblies.Keys | ForEach-Object {
    # http://all-things-pure.blogspot.com/2009/09/assembly-version-file-version-product.html
    $assembly = $_
    $assembly_path = [System.IO.Path]::Combine($shared_assemblies_path,$assembly)
    $assembly_version = [Reflection.AssemblyName]::GetAssemblyName($assembly_path).Version
    $assembly_version_string = ('{0}.{1}' -f $assembly_version.Major,$assembly_version.Minor)
    if ($shared_assemblies[$assembly] -ne $null) {

      if (-not ($shared_assemblies[$assembly] -match $assembly_version_string)) {
        Write-Output ('Need {0} {1}, got {2}' -f $assembly,$shared_assemblies[$assembly],$assembly_path)
        Write-Output $assembly_version
        throw ('invalid version :{0}' -f $assembly)
      }
    }

    if ($host.Version.Major -gt 2) {
      Unblock-File -Path $_;
    }
    Write-Debug $_
    Add-Type -Path $_
  }
  popd


}


# TODO: local connections only ?
function netstat_check {
  param(
    [string]$selenium_http_port = 4444
  )

  $local_tcpconnections = Invoke-Expression -Command ("C:\Windows\System32\netsh.exe interface ipv4 show tcpconnections localport={0}" -f $selenium_http_port)

  $established_tcpconnections = $local_tcpconnections | Where-Object { ($_ -match '\bEstablished\b') }
  (($established_tcpconnections -ne '') -and $established_tcpconnections -ne $null)

}


<#
findstr /ic:"`$selenium " *.ps1
#>
