// Initial setups for SCREEN
@16384 // SCREEN address
D=A
@R5   // Store it in R5
M=D
// // Initialize KBD address to R0
// @24576 // KBD memory address
// D=A
// @R0
// M=D

// Loop for continuously checking keyboard input
(Loop)

// Read from the KBD memory address into D
@KBD
D=M

// Store the read value in R2
@R2
M=D

// If D=0, no key was pressed, so jump back to Loop
@Loop
D;JEQ

// Compare D with arrow key values and jump accordingly
@131 // Up
D=A-D
@Up
D;JEQ

@133 // Down
D=A-D
@Down
D;JEQ

@130 // Left
D=A-D
@Left
D;JEQ

@132 // Right
D=A-D
@Right
D;JEQ

@Loop // If none of the above, return to Loop
0;JMP

// Logic for each direction
(Up)
@R5
M=M+1
@Loop
0;JMP

(Down)
@R5
M=M-1
@Loop
0;JMP

(Left)
@R5
M=M-1
@Loop
0;JMP

(Right)
@R5
M=M+1
@Loop
0;JMP
