globals
integer ov=0
endglobals
function FuncName takes integer i returns string
local integer b
set b=i-(i/ ov)*ov
endfunction