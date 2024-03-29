'TODO: http://en.wikipedia.org/wiki/List_of_XML_and_HTML_character_entity_references
Option Strict Off
Option Explicit On

Namespace Lexicon
    Module mWebLexicon

#Region "LANGUAGE CONSTANTS"
        Const MIME_XLSFO As String = "application/xml" 'http://en.wikipedia.org/wiki/XSL-FO
        Const MIME_XLSFO_2 As String = "text/xml" 'http://en.wikipedia.org/wiki/XSL-FO
        Const MIME_DOCBOOK As String = "application/docbook+xml" 'http://en.wikipedia.org/wiki/DocBook
        Const MIME_HTML As String = "text/html"
        Const MIME_SGML As String = "application/sgml" 'http://en.wikipedia.org/wiki/Standard_Generalized_Markup_Language
        Const MIME_SGML_2 As String = "text/sgml" 'http://en.wikipedia.org/wiki/Standard_Generalized_Markup_Language
        Const MIME_RSS As String = "application/rss+xml" 'http://en.wikipedia.org/wiki/RSS
        Const MIME_ATOM As String = "application/atom+xml"
        Const MIME_MATHML As String = "text/mathml" 'http://www.w3.org/TR/REC-MathML
        Const MIME_MATHML_Custom As String = "text/mathml-renderer" ''http://www.w3.org/TR/REC-MathML
        Const MIME_TEX As String = "application/x-tex" 'TeX
#End Region
#Region "CHARSETS"
        Const CHARSET_ISO_8859_1 As String = "ISO-8859-1"
        Const CHARSET_US_ASCII As String = "US-ASCII"
#End Region
#Region "ENCODINGS"
        Const ENCODING_MAPLE As String = "Maple"
#End Region
#Region "BOOLEANS"
        Public INSIDE_COMMENT As Boolean = False
        Public INSIDE_CDATA As Boolean = False
        Public INSIDE_CURLY As Boolean = False
        Public HTML_TAG_OPENED As Boolean = False
        Public EQUAL_SIGN_TYPED As Boolean = False 'True when "=" is typed inside tags
#End Region
#Region "CHARACTER SETS"
        Const DELIMITERS As String = " {}[]()<>,;:-=/\*?&'@+%~$–!:"
        Const LATIN_1_SUPLEMENT As String = "¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶•¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþ"
        Const LATIN_EXTENDED_A As String = "ĀāĂăĄąĆćĈĉĊċČčĎďĐ"
        Const MISC As String = ".|_"
#End Region
#Region "TOKEN TYPES"
        Enum Tok_Types
            NONE = 0
            LANGLEB = 1     ' Tag start    "<"
            RANGLEB = 2     ' Tag end      ">"
            ZANGLEB = 3     ' Tag on its way to ending "</"
            LSQB = 5        ' BBCode start "["
            RSQB = 6        ' BBCode end   "]"
            ZSQB = 7        ' BCCode on its way to ending "[/"
            LCURLY = 8      ' CSS end
            RCURLY = 9      ' CSS start
            LPARM = 10      ' Left Bracket  "("
            RPARM = 11      ' Right Bracket ")"
            DEL = 12        ' Delimiter
            LSTRING = 13    ' String
            QSTRING = 14    ' Quote
            DIGIT = 15      ' Digit (0-9)
            LVARIABLE = 16  ' Variable
            COMMENT = 17    ' Comment (html/css)
            COMMENT_S = 18  ' Comment start
            COMMENT_E = 19  ' Comment end
            QMARK = 20      ' Question Mark "?"
            COLON = 21      ' Colon ":"
            AMPERSAND = 22  ' Ampersand "&"
            MARKEDSECT = 30 ' Marked Section "<![" "]]>"
            CDATA = 31      ' CDATA starts "CDATA" 
            PINSTRUC_S = 32 ' Processing Instruction Start "<?"
            PINSTRUC_E = 33 ' Processing Instruction End   "<?/"
            AVALUE = 34     ' Attribute Value (AttributeName="this is the value")
            ASET = 35       ' Attribute Set ("=" inside <> tags)
            COLOR_RGB = 50 'RGB Color
            COLOR_ARGB = 51 'ARGB color
            COLOR_HEX = 52 'HEX Color
            COLOR_WEB = 53 'WEB Color
            KEYWORD = 90    ' Keyword (html/css)
            ATTRIBUTE = 91  ' Attribute
            XINCLUDE = 92   ' ![INCLUDE[
            XIGNORE = 93    ' ![IGNORE[
            EOL = 98        ' End of Line
            EOP = 99        ' end of File or error triggered
        End Enum
        Public TokType As Tok_Types         ' Hold the Token Type
#End Region
#Region "MISC"
        Public CharPos As Integer           ' Current processing char
        Public Source As String             ' Source to scan
        Public Token As String              ' Hold the returned Token
