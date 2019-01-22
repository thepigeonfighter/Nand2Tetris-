// This file is part of www.nand2tetris.org
// and the book "The Elements of Computing Systems"
// by Nisan and Schocken, MIT Press.
// File name: projects/04/Mult.asm

// Multiplies R0 and R1 and stores the result in R2.
// (R0, R1, R2 refer to RAM[0], RAM[1], and RAM[2], respectively.)

// Put your code here.
@R2 //Zeros out the product field
M=0

@R0 //Retrieves the first input
D=M

@END
D;JEQ //Skips to end if input == 0

@base //value to be added onto
M=D


@R1
D=M
@END
D;JEQ //Skips to end if input == 0
@n //times value should be added together
M=D

@i //Counter
M=1
(LOOP)
@i
D=M
@n
D=D-M 
@END
D;JGT
@base
D=M
@R2
M=D+M // add to product 
@i
M=M+1 // +1 to counter 
@LOOP
0;JMP //Restart Loop

(END)
@END
0;JMP