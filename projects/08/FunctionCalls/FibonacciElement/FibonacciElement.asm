//This is generated code
//Provided by a generous grant from the OG AKA thepigeonfighter


//--------Initializing -----------
//@256
//D=A
//@SP
//M=D

//(----VMCOMMAND--------)
//----function Sys.init 0----//
(Sys.init)
D=0

//(----VMCOMMAND--------)
//----push constant 4----//

@4
D=A
@SP       //SP = 4
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Main.fibonacci 1----//
//--------CALLING Sys-----
//Pushing Stack Snapshot to Stack
@Sys$ret.3
D=A
@SP
A=M
M=D
@SP
M=M+1
@LCL
D=M
@SP
A=M
M=D
@SP
M=M+1
@ARG
D=M
@SP
A=M
M=D
@SP
M=M+1
@THIS
D=M
@SP
A=M
M=D
@SP
M=M+1
@THAT
D=M
@SP
A=M
M=D
@SP
M=M+1
//---------Stack Snapshot Complete ------
@6
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Main.fibonacci
0;JMP
(Sys$ret.3)

//(----VMCOMMAND--------)
//----label WHILE----//
(WHILE)

//(----VMCOMMAND--------)
//----goto WHILE----//
@WHILE
0;JMP


//This concludes the asm file. 
//This is generated code
//Provided by a generous grant from the OG AKA thepigeonfighter

//(----VMCOMMAND--------)
//----function Main.fibonacci 0----//
(Main.fibonacci)
D=0

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
//----lt----//
//Popping from stack
@SP
M=M-1
A=M
D=M
//Popping from stack
@SP
M=M-1
A=M
D=M-D
@TRUE.1
D;JLT   // x==0 
D=-1       // Set Result to false
@SP
A=M
M=D
@SP
M=M+1
@RESULT.1
0;JMP
(TRUE.1)
D=1      // Set Result to true
@SP
A=M
M=D
@SP
M=M+1
(RESULT.1)   // On Exit

//(----VMCOMMAND--------)
//----if-goto IF_TRUE----//
//Popping from stack
@SP
M=M-1
A=M
D=M
@IF_TRUE
D;JGT

//(----VMCOMMAND--------)
//----goto IF_FALSE----//
@IF_FALSE
0;JMP

//(----VMCOMMAND--------)
//----label IF_TRUE----//
(IF_TRUE)

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

//(----VMCOMMAND--------)
//----label IF_FALSE----//
(IF_FALSE)

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
//----call Main.fibonacci 1----//
//--------CALLING Main-----
//Pushing Stack Snapshot to Stack
@Main$ret.4
D=A
@SP
A=M
M=D
@SP
M=M+1
@LCL
D=M
@SP
A=M
M=D
@SP
M=M+1
@ARG
D=M
@SP
A=M
M=D
@SP
M=M+1
@THIS
D=M
@SP
A=M
M=D
@SP
M=M+1
@THAT
D=M
@SP
A=M
M=D
@SP
M=M+1
//---------Stack Snapshot Complete ------
@6
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Main.fibonacci
0;JMP
(Main$ret.4)

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
//----call Main.fibonacci 1----//
//--------CALLING Main-----
//Pushing Stack Snapshot to Stack
@Main$ret.5
D=A
@SP
A=M
M=D
@SP
M=M+1
@LCL
D=M
@SP
A=M
M=D
@SP
M=M+1
@ARG
D=M
@SP
A=M
M=D
@SP
M=M+1
@THIS
D=M
@SP
A=M
M=D
@SP
M=M+1
@THAT
D=M
@SP
A=M
M=D
@SP
M=M+1
//---------Stack Snapshot Complete ------
@6
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Main.fibonacci
0;JMP
(Main$ret.5)

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
//This is generated code
//Provided by a generous grant from the OG AKA thepigeonfighter

//(----VMCOMMAND--------)
//----function Sys.init 0----//
(Sys.init)
D=0

//(----VMCOMMAND--------)
//----push constant 4----//

@4
D=A
@SP       //SP = 4
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Main.fibonacci 1----//
//--------CALLING Sys-----
//Pushing Stack Snapshot to Stack
@Sys$ret.6
D=A
@SP
A=M
M=D
@SP
M=M+1
@LCL
D=M
@SP
A=M
M=D
@SP
M=M+1
@ARG
D=M
@SP
A=M
M=D
@SP
M=M+1
@THIS
D=M
@SP
A=M
M=D
@SP
M=M+1
@THAT
D=M
@SP
A=M
M=D
@SP
M=M+1
//---------Stack Snapshot Complete ------
@6
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Main.fibonacci
0;JMP
(Sys$ret.6)

//(----VMCOMMAND--------)
//----label WHILE----//
(WHILE)

//(----VMCOMMAND--------)
//----goto WHILE----//
@WHILE
0;JMP


//This concludes the asm file. 
