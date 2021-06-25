Revese Polish Notation Calculator
=====
This is a calculator, based on *reverse polish notation* (RPN) algorithm.
It supports only next operations:
    * addition (+);
    * substraction (-);
    * multiplication (\*);
    * division (/);
    * exponentiation(^);
    * also it supports round brackets.

It accepts **1** parameter:
    * `-n` - prints the input expression as RPN.

**Pattern:**
```cmd
Masya.ConsoleCalc.exe [-n] <expression>
```

Examples
=====
There is some examples, how to work with this console calculator.

**Input:**
```cmd
Masya.ConsoleCalc.exe -n 2+2*2
```

**Output:**
```cmd
Expression in reverse polish notation: + * 2 2 2
2+2*2 = 6
```

**Input:**
```cmd
Masya.ConsoleCalc.exe 256/2 * 3/2 + 8 - (2 - (8 + 11))
```

**Output:**
```cmd
256/2*3/2+8-(2-(8+11)) = 217
```