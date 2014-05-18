
var inputs=document.querySelectorAll('input, textarea, button');

for(i=0;i<inputs.length;i++)
{
    inputs[i].disabled=false;
}

return "Elements (input, textarea, button) were enabled";