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
//----push constant 4000----//

@4000
D=A
@SP       //SP = 4000
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop pointer 0----//

//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@3
M=D

//(----VMCOMMAND--------)
//----push constant 5000----//

@5000
D=A
@SP       //SP = 5000
A=M
M=D
@SP       //SP++
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
//----call Sys.main 0----//
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
@Sys.main
0;JMP
(Sys$ret.1)

//(----VMCOMMAND--------)
//----pop temp 1----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@6
M=D

//(----VMCOMMAND--------)
//----label LOOP----//
(LOOP)

//(----VMCOMMAND--------)
//----goto LOOP----//
@LOOP
0;JMP

//(----VMCOMMAND--------)
//----function Sys.main 5----//
(Sys.main)
D=0
@SP
A=M
M=D
@SP
M=M+1
@SP
A=M
M=D
@SP
M=M+1
@SP
A=M
M=D
@SP
M=M+1
@SP
A=M
M=D
@SP
M=M+1
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push constant 4001----//

@4001
D=A
@SP       //SP = 4001
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop pointer 0----//

//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@3
M=D

//(----VMCOMMAND--------)
//----push constant 5001----//

@5001
D=A
@SP       //SP = 5001
A=M
M=D
@SP       //SP++
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
//----push constant 200----//

@200
D=A
@SP       //SP = 200
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop local 1----//

@1 // Local pointer
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
//----push constant 40----//

@40
D=A
@SP       //SP = 40
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop local 2----//

@1 // Local pointer
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
//----push constant 6----//

@6
D=A
@SP       //SP = 6
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop local 3----//

@1 // Local pointer
D=M
@SP
A=M
M=D
@SP
M=M+1
@3
D=A
@SP       //SP = 3
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
//----push constant 123----//

@123
D=A
@SP       //SP = 123
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Sys.add12 1----//
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
@Sys.add12
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
//----push local 2----//

@1
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
A=M
D=M
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push local 3----//

@1
D=M
@SP
A=M
M=D
@SP
M=M+1
@3
D=A
@SP       //SP = 3
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
//----push local 4----//

@1
D=M
@SP
A=M
M=D
@SP
M=M+1
@4
D=A
@SP       //SP = 4
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

//(----VMCOMMAND--------)
//----function Sys.add12 0----//
(Sys.add12)
D=0

//(----VMCOMMAND--------)
//----push constant 4002----//

@4002
D=A
@SP       //SP = 4002
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop pointer 0----//

//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@3
M=D

//(----VMCOMMAND--------)
//----push constant 5002----//

@5002
D=A
@SP       //SP = 5002
A=M
M=D
@SP       //SP++
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
//----push constant 12----//

@12
D=A
@SP       //SP = 12
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
//----push constant 4000----//

@4000
D=A
@SP       //SP = 4000
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop pointer 0----//

//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@3
M=D

//(----VMCOMMAND--------)
//----push constant 5000----//

@5000
D=A
@SP       //SP = 5000
A=M
M=D
@SP       //SP++
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
//----call Sys.main 0----//
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
@Sys.main
0;JMP
(Sys$ret.3)

//(----VMCOMMAND--------)
//----pop temp 1----//

//Popping from stack
@SP
M=M-1
A=M
D=M
@6
M=D

//(----VMCOMMAND--------)
//----label LOOP----//
(LOOP)

//(----VMCOMMAND--------)
//----goto LOOP----//
@LOOP
0;JMP

//(----VMCOMMAND--------)
//----function Sys.main 5----//
(Sys.main)
D=0
@SP
A=M
M=D
@SP
M=M+1
@SP
A=M
M=D
@SP
M=M+1
@SP
A=M
M=D
@SP
M=M+1
@SP
A=M
M=D
@SP
M=M+1
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push constant 4001----//

@4001
D=A
@SP       //SP = 4001
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop pointer 0----//

//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@3
M=D

//(----VMCOMMAND--------)
//----push constant 5001----//

@5001
D=A
@SP       //SP = 5001
A=M
M=D
@SP       //SP++
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
//----push constant 200----//

@200
D=A
@SP       //SP = 200
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop local 1----//

@1 // Local pointer
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
//----push constant 40----//

@40
D=A
@SP       //SP = 40
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop local 2----//

@1 // Local pointer
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
//----push constant 6----//

@6
D=A
@SP       //SP = 6
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop local 3----//

@1 // Local pointer
D=M
@SP
A=M
M=D
@SP
M=M+1
@3
D=A
@SP       //SP = 3
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
//----push constant 123----//

@123
D=A
@SP       //SP = 123
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Sys.add12 1----//
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
@Sys.add12
0;JMP
(Sys$ret.4)

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
//----push local 2----//

@1
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
A=M
D=M
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push local 3----//

@1
D=M
@SP
A=M
M=D
@SP
M=M+1
@3
D=A
@SP       //SP = 3
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
//----push local 4----//

@1
D=M
@SP
A=M
M=D
@SP
M=M+1
@4
D=A
@SP       //SP = 4
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

//(----VMCOMMAND--------)
//----function Sys.add12 0----//
(Sys.add12)
D=0

//(----VMCOMMAND--------)
//----push constant 4002----//

@4002
D=A
@SP       //SP = 4002
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----pop pointer 0----//

//Pointer Pop Command
//Popping from stack
@SP
M=M-1
A=M
D=M
@3
M=D

//(----VMCOMMAND--------)
//----push constant 5002----//

@5002
D=A
@SP       //SP = 5002
A=M
M=D
@SP       //SP++
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
//----push constant 12----//

@12
D=A
@SP       //SP = 12
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
