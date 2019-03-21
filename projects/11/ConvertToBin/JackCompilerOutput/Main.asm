//This is generated code
//Provided by a generous grant from the OG AKA thepigeonfighter

//(----VMCOMMAND--------)
//----function Main.main 1----//
(Main.main)
D=0
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----push constant 8001----//

@8001
D=A
@SP       //SP = 8001
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----push constant 16----//

@16
D=A
@SP       //SP = 16
A=M
M=D
@SP       //SP++
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
//----neg----//
//Popping from stack
@SP
M=M-1
A=M
D=M
D=-D
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----call Main.fillMemory 3----//
//--------CALLING Main-----
//Pushing Stack Snapshot to Stack
@Main$ret.1
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
@8
D=A
@SP
D=M-D
@ARG
M=D
@SP
D=M
@LCL
M=D
@Main.fillMemory
0;JMP
(Main$ret.1)

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
//----push constant 8000----//

@8000
D=A
@SP       //SP = 8000
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Memory.peek 1----//
//--------CALLING Main-----
//Pushing Stack Snapshot to Stack
@Main$ret.2
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
@Memory.peek
0;JMP
(Main$ret.2)

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
//----call Main.convert 1----//
//--------CALLING Main-----
//Pushing Stack Snapshot to Stack
@Main$ret.3
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
@Main.convert
0;JMP
(Main$ret.3)

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
//----function Main.convert 3----//
(Main.convert)
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
//----label Main_convert_1----//
(Main_convert_1)

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
//----if-goto Main_convert_2----//
//Popping from stack
@SP
M=M-1
A=M
D=M
@Main_convert_2
D;JGT

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
//----call Main.nextMask 1----//
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
@Main.nextMask
0;JMP
(Main$ret.4)

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
//----push constant 16----//

@16
D=A
@SP       //SP = 16
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----gt----//
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
@TRUE.0
D;JGT   // x==0 
D=-1       // Set Result to false
@SP
A=M
M=D
@SP
M=M+1
@RESULT.0
0;JMP
(TRUE.0)
D=1      // Set Result to true
@SP
A=M
M=D
@SP
M=M+1
(RESULT.0)   // On Exit

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
//----if-goto Main_convert_3----//
//Popping from stack
@SP
M=M-1
A=M
D=M
@Main_convert_3
D;JGT

//(----VMCOMMAND--------)
//----goto Main_convert_4----//
@Main_convert_4
0;JMP

//(----VMCOMMAND--------)
//----label Main_convert_3----//
(Main_convert_3)

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
//----and----//
//Popping from stack
@SP
M=M-1
A=M
D=M
//Popping from stack
@SP
M=M-1
A=M
M=D&M
@SP
M=M+1

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
//----eq----//
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
D;JEQ   // x==0 
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
//----if-goto Main_convert_6----//
//Popping from stack
@SP
M=M-1
A=M
D=M
@Main_convert_6
D;JGT

//(----VMCOMMAND--------)
//----goto Main_convert_7----//
@Main_convert_7
0;JMP

//(----VMCOMMAND--------)
//----label Main_convert_6----//
(Main_convert_6)

//(----VMCOMMAND--------)
//----push constant 8000----//

@8000
D=A
@SP       //SP = 8000
A=M
M=D
@SP       //SP++
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
//----push constant 1----//

@1
D=A
@SP       //SP = 1
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Memory.poke 2----//
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
@Memory.poke
0;JMP
(Main$ret.5)

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
//----goto Main_convert_8----//
@Main_convert_8
0;JMP

//(----VMCOMMAND--------)
//----label Main_convert_7----//
(Main_convert_7)

//(----VMCOMMAND--------)
//----push constant 8000----//

@8000
D=A
@SP       //SP = 8000
A=M
M=D
@SP       //SP++
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
//----push constant 0----//

@0
D=A
@SP       //SP = 0
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----call Memory.poke 2----//
//--------CALLING Main-----
//Pushing Stack Snapshot to Stack
@Main$ret.6
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
@Memory.poke
0;JMP
(Main$ret.6)

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
//----label Main_convert_8----//
(Main_convert_8)

//(----VMCOMMAND--------)
//----goto Main_convert_5----//
@Main_convert_5
0;JMP

//(----VMCOMMAND--------)
//----label Main_convert_4----//
(Main_convert_4)

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
//----label Main_convert_5----//
(Main_convert_5)

//(----VMCOMMAND--------)
//----goto Main_convert_1----//
@Main_convert_1
0;JMP

//(----VMCOMMAND--------)
//----label Main_convert_2----//
(Main_convert_2)

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
//----function Main.nextMask 0----//
(Main.nextMask)
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
//----push constant 0----//

@0
D=A
@SP       //SP = 0
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----eq----//
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
@TRUE.2
D;JEQ   // x==0 
D=-1       // Set Result to false
@SP
A=M
M=D
@SP
M=M+1
@RESULT.2
0;JMP
(TRUE.2)
D=1      // Set Result to true
@SP
A=M
M=D
@SP
M=M+1
(RESULT.2)   // On Exit

//(----VMCOMMAND--------)
//----if-goto Main_nextMask_1----//
//Popping from stack
@SP
M=M-1
A=M
D=M
@Main_nextMask_1
D;JGT

//(----VMCOMMAND--------)
//----goto Main_nextMask_2----//
@Main_nextMask_2
0;JMP

//(----VMCOMMAND--------)
//----label Main_nextMask_1----//
(Main_nextMask_1)

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
//----goto Main_nextMask_3----//
@Main_nextMask_3
0;JMP

//(----VMCOMMAND--------)
//----label Main_nextMask_2----//
(Main_nextMask_2)

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
//----call Math.multiply 2----//
//--------CALLING Main-----
//Pushing Stack Snapshot to Stack
@Main$ret.7
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
@Math.multiply
0;JMP
(Main$ret.7)

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
//----label Main_nextMask_3----//
(Main_nextMask_3)

//(----VMCOMMAND--------)
//----function Main.fillMemory 0----//
(Main.fillMemory)
D=0

//(----VMCOMMAND--------)
//----label Main_fillMemory_1----//
(Main_fillMemory_1)

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
//----push constant 0----//

@0
D=A
@SP       //SP = 0
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----gt----//
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
@TRUE.3
D;JGT   // x==0 
D=-1       // Set Result to false
@SP
A=M
M=D
@SP
M=M+1
@RESULT.3
0;JMP
(TRUE.3)
D=1      // Set Result to true
@SP
A=M
M=D
@SP
M=M+1
(RESULT.3)   // On Exit

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
//----if-goto Main_fillMemory_2----//
//Popping from stack
@SP
M=M-1
A=M
D=M
@Main_fillMemory_2
D;JGT

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
//----push argument 2----//

@2
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
//----call Memory.poke 2----//
//--------CALLING Main-----
//Pushing Stack Snapshot to Stack
@Main$ret.8
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
@Memory.poke
0;JMP
(Main$ret.8)

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
//----push constant 1----//

@1
D=A
@SP       //SP = 1
A=M
M=D
@SP       //SP++
M=M+1

//(----VMCOMMAND--------)
//----neg----//
//Popping from stack
@SP
M=M-1
A=M
D=M
D=-D
@SP
A=M
M=D
@SP
M=M+1

//(----VMCOMMAND--------)
//----pop argument 1----//

@2 // Argument pointer
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
//----goto Main_fillMemory_1----//
@Main_fillMemory_1
0;JMP

//(----VMCOMMAND--------)
//----label Main_fillMemory_2----//
(Main_fillMemory_2)

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


//This concludes the asm file. 
