//----------------------------------------------
//For Loop
//----------------------------------------------
@R0
M=0             // Initialiser R0 til 0
(LOOP_START)
@R0
D=M             // Læser værdien af R0 ind i D register
@10
D=D-A           // Subtraher konstanten 10 fra D
@LOOP_END
D;JEQ           // Hvis R0 er lig med 10, afslut løkken
// Din kode her...
@R0
M=M+1           // Forøg værdien af R0 med 1
@LOOP_START
0;JMP           // Gå tilbage til LOOP_START
(LOOP_END)
