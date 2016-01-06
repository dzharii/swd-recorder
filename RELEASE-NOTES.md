SWD Page Recorder v2.XX.XX

- Added JSON based configuration files. Now you can override the available settings inside `myConfiguration.json`
  In order to override the setting, redefine any configuration key inside `_defaultConfiguration.json`.
  Do not modify the configuration inside `_defaultConfiguration.json`. This file should serve you as a read-only reference
  on available settings. Always use `myConfiguration.json` for your user-defined configuration changes. 

- JSON based browser configuration profiles. Profiles are the configuration system extension, allows you to tweak the 
  browser start up behaviour and alter the default browser capabilities. 