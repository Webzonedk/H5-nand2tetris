//Multiplication
//Insert numbers in Ram[0] and Ram[1]
//and the program will multiply them and put the result in Ram[2]


// Setting R0 to 100
    @100
    D=A
    @R0
    M=D

//Setting R1 to 5
    @5
    D=A
    @R1
    M=D
//Setting @R2 to 0 (ressetting the result) (Not in loop)
@R2
M=0

//setting i to 0
@i
M=0

(Loop)
@i          //Variables always starts at place 16 and forward until That is why the counter is represented there
D=M
@R1
D=D-M
@End
D;JEQ //if i > R1 goto End

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
