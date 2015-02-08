 module WebElementExplorer {

     class CSS {
         static DEFAULT_BOX = "defaultBox";
     }


     export class MainViewTemplate {
         TEMPLATE_CONTAINER_HTML_ID = "swdPageRecorder_WebElementExplorer";

         convertObjectToCssStyle(jsObject: Object): string {
             if (!jsObject) return "";

             var propNames = Object.getOwnPropertyNames(jsObject);
             if (propNames.length < 1) return "";

             var result = "";
             for (var i = 0; i < propNames.length; i++) {
                 var prefixSemicolon = (i === 0) ? "" : "; ";

                 var cssKey = propNames[i].trim();
                 var cssValue = jsObject[cssKey].trim();

                 result += `${prefixSemicolon}${cssKey}: ${cssValue}`;
             }
             return result;
         }

         getStyle(key:string) {

             var styles = {};

             styles[CSS.DEFAULT_BOX] = {
                 
             };

             if (!styles[key]) {
                 logError(new Error(`MainViewTemplate: style ${key} is not defined`))
             }

             return this.convertObjectToCssStyle(styles[key]);
         }


         render() {
//================= HTML ===================================
//==========================================================
             var htmlTemplate =`
<div style="${this.getStyle(CSS.DEFAULT_BOX)}">
    Hello World 4!
</div>
`.trim();
//==========================================================
             this.showForm(htmlTemplate);
         }

         showForm(html:string) {
             if (!document || !document.body) return;

             var containerDiv = document.getElementById(this.TEMPLATE_CONTAINER_HTML_ID);

             if (!containerDiv) {
                 containerDiv = document.createElement("div");
                 containerDiv.id = this.TEMPLATE_CONTAINER_HTML_ID;
             }

             containerDiv.innerHTML = html;
             document.body.appendChild(containerDiv);
         }
     }
 }
