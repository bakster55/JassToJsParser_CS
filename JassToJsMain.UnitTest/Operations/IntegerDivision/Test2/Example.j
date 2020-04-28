globals
integer ov=0
endglobals
function FuncName takes nothing returns nothing
local integer b
set b = GetHeroLevel(ov) / 25 + 1
set b = GetPlayerTeam(ov) / 25 + 1
set b = CAMERA_MARGIN_LEFT / 25 + 1
endfunction