Cruorin
=======

Cruorin is a assembly code styled script language.  
Cruorin supports expression evaluation and meta programming.  

### Basic Command ###
**move** [from:value] **to** [to:symbol]  
**drop** [name:symbol]  
**mark** [name:label]  
**jump** [name:label] **on**.[condition:value]  
**back**  
**load** [path:value]  
**call** [name:value] in [in:value optional more] out [out:symbol optional more]  
**emit** [command:value]  

### Expression ###
**Value Expression**  
Value expression is used to get value element.  

**Name Expression**  
Name expression is used to get name that can refer to an element.  
This is a useful tool for meta programming.  

**Name Operator**  
***`[]`*** is the operator to access name.  

    ["function"+a+1]([a],a)
    ;means get function by name "function"+a+1
    ;input value of symbol whose name is value of a and value of a
    ;call the function

