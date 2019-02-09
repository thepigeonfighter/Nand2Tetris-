//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter


 //Pushing 111 to stack
@111
D=A
@SP       //SP = 111
A=M
M=D
@SP       //SP++
M=M+1


 //Pushing 333 to stack
@333
D=A
@SP       //SP = 333
A=M
M=D
@SP       //SP++
M=M+1


 //Pushing 888 to stack
@888
D=A
@SP       //SP = 888
A=M
M=D
@SP       //SP++
M=M+1


//Popping from stack
@SP
M=M-1
A=M
D=M
@var.8
M=D


//Popping from stack
@SP
M=M-1
A=M
D=M
@var.3
M=D


//Popping from stack
@SP
M=M-1
A=M
D=M
@var.1
M=D


 //Pushing var.3 to stack
@var.3
D=M
@SP     //Pushing from D Register to main stack
A=M
M=D
@SP
M=M+1


 //Pushing var.1 to stack
@var.1
D=M
@SP     //Pushing from D Register to main stack
A=M
M=D
@SP
M=M+1

//Performing a  subtraction
//Popping from stack
@SP
M=M-1
A=M
D=M
//Popping from stack
@SP
M=M-1
A=M
M = M-D
@SP
M=M+1


 //Pushing var.8 to stack
@var.8
D=M
@SP     //Pushing from D Register to main stack
A=M
M=D
@SP
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
