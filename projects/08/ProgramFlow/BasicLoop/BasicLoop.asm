//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter

//(----VMCOMMAND--------)
//----push constant 0----//

@0
D=A
@SP       //SP = 0
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop local 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@1
A=M
M=D

//(----VMCOMMAND--------)
//----label LOOP_START----//
(LOOP_START)

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
//----pop local 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@1
A=M
M=D

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
//----push constant 1----//

@1
D=A
@SP       //SP = 1
A=M
M=D
@SP       //SP++
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
//----pop argument 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@2
A=M
M=D

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
//----if-goto LOOP_START----//
//Popping from stack
@SP
M=M-1
A=M
D=M
@LOOP_START
D;JGT

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


//This concludes the asm file. 
