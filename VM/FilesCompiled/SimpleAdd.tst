load SimpleAdd.vm,
output-file SimpleAdd.out,
// compare-to MyProgram.cmp,
output-list RAM[256]%D1.6.1 RAM[300]%D1.6.1 RAM[400]%D1.6.1 
            RAM[3000]%D1.6.1 RAM[3010]%D1.6.1;

// Initial setup for SP, LCL, ARG, THIS, THAT
set RAM[0] 256,  // SP
set RAM[1] 300,  // LCL
set RAM[2] 400,  // ARG
set RAM[3] 3000, // THIS
set RAM[4] 3010, // THAT

repeat 1000 {     // Assuming your VM program has less than 100 instructions
  vmstep;
}

output;