#End Region
#Region "KEYWORDS"
        Public KEYW_HTML(120) As String      ' Hold HTML/XHTML Keywords
        Public KEYW_BBCODE(25) As String    ' Hold BBCode Keywords
        Public KEYW_MATHML(120) As String    ' Hold MathML Keywords
        Public ATTR_HTML(99) As String      ' Hold HTML/XHTML Attributes
        Public ATTR_MATHML(99) As String    ' Hold MathML Attributes
        Public COLOR_HTML(99) As String     ' Hold HTML Colornames
        Public MATHML_NAMEDSPACE(6) As String ' Hold values for the Namedspace attribute in MathML
        Public MATHML_INVOPS(6) As String   ' Hold MathML Invisible Operators
        Public MATHML_LINEBREAK(6) As String ' Hold MathML Linebreak Attribute values
        Sub InvokeKeywords()
            'TODO: Add all keywords from HTML/CSS
            'COLORNAMES
            'Html 4 standard
            COLOR_HTML(0) = "AQUA"
            COLOR_HTML(1) = "BLACK"
            COLOR_HTML(2) = "BLUE"
            COLOR_HTML(3) = "FUCHSIA"
            COLOR_HTML(4) = "GRAY"
            COLOR_HTML(5) = "GREEN"
            COLOR_HTML(6) = "LIME"
            COLOR_HTML(7) = "MAROON"
            COLOR_HTML(8) = "NAVY"
            COLOR_HTML(9) = "OLIVE"
            COLOR_HTML(10) = "PURPLE"
            COLOR_HTML(11) = "RED"
            COLOR_HTML(12) = "SILVER"
            COLOR_HTML(13) = "TEAL"
            COLOR_HTML(14) = "WHITE"
            COLOR_HTML(15) = "YELLOW"
            'HTML ATTRIBUTES
            ATTR_HTML(0) = "LANG"
            'HTML KEYWORDS
            'Basic
            KEYW_HTML(0) = "HTML"
            KEYW_HTML(1) = "BODY"
            KEYW_HTML(2) = "DOCTYPE"
            KEYW_HTML(3) = "H1"
            KEYW_HTML(4) = "H2"
            KEYW_HTML(5) = "H3"
            KEYW_HTML(6) = "H4"
            KEYW_HTML(7) = "H5"
            KEYW_HTML(8) = "H6"
            KEYW_HTML(9) = "P"
            KEYW_HTML(10) = "BR"
            KEYW_HTML(11) = "HR"
            'Char Format
            KEYW_HTML(12) = "B"
            KEYW_HTML(13) = "FONT"
            KEYW_HTML(14) = "I"
            KEYW_HTML(15) = "EM"
            KEYW_HTML(16) = "BIG"
            KEYW_HTML(17) = "STRONG"
            KEYW_HTML(18) = "SMALL"
            KEYW_HTML(19) = "SUP"
            KEYW_HTML(20) = "SUB"
            KEYW_HTML(21) = "BDO"
            KEYW_HTML(22) = "U"
            'Output
            KEYW_HTML(23) = "PRE"
            KEYW_HTML(24) = "CODE"
            KEYW_HTML(25) = "TT"
            KEYW_HTML(26) = "KBD"
            KEYW_HTML(27) = "VAR"
            KEYW_HTML(28) = "DFN"
            KEYW_HTML(29) = "SAMP"
            KEYW_HTML(30) = "XMP"
            'Blocks
            KEYW_HTML(31) = "ACRONYM"
            KEYW_HTML(32) = "ABBR"
            KEYW_HTML(33) = "ADRESS"
            KEYW_HTML(34) = "BLOCKQUOTE"
            KEYW_HTML(35) = "CENTER"
            KEYW_HTML(36) = "Q"
            KEYW_HTML(37) = "CITE"
            KEYW_HTML(38) = "INS"
            KEYW_HTML(39) = "DEL"
            KEYW_HTML(40) = "S"
            KEYW_HTML(41) = "STRIKE"
            'Links
            KEYW_HTML(42) = "A"
            KEYW_HTML(43) = "LINK"
            'Frames
            KEYW_HTML(44) = "FRAME"
            KEYW_HTML(45) = "FRAMESET"
            KEYW_HTML(46) = "NOFRAMES"
            KEYW_HTML(47) = "IFRAME"
            'Input
            KEYW_HTML(48) = "FORM"
            KEYW_HTML(49) = "INPUT"
            KEYW_HTML(50) = "TEXTAREA"
            KEYW_HTML(51) = "BUTTON"
            KEYW_HTML(52) = "SELECT"
            KEYW_HTML(53) = "OPTGROUP"
            KEYW_HTML(54) = "OPTION"
            KEYW_HTML(55) = "LABEL"
            KEYW_HTML(56) = "FIELDSET"
            KEYW_HTML(57) = "LEGEND"
            KEYW_HTML(58) = "ISINDEX"
            'Lists
            KEYW_HTML(59) = "UL"
            KEYW_HTML(60) = "OL"
            KEYW_HTML(61) = "LI"
            KEYW_HTML(62) = "DIR"
            KEYW_HTML(63) = "DL"
            KEYW_HTML(64) = "DT"
            KEYW_HTML(65) = "DD"
            KEYW_HTML(66) = "MENU"
            'Images
            KEYW_HTML(67) = "IMG"
            KEYW_HTML(68) = "MAP"
            KEYW_HTML(69) = "AREA"
            'Tables
            KEYW_HTML(70) = "TABLE"
            KEYW_HTML(71) = "CAPTION"
            KEYW_HTML(72) = "TH"
            KEYW_HTML(73) = "TR"
            KEYW_HTML(74) = "TD"
            KEYW_HTML(75) = "THEAD"
            KEYW_HTML(76) = "TBODY"
            KEYW_HTML(77) = "TFOOT"
            KEYW_HTML(78) = "COL"
            KEYW_HTML(79) = "COLGROUP"
            'Styles
            KEYW_HTML(80) = "STYLE"
            KEYW_HTML(81) = "DIV"
            KEYW_HTML(82) = "SPAN"
            'Meta Info
            KEYW_HTML(83) = "HEAD"
            KEYW_HTML(84) = "TITLE"
            KEYW_HTML(85) = "META"
            KEYW_HTML(86) = "BASE"
            KEYW_HTML(87) = "BASEFONT"
            'Programming
            KEYW_HTML(88) = "SCRIPT"
            KEYW_HTML(89) = "NOSCRIPT"
            KEYW_HTML(90) = "APPLET"
            KEYW_HTML(91) = "OBJECT"
            KEYW_HTML(92) = "PARAM"
            'Core Attributes
            KEYW_HTML(93) = "CLASS"
            KEYW_HTML(94) = "ID"
            KEYW_HTML(95) = "STYLE"
            KEYW_HTML(96) = "TITLE"
            'Language Attributes
            KEYW_HTML(97) = "DIR"
            KEYW_HTML(98) = "LANG"
            KEYW_HTML(99) = "LTR"
            KEYW_HTML(100) = "RTL"
            'Keyboard Attributes
            KEYW_HTML(101) = "ACCESSKEY"
            KEYW_HTML(102) = "TABINDEX"
            'Window Events
            KEYW_HTML(103) = "ONLOAD"
            KEYW_HTML(104) = "ONUNLOAD"
            'Form Element Events
            KEYW_HTML(105) = "ONCHANGE"
            KEYW_HTML(106) = "ONSUBMIT"
            KEYW_HTML(107) = "ONRESET"
            KEYW_HTML(108) = "ONSELECT"
            KEYW_HTML(109) = "ONBLUR"
            KEYW_HTML(110) = "ONFOCUS"
            'Keyboard Events
            KEYW_HTML(111) = "ONKEYDOWN"
            KEYW_HTML(112) = "ONKEYPRESS"
            KEYW_HTML(113) = "ONKEYUP"
            'Mouse Events
            KEYW_HTML(114) = "ONCLICK"
            KEYW_HTML(115) = "ONDBLCLICK"
            KEYW_HTML(116) = "ONMOUSEDOWN"
            KEYW_HTML(117) = "ONMOUSEMOVE"
            KEYW_HTML(118) = "ONMOUSEOVER"
            KEYW_HTML(119) = "ONMOUSEOUT"
            KEYW_HTML(120) = "ONMOUSEUP"
            'MATHML ATTRIBUTES              
            'TODO: Add all MathML attributes
            ATTR_MATHML(0) = "FONTSTYLE" '
            ATTR_MATHML(1) = "MATHVARIANT"
            ATTR_MATHML(2) = "MATHSIZE"
            ATTR_MATHML(3) = "MATHCOLOR"
            ATTR_MATHML(4) = "MATHBACKGROUND"
            ATTR_MATHML(5) = "FONTWEIGHT"
            ATTR_MATHML(6) = "FONTSIZE"
            ATTR_MATHML(7) = "FONTFAMILY"
            ATTR_MATHML(8) = "FORM"
            ATTR_MATHML(9) = "FENCE"
            ATTR_MATHML(10) = "SEPARATOR"
            ATTR_MATHML(11) = "LSPACE"
            ATTR_MATHML(12) = "RSPACE"
            ATTR_MATHML(13) = "STRETCHY"
            ATTR_MATHML(14) = "SYMMETRIC"
            ATTR_MATHML(15) = "MAXSIZE"
            ATTR_MATHML(16) = "MINSIZE"
            ATTR_MATHML(17) = "LARGEOP"
            ATTR_MATHML(18) = "MOVABLELIMITS"
            ATTR_MATHML(19) = "WIDTH"
            ATTR_MATHML(20) = "HEIGHT"
            ATTR_MATHML(21) = "DEPTH"
            ATTR_MATHML(22) = "LINEBREAK"
            ATTR_MATHML(23) = "LQUOTE"
            ATTR_MATHML(24) = "RQUOTE"
            ATTR_MATHML(25) = "CLOSURE"
            'MATHML Misc
            MATHML_NAMEDSPACE(0) = "VERYVERYTHINMATHSPACE"
            MATHML_NAMEDSPACE(1) = "VERYTHINMATHSPACE"
            MATHML_NAMEDSPACE(2) = "THINMATHSPACE"
            MATHML_NAMEDSPACE(3) = "MEDIUMMATHSPACE"
            MATHML_NAMEDSPACE(4) = "THICKMATHSPACE"
            MATHML_NAMEDSPACE(5) = "VERYTHICKMATHSPACE"
            MATHML_NAMEDSPACE(6) = "VERYVERYTHICKMATHSPACE"
            MATHML_INVOPS(0) = "INVISIBLETIMES"         '&InvisibleTimes;
            MATHML_INVOPS(1) = "APPLYFUNCTION"          '&ApplyFunction;
            MATHML_INVOPS(2) = "INVISIBLECOMMA"         '&InvisibleComma;
            MATHML_INVOPS(3) = "IT"                     '&it;
            MATHML_INVOPS(4) = "AF"                     '&af;
            MATHML_INVOPS(5) = "IC"                     '&ic;
            MATHML_LINEBREAK(0) = "AUTO"                'default
            MATHML_LINEBREAK(1) = "NEWLINE"             'start a new line and do not indent
            MATHML_LINEBREAK(2) = "INDENTINGNEWLINE"    'start a new line and do indent
            MATHML_LINEBREAK(3) = "NOBREAK"             'do not allow a linebreak here
            MATHML_LINEBREAK(4) = "GOODBREAK"           'if a linebreak is needed on the line, here is a good spot
            MATHML_LINEBREAK(5) = "BADBREAK"            'if a linebreak is needed on the line, try to avoid breaking here

            'MATHML KEYWORDS
            'Token Elements
            KEYW_MATHML(0) = "MI" ' Identifier
            KEYW_MATHML(1) = "MN" ' Number
            KEYW_MATHML(2) = "MO" ' Operator, Fence, Separator
            KEYW_MATHML(3) = "MTEXT" ' Text
            KEYW_MATHML(4) = "MSPACE" ' Space
            KEYW_MATHML(5) = "MS" ' String Literal
            'General Layout Schemata
            KEYW_MATHML(6) = "MROW" ' Horizontally group any number of subexpressions
            KEYW_MATHML(7) = "MFRAC" ' Form a fraction from 2 subexpressions
            KEYW_MATHML(8) = "MSQRT" ' Form a radical
            KEYW_MATHML(9) = "MROOT" ' Form a radical
            KEYW_MATHML(10) = "MSTYLE" ' Style Change
            KEYW_MATHML(11) = "MERROR" ' Encloses a syntaxror message from a preprocessor
            KEYW_MATHML(12) = "MPADDED" ' Adjust space around content
            KEYW_MATHML(13) = "MPHANTOM" ' Make content invisible but preserve its size
            KEYW_MATHML(14) = "MFENCED" ' Surround content with a pair of fences
            'Script and Limit Schemata
            KEYW_MATHML(15) = "MSUB" ' Attach a subscript to a base
            KEYW_MATHML(16) = "MSUP" ' Attach a superscript to a base
            KEYW_MATHML(17) = "MSUBSUP" ' Attach a subscript-superscript to a base
            KEYW_MATHML(18) = "MUNDER" ' Attach an under-script to a base
            KEYW_MATHML(19) = "MOVER" ' Attach an over-script to a base
            KEYW_MATHML(20) = "MUNDEROVER" ' Attach and under-over script to a base
            KEYW_MATHML(21) = "MMULTISCRIPTS" ' Attach prescripts and tensor indices to a base
            'Tables and Matrices
            KEYW_MATHML(22) = "MTABLE" ' Table or Matrix
            KEYW_MATHML(23) = "MTR" ' Row in a table or matrix
            KEYW_MATHML(24) = "MTD" ' One entry in a table or matrix
            KEYW_MATHML(25) = "MALIGNGROUP" ' Alignment marker
            KEYW_MATHML(26) = "MALIGNMARK" ' Alignment marker
            'Elivening Expressions
            KEYW_MATHML(27) = "MACTION" 'Bind actions to a subexpression
            'Containers
            KEYW_MATHML(28) = "CI"      'Content Identifier
            KEYW_MATHML(29) = "CN"
            KEYW_MATHML(30) = "CSYMBOL" 'Content Symbol
            'Constructors ?MathML2
            KEYW_MATHML(31) = "INTERVAL" 'denotes an interval on the real line with the values represented by its children as end points http://www.w3.org/TR/MathML2/chapter4.html#contm.interval
            KEYW_MATHML(32) = "MATRIX" 'Matrix
            KEYW_MATHML(33) = "MATRIXROW" 'Matrix row
            KEYW_MATHML(34) = "SET"
            KEYW_MATHML(35) = "LIST"
            KEYW_MATHML(36) = "VECTOR"
            KEYW_MATHML(37) = "APPLY"
            ' KEYW_MATHML(38) = ""
            KEYW_MATHML(39) = "RELN"
            KEYW_MATHML(40) = "LAMBDA"
            KEYW_MATHML(41) = "PIECEWISE"
            KEYW_MATHML(42) = "PIECE"
            KEYW_MATHML(43) = "OTHERWISE"
            'Functions: Unary Arithmetic ?MathML2
            KEYW_MATHML(44) = "FACTORIAL"
            KEYW_MATHML(45) = "MINUS"
            KEYW_MATHML(46) = "ABS"
            KEYW_MATHML(47) = "CONJUGATE"
            KEYW_MATHML(48) = "ARG"
            KEYW_MATHML(49) = "REAL"
            KEYW_MATHML(50) = "IMAGINARY"
            KEYW_MATHML(51) = "FLOOR"
            KEYW_MATHML(52) = "CEILING"
            'Functions: Unary Logic ?MathML2
            KEYW_MATHML(53) = "NOT"
            'Functions: Unary Functional ?MathML2
            KEYW_MATHML(54) = "INVERSE"
            KEYW_MATHML(55) = "IDENT"
            KEYW_MATHML(56) = "DOMAIN"
            KEYW_MATHML(57) = "CODOMAIN"
            KEYW_MATHML(58) = "IMAGE"
            'Functions: Unary Elemental Classic ?MathML2
            KEYW_MATHML(59) = "SIN"
            KEYW_MATHML(60) = "COS"
            KEYW_MATHML(61) = "TAN"
            KEYW_MATHML(62) = "SEC"
            KEYW_MATHML(63) = "CSC"
            KEYW_MATHML(64) = "COT"
            KEYW_MATHML(65) = "SINH"
            KEYW_MATHML(66) = "COSH"
            KEYW_MATHML(67) = "SECH"
            KEYW_MATHML(68) = "CSCH"
            KEYW_MATHML(69) = "COTH"
            KEYW_MATHML(70) = "ARCSIN"
            KEYW_MATHML(71) = "ARCCOS"
            KEYW_MATHML(72) = "ARCTAN"
            KEYW_MATHML(73) = "ARCCOSH"
            KEYW_MATHML(74) = "ARCCOT"
            KEYW_MATHML(75) = "ARCCOTH"
            KEYW_MATHML(76) = "ARCCSC"
            KEYW_MATHML(77) = "ARCCSCH"
            KEYW_MATHML(78) = "ARCSEC"
            KEYW_MATHML(79) = "ARCSECH"
            KEYW_MATHML(80) = "ARCSINH"
            KEYW_MATHML(81) = "ARCTANH"
            KEYW_MATHML(82) = "EXP"
            KEYW_MATHML(83) = "LN"
            KEYW_MATHML(84) = "LOG"
            'Functions: Unary Linear Algebra ?MathML2
            KEYW_MATHML(85) = "DETERMINANT"
            KEYW_MATHML(86) = "TRANSPOSE"
            'Functions: Unary Calculus and Vector Calculus ?MathML2
            KEYW_MATHML(87) = "DIVERGENCE"
            KEYW_MATHML(88) = "GRAD"
            KEYW_MATHML(89) = "CURL"
            KEYW_MATHML(90) = "LAPLACIAN"
            'Functions: Unary set-theoretic ?MathML2
            KEYW_MATHML(91) = "CARD"
            'Functions: Binary Arithmetic ?MathML2
            KEYW_MATHML(92) = "QUOTIENT"
            KEYW_MATHML(93) = "DIVIDE"
            KEYW_MATHML(94) = "MINUS"
            KEYW_MATHML(95) = "POWER"
            KEYW_MATHML(96) = "REM"
            'Functions: Binary Logical ?MathML2
            KEYW_MATHML(97) = "IMPLIES"
            KEYW_MATHML(98) = "EQUIVALENT"
            KEYW_MATHML(99) = "APPROX"
            'Functions: Binary Set Operators ?MathML2
            KEYW_MATHML(100) = "SETDIFF"

        End Sub
