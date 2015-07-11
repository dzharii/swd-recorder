<#
.SYNOPSIS
	Determines script directory
.DESCRIPTION
	Determines script directory
	
.EXAMPLE
	$script_directory = Get-ScriptDirectory

.LINK
	# http://stackoverflow.com/questions/8343767/how-to-get-the-current-directory-of-the-cmdlet-being-executed	
	
.NOTES
	TODO: http://joseoncode.com/2011/11/24/sharing-powershell-modules-easily/	
	VERSION HISTORY
	2015/06/07 Initial Version
#>

function Get-ScriptDirectory
{
  $Invocation = (Get-Variable MyInvocation -Scope 1).Value
  if ($Invocation.PSScriptRoot) {
    $Invocation.PSScriptRoot
  }
  elseif ($Invocation.MyCommand.Path) {
    Split-Path $Invocation.MyCommand.Path
  } else {
    $Invocation.InvocationName.Substring(0,$Invocation.InvocationName.LastIndexOf(''))
  }
}


<#
.SYNOPSIS
	Extracts match
.DESCRIPTION
	Extracts match from a text, e.g. from some $element.Text or $element.GetAttribute('innerHTML')
	
.EXAMPLE
	$first_item = $null
	$capturing_match_expression = '(?<first_item>\d+)$'
	extract_match -Source $text -capturing_match_expression $capturing_match_expression -label 'first_item' -result_ref ([ref]$first_item)

.LINK
	
.NOTES
	VERSION HISTORY
	2015/06/07 Initial Version
#>

function extract_match {
  param(
    [string]$source,
    [string]$capturing_match_expression,
    [string]$label,
    [System.Management.Automation.PSReference]$result_ref = ([ref]$null)
  )
  Write-Debug ('Extracting from {0}' -f $source)
  $local:results = {}
  $local:results = $source | where { $_ -match $capturing_match_expression } |
  ForEach-Object { New-Object PSObject -prop @{ Media = $matches[$label]; } }
  Write-Debug 'extract_match:'
  Write-Debug $local:results
  $result_ref.Value = $local:results.Media
}

<#
.SYNOPSIS
	Highlights page element
.DESCRIPTION
	Highlights page element by executing Javascript through Selenium
	
.EXAMPLE
        highlight -selenium_ref ([ref]$selenium) -element_ref ([ref]$element) -delay 1500
.LINK
	
.NOTES
	VERSION HISTORY
	2015/06/07 Initial Version
#>

function highlight {
  param(
    [System.Management.Automation.PSReference]$selenium_ref,
    [System.Management.Automation.PSReference]$element_ref,
    [int]$delay = 300
  )
  # https://selenium.googlecode.com/git/docs/api/java/org/openqa/selenium/JavascriptExecutor.html
  [OpenQA.Selenium.IJavaScriptExecutor]$selenium_ref.Value.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",$element_ref.Value,'color: yellow; border: 4px solid yellow;')
  Start-Sleep -Millisecond $delay
  [OpenQA.Selenium.IJavaScriptExecutor]$selenium_ref.Value.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",$element_ref.Value,'')
}


<#
.SYNOPSIS
	Finds page element
.DESCRIPTION
	Finds page element by executing appropriate FindElement, By, Wait through Selenium
	
.EXAMPLE
	$link_alt_text = 'Shore Excursions'
	$element = $null
	$css_selector = ('img[alt="{0}"]' -f $link_alt_text)
	find_page_element_by_css_selector ([ref]$selenium) ([ref]$element) $css_selector

.LINK
	
.NOTES
	VERSION HISTORY
	2015/06/21 Initial Version
#>


function find_page_element_by_xpath {
  param(
    [System.Management.Automation.PSReference]$selenium_driver_ref,
    [System.Management.Automation.PSReference]$element_ref,
    [string]$xpath,
    [int]$wait_seconds = 10
  )
  if ($xpath -eq '' -or $xpath -eq $null) {
    return
  }
  $local:element = $null
  [OpenQA.Selenium.Remote.RemoteWebDriver]$local:selenum_driver = $selenium_driver_ref.Value
  [OpenQA.Selenium.Support.UI.WebDriverWait]$wait = New-Object OpenQA.Selenium.Support.UI.WebDriverWait ($local:selenum_driver,[System.TimeSpan]::FromSeconds($wait_seconds))
  $wait.PollingInterval = 50

  try {
    [void]$wait.Until([OpenQA.Selenium.Support.UI.ExpectedConditions]::ElementExists([OpenQA.Selenium.By]::XPath($xpath)))
  } catch [exception]{
    Write-Debug ("Exception : {0} ...`ncss_selector={1}" -f (($_.Exception.Message) -split "`n")[0],$css_selector)
  }

  $local:element = $local:selenum_driver.FindElement([OpenQA.Selenium.By]::XPath($xpath))
  $element_ref.Value = $local:element
}



<#
.SYNOPSIS
	Finds page element
.DESCRIPTION
	Finds page element by executing appropriate FindElement, By, Wait through Selenium
	
.EXAMPLE
	$link_alt_text = 'Shore Excursions'
	$element = $null
	$css_selector = ('img[alt="{0}"]' -f $link_alt_text)
	find_page_element_by_css_selector ([ref]$selenium) ([ref]$element) $css_selector

.LINK
	
.NOTES
	VERSION HISTORY
	2015/06/21 Initial Version
#>

function find_page_element_by_css_selector {
  param(
    [System.Management.Automation.PSReference]$selenium_driver_ref,
    [System.Management.Automation.PSReference]$element_ref,
    [string]$css_selector,
    [int]$wait_seconds = 10
  )
  if ($css_selector -eq '' -or $css_selector -eq $null) {
    return
  }
  $local:status = $false 
  $local:element = $null
  [OpenQA.Selenium.Remote.RemoteWebDriver]$local:selenum_driver = $selenium_driver_ref.Value
  [OpenQA.Selenium.Support.UI.WebDriverWait]$wait = New-Object OpenQA.Selenium.Support.UI.WebDriverWait ($local:selenum_driver,[System.TimeSpan]::FromSeconds($wait_seconds))
  $wait.PollingInterval = 50

  try {
    [void]$wait.Until([OpenQA.Selenium.Support.UI.ExpectedConditions]::ElementExists([OpenQA.Selenium.By]::CssSelector($css_selector)))
    $local:status = $true 
  } catch [exception]{
    Write-Debug ("Exception : {0} ...`ncss_selector={1}" -f (($_.Exception.Message) -split "`n")[0],$css_selector)
  }
  if ($local:status) {
    $local:element = $local:selenum_driver.FindElement([OpenQA.Selenium.By]::CssSelector($css_selector))
    $element_ref.Value = $local:element
  }
}
