//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter


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
//----push constant 6----//

@6
D=A
@SP       //SP = 6
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----push constant 8----//

@8
D=A
@SP       //SP = 8
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Class1.set 2----//
//--------CALLING Sys-----
//Pushing Stack Snapshot to Stack
@Sys$ret.1
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
@7
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Class1.set
0;JMP
(Sys$ret.1)

//(----VMCOMMAND--------)
//----pop temp 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@5
M=D

//(----VMCOMMAND--------)
//----push constant 23----//

@23
D=A
@SP       //SP = 23
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----push constant 15----//

@15
D=A
@SP       //SP = 15
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Class2.set 2----//
//--------CALLING Sys-----
//Pushing Stack Snapshot to Stack
@Sys$ret.2
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
@7
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Class2.set
0;JMP
(Sys$ret.2)

//(----VMCOMMAND--------)
//----pop temp 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@5
M=D

//(----VMCOMMAND--------)
//----call Class1.get 0----//
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
@5
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Class1.get
0;JMP
(Sys$ret.3)

//(----VMCOMMAND--------)
//----call Class2.get 0----//
//--------CALLING Sys-----
//Pushing Stack Snapshot to Stack
@Sys$ret.4
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
@5
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Class2.get
0;JMP
(Sys$ret.4)

//(----VMCOMMAND--------)
//----label WHILE----//
(WHILE)

//(----VMCOMMAND--------)
//----goto WHILE----//
@WHILE
0;JMP


//This concludes the asm file. 
//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter

//(----VMCOMMAND--------)
//----function Class1.set 0----//
(Class1.set)
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
//----pop static 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@Class1.var.0
M=D

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
//----pop static 1----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@Class1.var.1
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
//----function Class1.get 0----//
(Class1.get)
D=0

//(----VMCOMMAND--------)
//----push static 0----//

@Class1.var.0
D=M
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push static 1----//

@Class1.var.1
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
//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter

//(----VMCOMMAND--------)
//----function Class2.set 0----//
(Class2.set)
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
//----pop static 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@Class2.var.0
M=D

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
//----pop static 1----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@Class2.var.1
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
//----function Class2.get 0----//
(Class2.get)
D=0

//(----VMCOMMAND--------)
//----push static 0----//

@Class2.var.0
D=M
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push static 1----//

@Class2.var.1
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
//This is generated code
//Provided by a generous grant from the brain of the OG thepigeonfighter

//(----VMCOMMAND--------)
//----function Sys.init 0----//
(Sys.init)
D=0

//(----VMCOMMAND--------)
//----push constant 6----//

@6
D=A
@SP       //SP = 6
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----push constant 8----//

@8
D=A
@SP       //SP = 8
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Class1.set 2----//
//--------CALLING Sys-----
//Pushing Stack Snapshot to Stack
@Sys$ret.5
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
@7
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Class1.set
0;JMP
(Sys$ret.5)

//(----VMCOMMAND--------)
//----pop temp 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@5
M=D

//(----VMCOMMAND--------)
//----push constant 23----//

@23
D=A
@SP       //SP = 23
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----push constant 15----//

@15
D=A
@SP       //SP = 15
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Class2.set 2----//
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
@7
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Class2.set
0;JMP
(Sys$ret.6)

//(----VMCOMMAND--------)
//----pop temp 0----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@5
M=D

//(----VMCOMMAND--------)
//----call Class1.get 0----//
//--------CALLING Sys-----
//Pushing Stack Snapshot to Stack
@Sys$ret.7
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
@5
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Class1.get
0;JMP
(Sys$ret.7)

//(----VMCOMMAND--------)
//----call Class2.get 0----//
//--------CALLING Sys-----
//Pushing Stack Snapshot to Stack
@Sys$ret.8
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
@5
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Class2.get
0;JMP
(Sys$ret.8)

//(----VMCOMMAND--------)
//----label WHILE----//
(WHILE)

//(----VMCOMMAND--------)
//----goto WHILE----//
@WHILE
0;JMP


//This concludes the asm file. 
