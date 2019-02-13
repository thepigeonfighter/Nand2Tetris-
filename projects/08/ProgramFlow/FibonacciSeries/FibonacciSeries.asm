//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter

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
//----pop pointer 1----//

//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@4
M=D

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
//----pop that 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@4
A=M
M=D

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
//----pop that 1----//

@4 // That pointer
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
//Popping from stack
@SP
M=M-1
A=M
D=M
@SP
M=M+1
A=M
A=M
M=D
@SP
M=M-1

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
//----push constant 2----//

@2
D=A
@SP       //SP = 2
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
//----label MAIN_LOOP_START----//
(MAIN_LOOP_START)

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
//----if-goto COMPUTE_ELEMENT----//
//Popping from stack
@SP
M=M-1
A=M
D=M
@COMPUTE_ELEMENT
D;JGT

//(----VMCOMMAND--------)
//----goto END_PROGRAM----//
@END_PROGRAM
0;JMP

//(----VMCOMMAND--------)
//----label COMPUTE_ELEMENT----//
(COMPUTE_ELEMENT)

//(----VMCOMMAND--------)
//----push that 0----//

@4
A=M
D=M
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push that 1----//

@4
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
//----pop that 2----//

@4 // That pointer
D=M
@SP
A=M
M=D
@SP
M=M+1
@2
D=A
@SP       //SP = 2
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
//Popping from stack
@SP
M=M-1
A=M
D=M
@SP
M=M+1
A=M
A=M
M=D
@SP
M=M-1

//(----VMCOMMAND--------)
//----push pointer 1----//

//Pointer Push Command
@4
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
//----pop pointer 1----//

//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@4
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
//----goto MAIN_LOOP_START----//
@MAIN_LOOP_START
0;JMP

//(----VMCOMMAND--------)
//----label END_PROGRAM----//
(END_PROGRAM)


//This concludes the asm file. 
