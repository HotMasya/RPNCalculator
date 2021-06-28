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
rpncalc [-n] <expression>
```

Examples
=====
There are some examples, how to work with this console calculator.

**Input:**
```cmd
rpncalc -n 2+2*2
```

**Output:**
```cmd
Expression in reverse polish notation: + * 2 2 2
2+2*2 = 6
```

**Input:**
```cmd
rpncalc 256/2 * 3/2 + 8 - (2 - (8 + 11))
```

**Output:**
```cmd
256/2*3/2+8-(2-(8+11)) = 217
```