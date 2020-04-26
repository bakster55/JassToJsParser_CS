lexer grammar JassLexer;

K_CODE : 'code';
K_HANDLE : 'handle';
K_INTEGER : 'integer';
K_REAL : 'real';
K_BOOLEAN : 'boolean';
K_STRING : 'string';
K_TRUE : 'true';
K_FALSE : 'false';
K_NULL : 'null';
K_NOT : 'not';
K_AND : 'and';
K_OR : 'or';
K_FUNCTION : 'function';
K_RETURN : 'return';
K_RETURNS : 'returns';
K_EXITWHEN : 'exitwhen';
K_LOOP : 'loop';
K_ENDLOOP : 'endloop';
K_ELSEIF : 'elseif';
K_ELSE : 'else';
K_CALL : 'call';
K_IF : 'if';
K_THEN : 'then';
K_ENDIF : 'endif';
K_DEBUG : 'debug';
K_SET : 'set';
K_TYPE : 'type';
K_EXTENDS : 'extends';
K_GLOBALS : 'globals';
K_ENDGLOBALS : 'endglobals';
K_CONSTANT : 'constant';
K_NATIVE : 'native';
K_TAKES : 'takes';
K_NOTHING : 'nothing';
K_ENDFUNCTION : 'endfunction';
K_LOCAL : 'local';
K_ARRAY : 'array';

ADD : '+';
SUB : '-';
MULT : '*';
DIV : '/';
GT : '>';
LT : '<';
EQ : '==';
NEQ : '!=';
GTEQ : '>=';
LTEQ : '<=';
O_BRACK : '[';
C_BRACK : ']';
O_PAR : '(';
C_PAR : ')';
COMMA : ',';
ASSIGN : '=';

DECIMAL
 : [1-9] [0-9]*
 ;

OCTAL
 : '0' [0-7]*
 ;

HEX
 : '$' [0-9a-fA-F]+
 | '0' [xX] [0-9a-fA-F]+
 ;

FOURCC
 : ['] .*? [']
 ;

REAL_CONST
 : [0-9]+ '.' [0-9]*
 | '.' [0-9]+
 ;

STRING_CONST
 : '"' ( ~["\\] | '\\'. )*? '"'
 ;

ID
 : [a-zA-Z] ([a-zA-Z0-9_]* [a-zA-Z0-9])?
 ;

WS
 : [ \t\r\n]+ -> channel(HIDDEN)
 ;

COMMENT
 : '//' ~[\r\n]* -> skip
 ;