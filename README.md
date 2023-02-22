# GlobalVariablesMod
Global Variables mod for Quatro

## Examples Cards
### Draw X Stacks
```
match.Draw(globalInts["stack"])
globalInts["stack"] = 0
```


### Increases Stacks by 1
```
if globalInts["stack"] == nil or globalInts["stack"] == '' then
  globalInts["stack"] = 0
end
globalInts["stack"] = globalInts["stack"] + 1
```
