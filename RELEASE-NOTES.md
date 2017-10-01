# SWD PageRecorder 01 OCT 2017 v3.6.0
(Minor release)

## Changes and updates
- Selenium WebDriver upgraded to version 3.6.0
- Upgraded chromedriver
- Upgraded geckodriver



# SWD PageRecorder 29 MAR 2017 v3.3.0
(Minor release)

## Bugfixes


Attempt to fix the the issue by upgrading project dependencies to the recent versions:
[Failed to start up socket due to 'OpenQA.Selenium.WebDriverException' #50](https://github.com/dzharii/swd-recorder/issues/50) reported by @nitfeu

## Changes and updates

- Selenium WebDriver upgraded to version 3.3.0
- Upgraded chromedriver
- Added geckodriver

The binary distribution was scanned with VirusTotal. [See the results here.](https://www.virustotal.com/en/file/8a27bfc0ebec76710fb03e110f3caab57899d96997d973bd5c8fa7be94e499b5/analysis/1490847462/)




SWD Page Recorder v2.XX.XX

- Added JSON based configuration files. Now you can override the available settings inside `myConfiguration.json`
  In order to override the setting, redefine any configuration key inside `_defaultConfiguration.json`.
  Do not modify the configuration inside `_defaultConfiguration.json`. This file should serve you as a read-only reference
  on available settings. Always use `myConfiguration.json` for your user-defined configuration changes. 

- JSON based browser configuration profiles. Profiles are the configuration system extension, allows you to tweak the 
  browser start up behavior and alter the default browser capabilities. 