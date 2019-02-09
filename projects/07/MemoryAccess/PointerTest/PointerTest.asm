//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter


 //Pushing 3030 to stack
@3030
D=A
@SP       //SP = 3030
A=M
M=D
@SP       //SP++
M=M+1


//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@3
M=D


 //Pushing 3040 to stack
@3040
D=A
@SP       //SP = 3040
A=M
M=D
@SP       //SP++
M=M+1


//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@4
M=D


 //Pushing 32 to stack
@32
D=A
@SP       //SP = 32
A=M
M=D
@SP       //SP++
M=M+1


//Popping to This stack
@3 // This pointer
D=M
@SP     //Pushing from D Register to main stack
A=M
M=D
@SP
M=M+1
//Pushing 2 to stack
@2
D=A
@SP       //SP = 2
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
//Popping from stack
@SP
M=M-1
A=M
D=M
@5
M=D
//Popping from stack
@SP
M=M-1
A=M
D=M
@5      /// Addressing Temp pointer
A=M
M=A
M=D


 //Pushing 46 to stack
@46
D=A
@SP       //SP = 46
A=M
M=D
@SP       //SP++
M=M+1


//Popping to That stack
@4 // That pointer
D=M
@SP     //Pushing from D Register to main stack
A=M
M=D
@SP
M=M+1
//Pushing 6 to stack
@6
D=A
@SP       //SP = 6
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
//Popping from stack
@SP
M=M-1
A=M
D=M
@5
M=D
//Popping from stack
@SP
M=M-1
A=M
D=M
@5      /// Addressing Temp pointer
A=M
M=A
M=D


 //Pointer Push Command
@3
D=M
@SP     //Pushing from D Register to main stack
A=M
M=D
@SP
M=M+1


 //Pointer Push Command
@4
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


 //Pushing 2 to This stack
@3
D=M
@SP     //Pushing from D Register to main stack
A=M
M=D
@SP
M=M+1
//Pushing 2 to stack
@2
D=A
@SP       //SP = 2
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
//Popping from stack
@SP
M=M-1
A=M
A=M
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


 //Pushing 6 to That stack
@4
D=M
@SP     //Pushing from D Register to main stack
A=M
M=D
@SP
M=M+1
//Pushing 6 to stack
@6
D=A
@SP       //SP = 6
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
//Popping from stack
@SP
M=M-1
A=M
A=M
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
