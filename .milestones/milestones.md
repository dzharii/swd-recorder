# SWD Page Recorder v 0.1 Release 

## JavaScript Snippets
This feature will allow to inject custom JavaScript scripts into the web-page.   
[ ] Implement User Interface  
[ ] Implement Injections   
[ ] Error handling  
[ ] Save/Load script functionality  

[ ] Implement Event scripts  
	[ ] Web Element Explorer: OnElementSelected  
[ ] Implement Web Element Explorer as JavaScript snippet
    * Implement plug-in support for WEE
	* Override locators search (Angular, Knockout, Ember)
	* Override locator type generation 
[ ] Allow JavaScript snippets work directly with declared 
    * PageObject elements.
    * Allow creating simple scripts (PlayGround?)
      * Add syntax autocompleation



## Documentation  
[ ] Create a list of features [like this](http://padre.perlide.org/trac/wiki/Features)  
  
## Testing   
[ ] TBD  

  
# SWD Page Recorder v 0.2 Release  

## API  
[ ] Libray  
[ ] Commandline  
	[ ] Class generation from template  

[ ] Save Application Settings  

## XPath/CSS selectors internal processing  
	[ ] FizzlerEx: http://fizzlerex.codeplex.com/   


## Web Element Explorer enhancements  
[ ] Display value of Id, Name attributes (if available for the element)  
[ ] Add support for CSS/HTML ID locators during. Update the locators at real time.  
> @yuriw: "I am expecting Html ID, Css Selector and XPath to be updating in real-time and if any of them are empty that would mean that those attributes/locators for a particular WebElement do not exist"  
  
[ ] When user adds an element, show success message or close the popup. Proposed by @upgundecha  

## Main App – Locators  
[ ]  Add a feature - "suggest a better locator syntax”; by @yuriw  

JavaScript support  
    [ ] FindBy JavaScript (http://stackoverflow.com/a/11320472/1126595)  
    [ ] Allow JavaScript snippets  

## Main App – Web Element PlayGround  
[ ]  Add a possibility to build and test WebElement actions from SWD Page Recorder, like Click, SendKeys and other actions. Proposed by @upgundecha and @yuriw.   
See [Enhancements to In-Broswer Element Explorer](https://github.com/dzhariy/swd-recorder/issues/9#issuecomment-23884770)  


# On hold  
[ ] @yuriw: “finding differences between different versions.  Consider this scenario: a test developer used SWD to build Object Pages, everything worked fine and then in a new version nothing works anymore, because some locators/HTML changed.”  
@dzhariy: “Probably it would be reasonable to add such verification, but I cannot implement that now in convenient way”  
  
[ ] @yuriw “compare a previous Object Pages vs current and highlight quickly differences, would you like it?”  
@dzhariy: “Probably, it is hard to find the actual list of elements. It is hard to define the actual logical PageObject borders, but this idea is worth for  further consideration”  
 
[ ] C# PageObject loading/source code integration  
[ ] Implement Save Capabilities settings  