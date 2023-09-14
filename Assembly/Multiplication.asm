//Multiplication

//Setup
@R2
M=0
@i
M=0


//if i > R1 goto End
(Loop)
@i          //Variables always starts at place 16 and forward until That is why the counter is represented there
D=M
@R1
D=D-M
@End
D;JEQ

//R2=R2+R0
@R0
D=M
@R2
M=M+D

//i++
@i
M=M+1

//Repeat
@Loop
0;JMP

//End
(End)
@End
0;JMP
