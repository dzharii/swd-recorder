echo off
call coffee --join "ElementSearch.js" --compile "src"
call coffee --compile "spec\ElementSearch_Spec.coffee"