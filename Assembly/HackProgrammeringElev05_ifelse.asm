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