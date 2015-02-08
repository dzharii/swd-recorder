 module WebElementExplorer {

     class CSS {
         static DEFAULT_BOX = "DEFAULT_BOX";
         static WINDOW_CONTAINER = "WINDOW_CONTAINER";
         static TOP_DRAGGING_AREA = "TOP_DRAGGING_AREA";
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
                 "width": "auto",
                 "height": "auto",
                 "margin": "0",
                 "padding": "0",
                 "border": "0",
                 "outline": "0",
                 "vertical-align": "baseline",
                 "background": "0 0",
                 "text-align": "left !important",
                 "line-height": "normal",
                 "border-radius": "0",
                 "font-variant": "normal !important",
                 "font-weight": "normal",
                 "cursor": "default",
                 "font-family": "Segoe UI, Helvetica, sans-serif !important",
                 "letter-spacing": "normal !important",
                 "clear": "none",
                 "box-sizing": "content-box",
             };

             styles[CSS.WINDOW_CONTAINER] = {
                 "z-index": "2147483647",
                 "box-shadow": "0 3px 11px",
                 "overflow": "hidden",
             };

             styles[CSS.TOP_DRAGGING_AREA] = {
                 "cursor": "move",
                 "background-color": "#D01345",
                 "background": "linear-gradient(to bottom,#A61E2D 0,#D01345 100%)",
                 "width": "auto",
                 "height": "auto",
                 "min-height": "20pt",
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
    <div data-role="container" style="${this.getStyle(CSS.WINDOW_CONTAINER)}">
        <div style="${this.getStyle(CSS.TOP_DRAGGING_AREA)}"> 
                 Header
        </div>
        <div>
        Hello World 4!
        </div>
    </div>
</div>
`.trim()
.replace(/^\s+|\s+$/gm,"");
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
