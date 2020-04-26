parser grammar JassParser;

options {
    tokenVocab=JassLexer;
}

file
 : declr* func*
 ;

declr
 : typedef
 | globals
 | nativeFunc
 ;

typedef
 : K_TYPE id K_EXTENDS (K_HANDLE | id)
 ;

globals
 : K_GLOBALS globalVarList K_ENDGLOBALS
 ;

globalVarList
 : (constDeclr | varDeclr)*
 ;

constDeclr
 : K_CONSTANT type id ASSIGN expr
 ;

nativeFunc
 : K_CONSTANT? K_NATIVE funcDeclr
 ;

funcDeclr
 : id K_TAKES (K_NOTHING | paramList) K_RETURNS (type | K_NOTHING)
 ;

paramList
 : type id (COMMA type id)*
 ;

func
 : K_CONSTANT? K_FUNCTION funcDeclr localVarList statementList K_ENDFUNCTION
 ;

localVarList
 : (K_LOCAL varDeclr)*
 ;

varDeclr
 : type id (ASSIGN expr)?
 | type K_ARRAY id
 ;

statementList
 : (statement)*
 ;

statement
 : set
 | call
 | ifthenelse
 | loop
 | exitwhen
 | returnStat
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
 : K_IF expr K_THEN statementList elseClause? K_ENDIF
 ;

elseClause
 : K_ELSE statementList
 | K_ELSEIF expr K_THEN statementList elseClause?
 ;

loop
 : K_LOOP statementList K_ENDLOOP
 ;

exitwhen
 : K_EXITWHEN expr
 ;

returnStat
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
 | funcCall
 | arrayRef
 | funcRef
 | id
 | constant
 | parens
 ;

funcCall
 : id O_PAR args? C_PAR
 ;

arrayRef
 : id O_BRACK expr C_BRACK
 ;

funcRef
 : K_FUNCTION id
 ;

constant
 : intConst
 | REAL_CONST
 | boolConst
 | stringConst
 | K_NULL
 ;

intConst
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