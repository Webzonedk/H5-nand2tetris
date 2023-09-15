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

 
//----------------------------------------------
//if
//----------------------------------------------
@R0
D=M            // Læser værdien af R0 ind i D register
@SKIP_IF
D;JEQ          // Spring til SKIP_IF, hvis D (R0's værdi) er 0

 

// Din kode her for når R0 ikke er 0...

 

(SKIP_IF)

 

//----------------------------------------------
//if else
//----------------------------------------------
@R0
D=M            // Læser værdien af R0 ind i D register
@ELSE_PART
D;JEQ          // Spring til ELSE_PART, hvis D (R0's værdi) er 0

 

// Din kode her for når R0 ikke er 0...

 

@END
0;JMP          // Gå til END efter at have udført if-koden

 

(ELSE_PART)
// Din kode her for når R0 er 0...

 

(END)