//----------------------------------------------
//While Loop
//----------------------------------------------
(LOOP_START)
@R0
D=M             // Læser værdien af R0 ind i D register
@END
D;JEQ           // Spring til END, hvis D (R0's værdi) er 0
// Din kode her...
@R0
M=M-1           // Reducer værdien af R0 med 1
@LOOP_START
0;JMP           // Gå tilbage til LOOP_START
(END)
