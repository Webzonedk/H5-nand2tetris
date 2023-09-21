// unknown command: // This file is part of www.nand2tetris.org
// unknown command: // and the book "The Elements of Computing Systems"
// unknown command: // by Nisan and Schocken, MIT Press.
// unknown command: // File name: projects/07/StackArithmetic/StackTest/StackTest.vm
// unknown command: 
// unknown command: // Executes a sequence of arithmetic and logical operations
// unknown command: // on the stack. 
@17          // Read value 17
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@17          // Read value 17
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: eq
@17          // Read value 17
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@16          // Read value 16
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: eq
@16          // Read value 16
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@17          // Read value 17
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: eq
@892          // Read value 892
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@891          // Read value 891
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: lt
@891          // Read value 891
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@892          // Read value 892
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: lt
@891          // Read value 891
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@891          // Read value 891
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: lt
@32767          // Read value 32767
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@32766          // Read value 32766
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: gt
@32766          // Read value 32766
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@32767          // Read value 32767
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: gt
@32766          // Read value 32766
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@32766          // Read value 32766
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: gt
@57          // Read value 57
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@31          // Read value 31
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
@53          // Read value 53
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
@112          // Read value 112
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: sub
// unknown command: neg
// unknown command: and
@82          // Read value 82
D=A         // Set D-register to value
@SP         // Go to stack pointer
A=M         // Point to top of stack
M=D         // Push value to stack
@SP         // Go back to stack pointer
M=M+1       // Increase stack pointer
// unknown command: or
// unknown command: not
(END)       // Setting label for the loop
@END        // Set pointer to address
0;JMP       // Goto @End