#End Region
#Region "FUNCTIONS 3RD PARTY"
        'Return true or false if we found a Keyword
        Function IsKeyword(ByRef Key As String) As Boolean
            Dim x As Short
            For x = 0 To UBound(KEYW_HTML)
                If KEYW_HTML(x) = UCase(Key) Then
                    IsKeyword = True : Exit For
                End If
            Next x
            For x = 0 To UBound(KEYW_MATHML)
                If KEYW_MATHML(x) = UCase(Key) Then
                    IsKeyword = True : Exit For
                End If
            Next x
            Exit Function
        End Function
        'Return True if we found an Attribute
        Function IsAttribute(ByRef Key As String) As Boolean
            Dim x As Short
            For x = 0 To UBound(ATTR_HTML)
                If ATTR_HTML(x) = UCase(Key) Then
                    IsAttribute = True : Exit For
                End If
            Next x
            For x = 0 To UBound(ATTR_MATHML)
                If ATTR_MATHML(x) = UCase(Key) Then
                    IsAttribute = True : Exit For
                End If
            Next x
            Exit Function
        End Function
        'Return true if we have Alpha Letters A-Z a-z
        Public Function isAlpha(ByRef c As String) As Boolean
            isAlpha = UCase(c) >= "A" And UCase(c) <= "Z"
        End Function
        'Return True if we find a white space
        Public Function isWhite(ByRef c As String) As Boolean
            isWhite = (c = " ") Or (c = vbTab)
        End Function
        'Return True when we only have digits
        Public Function isDigit(ByRef c As String) As Boolean
            isDigit = (c >= "0") And (c <= "9")
        End Function
        'Return True if we have a Delimiter
        Function IsDelim(ByRef c As String) As Boolean
            If InStr(DELIMITERS, c) Or c = vbCr Then IsDelim = True
        End Function
        'Return True if we have a custom character
        Function IsSpecialChar(ByRef c As String) As Boolean
            If InStr(LATIN_1_SUPLEMENT, c) Or InStr(MISC, c) Then IsSpecialChar = True
        End Function
        'Advance 1 character position
        Sub INC(Optional ByRef nMove As Short = -1)
            If (nMove <> -1) Then
                CharPos += nMove : Exit Sub
            Else : CharPos += 1 : Exit Sub
            End If
        End Sub
        'All this does is return the string name of a Token Type ID
        Function GetStrToken(ByRef iTokT As Tok_Types) As String
            Select Case iTokT
                Case Tok_Types.NONE : GetStrToken = "Nothing"
                Case Tok_Types.LSTRING : GetStrToken = "String"
                Case Tok_Types.DIGIT : GetStrToken = "Number"
                Case Tok_Types.QSTRING : GetStrToken = "Quote"
                Case Tok_Types.LPARM : GetStrToken = "Left Paranthesis"
                Case Tok_Types.RPARM : GetStrToken = "Right Paranthesis"
                Case Tok_Types.LVARIABLE : GetStrToken = "Variable"
                Case Tok_Types.COMMENT : GetStrToken = "Comment Block"
                Case Tok_Types.COMMENT_S : GetStrToken = "Comment Start"
                Case Tok_Types.COMMENT_E : GetStrToken = "Comment End"
                Case Tok_Types.KEYWORD : GetStrToken = "Keyword"
                Case Tok_Types.DEL : GetStrToken = "Delimiter"
                Case Tok_Types.EOL : GetStrToken = "Line Feed"
                Case Tok_Types.EOP : GetStrToken = "EOP"
                Case Tok_Types.LCURLY : GetStrToken = "Left Curly Bracket"
                Case Tok_Types.RCURLY : GetStrToken = "Right Curly Bracket"
                Case Tok_Types.LSQB : GetStrToken = "Left Square Bracket"
                Case Tok_Types.RSQB : GetStrToken = "Right Square Bracket"
                Case Tok_Types.ZSQB : GetStrToken = "BBC Ending"
                Case Tok_Types.LANGLEB : GetStrToken = "HTML Tag Start"
                Case Tok_Types.RANGLEB : GetStrToken = "HTML Tag End"
                Case Tok_Types.ZANGLEB : GetStrToken = "HTML Tag Ending"
                Case Tok_Types.QMARK : GetStrToken = "Question Mark"
                Case Tok_Types.COLON : GetStrToken = "Colon"
                Case Tok_Types.AMPERSAND : GetStrToken = "Ampersand"
                Case Tok_Types.MARKEDSECT : GetStrToken = "Marked Section"
                Case Tok_Types.CDATA : GetStrToken = "CDATA Start"
                Case Tok_Types.PINSTRUC_S : GetStrToken = "Processing Instruction Start"
                Case Tok_Types.PINSTRUC_E : GetStrToken = "Processing Instruction End"
                Case Tok_Types.AVALUE : GetStrToken = "Attribute Value"
                Case Tok_Types.ASET : GetStrToken = "Attribute Set"
                Case Tok_Types.ATTRIBUTE : GetStrToken = "Attribute"
                Case Tok_Types.XINCLUDE : GetStrToken = "Include"
                Case Tok_Types.XIGNORE : GetStrToken = "Ignore"
                Case Tok_Types.COLOR_ARGB : GetStrToken = "ARGB Color"
                Case Tok_Types.COLOR_RGB : GetStrToken = "RGB Color"
                Case Tok_Types.COLOR_HEX : GetStrToken = "HEX Color"
                Case Tok_Types.COLOR_WEB : GetStrToken = "WEB Color"
                Case Else : GetStrToken = "UNKNOWN"
            End Select
        End Function
