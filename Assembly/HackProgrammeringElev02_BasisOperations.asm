(Start)
// D=10 indirekte
@10 //sætter A = 10
D=A //sætter D = A


// D++
D=D+1 //kan gøre direkte


// D=RAM[17] D sættes lig med adresse 17 i RAM
@17
D=M


// RAM[17]=D Husk altid adr først
@17
M=D

// RAM[17]=10
@10 //værdien 10
D=A
@17
M=D


// RAM[5] = RAM[3]
@3
D=M
@5
M=D


@Start
0;JMP //jump til start
