// unknown command: // This file is part of www.nand2tetris.org
// unknown command: // and the book "The Elements of Computing Systems"
// unknown command: // by Nisan and Schocken, MIT Press.
// unknown command: // File name: projects/07/StackArithmetic/SimpleAdd/SimpleAdd.vm
// unknown command: 
// unknown command: // Pushes and adds two constants.
@7   // Read value 7
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@8   // Read value 8
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@SP         // Go to stack pointer
AM=M-1      // Decrease stack pointer and go to top of stack
D=M         // D = popped value
@SP         // Go to stack pointer
AM=M-1      // Decrease stack pointer and go to top of stack
D=D+M       // D = D + popped value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push D onto stack
@SP         // Go to stack pointer
M=M+1       // Increment stack pointer
