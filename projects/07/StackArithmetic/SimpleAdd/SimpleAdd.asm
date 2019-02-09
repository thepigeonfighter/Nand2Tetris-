//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter


 //Pushing 7 to stack
@7
D=A
@SP       //SP = 7
A=M
M=D
@SP       //SP++
M=M+1


 //Pushing 8 to stack
@8
D=A
@SP       //SP = 8
A=M
M=D
@SP       //SP++
M=M+1

//Adding numbers from stack
//Popping from stack
@SP
M=M-1
A=M
D=M
//Popping from stack
@SP
M=M-1
A=M
M=D+M
@SP
M=M+1


//This concludes the asm file. 
