// Program: Flip.asm
// flips the values of
// RAM[0] and RAM[1]

@10
D=A
@R0
M=D

@20
D=A
@R1
M=D

(Start)

   @R1  // Hvis man skriver R1 direkte, så er det en konstant, og ikke en variabel og skriver derfor direkte til RAM[1]
   D=M
   @temp    // temp is always Ram[16] , but when using multiple temp, it will add afterwards as 17 and so on
   M=D    // temp = R1

   @0
   D=M
   @R1
   M=D    // R1 = R0

   @temp
   D=M
   @R0
   M=D    // R0 = temp

   @R0
   D=M
   @ostekiks      //Temp2 is now written to Ram[17]
   M=D

   @Start 
   0;JMP
