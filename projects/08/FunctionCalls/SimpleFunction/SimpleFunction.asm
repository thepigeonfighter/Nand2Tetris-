//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter

//(----VMCOMMAND--------)
//----function SimpleFunction.test 2----//
(SimpleFunction.test)
@SP
M=M+1
@SP
M=M+1

//(----VMCOMMAND--------)
//----push local 0----//

@1
A=M
D=M
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push local 1----//

@1
D=M
@SP
A=M
M=D
@SP
M=M+1
@1
D=A
@SP       //SP = 1
A=M
M=D
@SP       //SP++
M=M+1
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
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----add----//
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

//(----VMCOMMAND--------)
//----not----//
//Popping from stack
@SP
M=M-1
A=M
D=M
D=!D
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push argument 0----//

@2
A=M
D=M
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----add----//
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

//(----VMCOMMAND--------)
//----push argument 1----//

@2
D=M
@SP
A=M
M=D
@SP
M=M+1
@1
D=A
@SP       //SP = 1
A=M
M=D
@SP       //SP++
M=M+1
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
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----sub----//
//Popping from stack
@SP
M=M-1
A=M
D=M
//Popping from stack
@SP
M=M-1
A=M
M=M-D
@SP
M=M+1

//(----VMCOMMAND--------)
//----return----//
@LCL
D=M
@endframe
M=D
@5
A=D-A
D=M
@retAddress
M=D
//Popping from stack
@SP
M=M-1
A=M
D=M
@ARG
A=M
M=D
D=A
@SP
M=D+1
@endframe
D=M
A=D-1
D=M
@THAT     //Resets THAT
M=D
@2
D=A
@endframe
A=M-D
D=M
@THIS     //Resets THIS
M=D
@3
D=A
@endframe
A=M-D
D=M
@ARG     //Resets ARG
M=D
@4
D=A
@endframe
A=M-D
D=M
@LCL    //Resets LCL
M=D
@retAddress
A=M
0;JMP


//This concludes the asm file. 
