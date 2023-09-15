// Program: Add2.asm
// Computes: RAM[2] = RAM[0] + RAM[1]
// Usage: put values in RAM[0], RAM[1]

//Resetting the computer
@2
MD=0
@3
MD=0

//Math is starting up
@0
D=M   // D = RAM[0]

@1
D=D+M // D = D + RAM[1]

@2
M=D   // RAM[2] = D
@3
M=D   // RAM[3] = D
@End

(End)
0;JMP
