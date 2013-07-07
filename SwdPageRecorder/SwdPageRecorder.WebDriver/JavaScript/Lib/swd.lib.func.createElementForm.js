function createElementForm() {
    //Create an input type dynamically.   
    var element = document.createElement("div");
    //Assign different attributes to the element. 
    element.id = 'SwdPR_PopUp';
    element.style = 'display: block; position: absolute; left: 100px; top: 50px; border: solid black 1px; padding: 10px; background-color: rgb(200,100,100); text-align: justify; font-size: 12px; width: 135px;';
    element.name = '';  
    document.getElementsByTagName('body')[0].appendChild(element);

    element.innerHTML = '[% insert.quote "swd.lib.func.createElementForm.template" %]';
}