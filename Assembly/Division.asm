//Division
//D register is used for temporary storage
//A register is used for memory access

    // Setting R0 to 100
    @7
    D=A
    @R0
    M=D

    //Setting R1 to 5
    @4
    D=A
    @R1
    M=D

    //Setting @R2 to 0 (ressetting the result) (Not in loop)
    @R2
    M=0

    //Setting i
    @i
    M=0

    //setting variable remaining to 0
    @R0
    D=M
    @Remaining
    M=D

    // setting result to 0
    @Result
    M=0

    //Loop
    (LOOP)
    //Setting D to value from Remaining to compare
    @Remaining
    D=M 

    //If out = 0, jump to end
    @END
    D;JEQ   

    //Remaining minus R1
    @R1
    D=M
    @Remaining
    M=M-D

    //i++ and setting result to be = i
    @i
    M=M+1
    @i
    D=M
    @Result
    M=D

    //Repeat
    @LOOP
    0;JMP

    //END
    (END)
    @END
    0;JMP