#End Region
#Region "SCANNER"
        'This is the main part of the scanner. It scans the input source and builds the tokens, and assigns the types
        Sub GetToken()
            '***********************************************************************************************************************************
            '0. DECLARE
            Dim LenSource As Integer = Len(Source)
            '***********************************************************************************************************************************
            '1. CLEAR PREVIOUS
            Token = ""
            TokType = Tok_Types.NONE
            '***********************************************************************************************************************************
            '2. DID WE REACHED THE LAST CHARACTER?
            If (CharPos > LenSource) Then : TokType = Tok_Types.EOP : Exit Sub
            End If
            '***********************************************************************************************************************************
            '3. SKIP OVER WHITE-SPACES
            Do While (CharPos <= LenSource) And (isWhite(Mid(Source, CharPos, 1)))
                INC()
                If (CharPos > LenSource) Then : TokType = Tok_Types.EOP : Exit Sub
                End If
            Loop
            '***********************************************************************************************************************************
            '4. SKIP OVER LINE-BREAKS
            If Mid(Source, CharPos, 1) = vbCr Then
                INC(2)
                TokType = Tok_Types.EOL
                Exit Sub
            End If
            '***********************************************************************************************************************************
            '5. CHECK FOR UNICODE CHARACTERS
            'If IsSpecialChar(Mid(Source, CharPos, 1)) Then
            '    INC()
            '    'TODO: Make a function to convert Unicodes to Text Entities &;
            '    'Token = ""
            '    TokType = Tok_Types.LSTRING
            '    Exit Sub
            'End If
            '***********************************************************************************************************************************
            '6. CHECK FOR DELIMITERS
            If IsDelim(Mid(Source, CharPos, 1)) Then
                Token &= Mid(Source, CharPos, 1)
                INC()
                '   ****************************************************************************************************************************
                '    6.1.   LEFT PARANTHESIS (
                If (Token = "(") Then
                    TokType = Tok_Types.LPARM : Exit Sub
                    '****************************************************************************************************************************
                    '6.2.   RIGHT PARANTHESIS )
                ElseIf (Token = ")") Then
                    TokType = Tok_Types.RPARM : Exit Sub
                    '****************************************************************************************************************************
                    '6.3.   LEFT ANGLE BRACKET <
                ElseIf (Token = "<") Then
                    '    6.3.1. LEFT ANGLE BRACKET + SLASH </
                    If Mid(Source, CharPos, 1) = "/" Then
                        TokType = Tok_Types.ZANGLEB
                        'Token &= "/"
                        HTML_TAG_OPENED = True
                        INC()
                        Exit Sub
                        '6.3.2. Inside CDATA
                    ElseIf INSIDE_CDATA = True Then
                        TokType = Tok_Types.LSTRING
                        '6.3.3. LEFT ANGLE BRACKET <
                    Else
                        TokType = Tok_Types.LANGLEB
                        HTML_TAG_OPENED = True
                    End If
                    '****************************************************************************************************************************
                    '6.4. RIGHT ANGLE BRACKET >
                ElseIf (Token = ">") Then
                    '    6.4.1. Inside CDATA
                    If INSIDE_CDATA = True Then
                        TokType = Tok_Types.LSTRING
                        '6.4.2. RIGHT ANGLE BRACKET >
                    Else
                        TokType = Tok_Types.RANGLEB
                        HTML_TAG_OPENED = False
                    End If
                    '****************************************************************************************************************************
                    '6.5. EQUAL SIGN =
                ElseIf (Token = "=") Then
                    EQUAL_SIGN_TYPED = True                                     'Global Boolean
                    '    6.5.1. Inside HTML Tag
                    If HTML_TAG_OPENED = True Then : TokType = Tok_Types.ASET   'Attribute Set ID
                        '6.5.2. Inside String
                    Else : TokType = Tok_Types.LSTRING                          'String
                    End If
                    '****************************************************************************************************************************
                    '6.6. LEFT CURLY BRACKET {
                ElseIf (Token = "{") Then
                    INSIDE_CURLY = True
                    TokType = Tok_Types.LCURLY
                    Exit Sub
                    '****************************************************************************************************************************
                    '6.7. RIGHT CURLY BRACKET }
                ElseIf (Token = "}") Then
                    INSIDE_CURLY = False
                    TokType = Tok_Types.RCURLY
                    Exit Sub
                    '****************************************************************************************************************************
                    '6.8. LEFT SQUARE BRACKET [
                ElseIf (Token = "[") Then
                    TokType = Tok_Types.LSQB
                    Exit Sub
                    '****************************************************************************************************************************
                    '6.9. RIGHT SQUARE BRACKET ]
                ElseIf (Token = "]") Then
                    '****************************************************************************************************************************
                    '    6.9.1. RIGHT SQUARE BRACKET + RIGHT ANGLE BRACKET ]>
                    If Mid(Source, CharPos, 2) = "]>" Then
                        TokType = Tok_Types.RANGLEB
                        INC(2)
                        'Token = ">"
                        INSIDE_CDATA = False
                        Exit Sub
                        '6.9.2. RIGHT SQUARE BRACKET ]
                    Else : TokType = Tok_Types.RSQB : Exit Sub
                    End If
                    '****************************************************************************************************************************
                    '6.10. RIGHT SLASH /
                ElseIf (Token = "/") Then
                    '    '6.10.1. RIGHT SLASH + ASTERIX
                    If Mid(Source, CharPos, 1) = "*" Then
                        INSIDE_COMMENT = True
                        INC()
                        While Mid(Source, CharPos, 2) <> "*/"
                            'Token = Token & Mid(Source, CharPos, 1)    'THIS WILL SHOW THE COMMENT BLOCK, OTHERWISE SKIP
                            INC()
                            If (CharPos > LenSource) Then Exit Sub
                        End While
                        TokType = Tok_Types.COMMENT
                        INC(2)
                        INSIDE_COMMENT = False
                        Exit Sub
                        '6.10.2. RIGHT SLASH + RIGHT ANGLE BRACKET />
                    ElseIf Mid(Source, CharPos, 1) = ">" Then
                        TokType = Tok_Types.RANGLEB
                        INC(1)
                        'Token &= ">"
                        Exit Sub
                        '6.10.3. LEFT SQUARE BRACKET + RIGHT SLASH
                    ElseIf Mid(Source, CharPos - 2, 1) = "[" Then  'BBC End
                        TokType = Tok_Types.ZSQB
                        Exit Sub
                        '6.10.4. Default
                    Else
                        If HTML_TAG_OPENED = False Then
                            TokType = Tok_Types.LSTRING : Exit Sub
                        End If
                    End If
                    '****************************************************************************************************************************
                    ' !
                ElseIf (Token = "!") Then
                    ' !--
                    If Mid(Source, CharPos, 2) = "--" Then
                        INSIDE_COMMENT = True
                        INC(2)
                        While Mid(Source, CharPos, 3) <> "-->"
                            'Token = Token & Mid(Source, CharPos, 1)    'THIS WILL SHOW THE COMMENT BLOCK, OTHERWISE SKIP
                            INC()
                            If (CharPos > Len(Source)) Then Exit Sub
                        End While
                        TokType = Tok_Types.COMMENT
                        CharPos = CharPos + 2
                        INSIDE_COMMENT = False
                        Exit Sub
                        ' ![
                    ElseIf Mid(Source, CharPos, 1) = "[" Then
                        INC()
                        Token = ""
                        While Mid(Source, CharPos, 3) <> "]]>"
                            If Mid(Source, CharPos, 1) = "[" Then
                                INC()
                                Exit Sub
                            Else
                                Token = Token & Mid(Source, CharPos, 1)
                                If Mid(Source, CharPos, 5) = "CDATA" Then
                                    TokType = Tok_Types.CDATA
                                    INSIDE_CDATA = True
                                ElseIf Mid(Source, CharPos, 7) = "INCLUDE" Then
                                    TokType = Tok_Types.XINCLUDE
                                ElseIf Mid(Source, CharPos, 6) = "IGNORE" Then
                                    TokType = Tok_Types.XIGNORE
                                End If
                                INC()
                            End If
                            If (CharPos > Len(Source)) Then Exit Sub
                        End While
                        TokType = Tok_Types.CDATA
                        CharPos = CharPos + 2
                        Token = Right(Token, Len(Token) - 2)
                        INSIDE_CDATA = False
                    End If
                    '****************************************************************************************************************************
                    '*
                ElseIf (Token = "*") Then
                    If HTML_TAG_OPENED = False Then
                        TokType = Tok_Types.LSTRING
                        Exit Sub
                    End If
                    '****************************************************************************************************************************
                    ' ?
                ElseIf (Token = "?") Then
                    ' <?
                    If Mid(Source, CharPos - 2, 1) = "<" Then
                        ' <?/
                        If Mid(Source, CharPos, 1) = "/" Then
                            TokType = Tok_Types.PINSTRUC_E
                            INC()
                            ' <?
                        Else
                            TokType = Tok_Types.PINSTRUC_S
                        End If
                        ' ?>
                    ElseIf Mid(Source, CharPos, 1) = ">" Then
                        TokType = Tok_Types.PINSTRUC_E
                        ' ?
                    Else
                        TokType = Tok_Types.QMARK
                    End If
                    '****************************************************************************************************************************
                    ' :
                ElseIf (Token = ":") Then
                    TokType = Tok_Types.COLON
                    '****************************************************************************************************************************
                    ' &
                ElseIf (Token = "&") Then
                    If Mid(Source, CharPos, 1) = "h" And INSIDE_CURLY = True Then
                        INC()
                        Token = ""
                        While IsDelim(Mid(Source, CharPos, 1)) = False
                            Token = Token + Mid(Source, CharPos, 1)
                            INC()
                        End While
                        TokType = Tok_Types.COLOR_HEX
                    Else
                        TokType = Tok_Types.AMPERSAND
                    End If
                    '****************************************************************************************************************************
                Else
                    ' Just return Delimiter type with no rules
                    TokType = Tok_Types.DEL
                    Exit Sub
                End If
                'This part I added to ident a # variable
            ElseIf Mid(Source, CharPos, 1) = "#" Then
                INC()
                Token = "#"
                If isAlpha(Mid(Source, CharPos, 1)) Then
                    While Not IsDelim(Mid(Source, CharPos, 1))
                        Token = Token + Mid(Source, CharPos, 1)
                        INC()
                    End While
                End If
                TokType = Tok_Types.LVARIABLE
                Exit Sub
                'RGB Color
            ElseIf LCase(Mid(Source, CharPos, 3)) = "rgb" And INSIDE_CURLY Then
                INC(4)
                Token = ""
                While Not (Mid(Source, CharPos, 1)) = ")"
                    Token = Token + Mid(Source, CharPos, 1)
                    INC()
                End While
                TokType = Tok_Types.COLOR_RGB
                Token = Replace(Token, "(", "")
                INC()
                Exit Sub
                'Checks for only Alpha strings
            ElseIf isAlpha(Mid(Source, CharPos, 1)) Then
                While Not IsDelim(Mid(Source, CharPos, 1))
                    Token = Token & Mid(Source, CharPos, 1)
                    INC()
                    TokType = Tok_Types.LSTRING
                End While
                'Check if we have a keyword other wise it's a LSTRING
                If IsKeyword(Token) And HTML_TAG_OPENED = True Then
                    TokType = Tok_Types.KEYWORD
                    Exit Sub
                ElseIf IsAttribute(Token) And HTML_TAG_OPENED = True Then
                    TokType = Tok_Types.ATTRIBUTE
                    Exit Sub
                End If
                'Check for digits
            ElseIf isDigit(Mid(Source, CharPos, 1)) Then
                While Not IsDelim(Mid(Source, CharPos, 1))
                    Token = Token & Mid(Source, CharPos, 1)
                    If CharPos > Len(Source) Then Exit Sub
                    INC()
                End While
                TokType = Tok_Types.DIGIT
                Exit Sub
                'Check for quoted strings "hello world"
            ElseIf Mid(Source, CharPos, 1) = Chr(34) Then
                INC()
                While Mid(Source, CharPos, 1) <> Chr(34)
                    Token = Token & Mid(Source, CharPos, 1)
                    INC()
                    If CharPos > Len(Source) Then
                        Exit Sub
                    End If
                End While
                INC()
                If HTML_TAG_OPENED Then
                    TokType = Tok_Types.AVALUE 'Attribute Vale
                    Exit Sub
                Else
                    TokType = Tok_Types.QSTRING 'Quote
                End If
                Exit Sub
                'ERROR
            Else
                'Beep()
                'Token = "ERROR @ pos: " & CharPos & " [" & Mid(Source, CharPos, 1) & "]"
                'TokType = Tok_Types.EOP
                While Not IsDelim(Mid(Source, CharPos, 1))
                    Token = Token & Mid(Source, CharPos, 1)
                    INC()
                    TokType = Tok_Types.LSTRING
                End While
                'Check if we have a keyword otherwise it's a LSTRING
                If IsKeyword(Token) And HTML_TAG_OPENED = True Then
                    TokType = Tok_Types.KEYWORD
                    Exit Sub
                ElseIf IsAttribute(Token) And HTML_TAG_OPENED = True Then
                    TokType = Tok_Types.ATTRIBUTE
                    Exit Sub
                End If
            End If
        End Sub
#End Region
    End Module
End Namespace