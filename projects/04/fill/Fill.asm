// This file is part of www.nand2tetris.org
// and the book "The Elements of Computing Systems"
// by Nisan and Schocken, MIT Press.
// File name: projects/04/Fill.asm

// Runs an infinite loop that listens to the keyboard input.
// When a key is pressed (any key), the program blackens the screen,
// i.e. writes "black" in every pixel;
// the screen should remain fully black as long as the key is pressed. 
// When no key is pressed, the program clears the screen, i.e. writes
// "white" in every pixel;
// the screen should remain fully clear as long as no key is pressed.
// IF KBD != 0 
// TURNSCREENBLACK
//IF KBD == 0
// TURNSCREENWHITE
// Put your code here.

@8192 //pixels filled
D=A
@n
M =D


(LISTENERLOOP)
@KBD
D=M
@TURNSCREENBLACK
D;JNE

@TURNSCREENWHITE
D;JEQ

@LISTENERLOOP
0;JMP

(TURNSCREENBLACK)
@iterator
D=M
@n
D=D-M
@ResetVars
D;JGT
@address
A=M
M=-1
@iterator
M = M+1
@address
M=M+1
@TURNSCREENBLACK
0;JMP


(TURNSCREENWHITE)
@iterator
D=M
@n
D=D-M
@ResetVars
D;JGT
@address
A=M
M=0
@iterator
M = M+1
@address
M=M+1
@TURNSCREENWHITE
0;JMP
(ResetVars)
@SCREEN
D=A
@address
M=D
@iterator
M=1
@LISTENERLOOP
0;JMP