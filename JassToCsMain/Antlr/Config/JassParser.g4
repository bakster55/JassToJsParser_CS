parser grammar JassParser;

file
 : (declr)* func*
 ;

declr
 : typedef
 | globals
 | native_func
 ;

typedef
 : K_TYPE id K_EXTENDS (K_HANDLE | id)
 ;

globals
 : K_GLOBALS global_var_list K_ENDGLOBALS
 ;

global_var_list
 : (global_var_declr | var_declr)*
 ;

global_var_declr
 : K_CONSTANT type id ASSIGN expr
 ;

native_func
 : K_CONSTANT? K_NATIVE func_declr
 ;

func_declr
 : id K_TAKES (K_NOTHING | param_list) K_RETURNS (type | K_NOTHING)
 ;

param_list
 : type id (COMMA type id)*
 ;

func
 : K_CONSTANT? K_FUNCTION func_declr local_var_list statement_list K_ENDFUNCTION
 ;

local_var_list
 : local_var_declr*
 ;

local_var_declr
 : K_LOCAL var_declr
 ;

var_declr
 : type id (ASSIGN expr)?
 | type K_ARRAY id
 ;

statement_list
 : (statement)*
 ;

statement
 : set
 | call
 | ifthenelse
 | loop
 | exitwhen
 | return_stat
 | debug
 ;

set
 : K_SET id ASSIGN expr
 | K_SET id O_BRACK expr C_BRACK ASSIGN expr
 ;

call
 : K_CALL id O_PAR args? C_PAR
 ;

args
 : expr (COMMA expr)*
 ;

ifthenelse
 : K_IF expr K_THEN statement_list else_clause? K_ENDIF
 ;

else_clause
 : K_ELSE statement_list
 | K_ELSEIF expr K_THEN statement_list else_clause?
 ;

loop
 : K_LOOP statement_list K_ENDLOOP
 ;

exitwhen
 : K_EXITWHEN expr
 ;

return_stat
 : K_RETURN expr?
 ;

debug
 : K_DEBUG (set | call | ifthenelse | loop)
 ;

expr
 : ADD expr
 | SUB expr
 | K_NOT expr
 | expr (MULT | DIV) expr
 | expr (ADD | SUB) expr
 | expr (GT | LT | GTEQ | LTEQ) expr
 | expr (EQ | NEQ) expr
 | expr (K_AND | K_OR) expr
 | func_call
 | array_ref
 | func_ref
 | id
 | constant
 | parens
 ;

func_call
 : id O_PAR args? C_PAR
 ;

array_ref
 : id O_BRACK expr C_BRACK
 ;

func_ref
 : K_FUNCTION id
 ;

constant
 : int_const
 | REAL_CONST
 | boolConst
 | stringConst
 | K_NULL
 ;

int_const
 : decimal
 | OCTAL
 | hex
 | FOURCC
 ;

decimal
 : DECIMAL
 ;

hex
 : HEX
 ;

parens
 : O_PAR expr C_PAR
 ;

boolConst
 : K_TRUE
 | K_FALSE
 ;

stringConst
 : STRING_CONST
 ;

type
 : id
 | K_CODE
 | K_HANDLE
 | K_INTEGER
 | K_REAL
 | K_BOOLEAN
 | K_STRING
 ;

id
 : ID
 ;