WebLEXICON v0.1
----------------
Known syntaxes:
	DOM/DOM2
	HTML/XHTML
	SGML
	MATHML
	JavaScript
	XML
	--and any similar syntax languages--
Future support:
	DocBook
	TeX / LaTeX
	
Global info (applies to all or most of the supported syntaxes):
	1. Empty closing tags ("</","<?/") can be used, they will close last opened tag. 
	   Empty opening tags ("<","<?") are not recommended right now.
	2. < > are ignored in some cases:
	    a) inside <!-- --> comment style, they will act as any other character, but inside /* */ they will be skipped.
	    b) Inside CDATA Marked Sections
			CDATA Marked sections start like this: "<![CDATA["  - ID1+ID31 -
	3. Closed Start Tags allowed. These are specific to SGML, and they look like this: <tag1<tag2>
	   You can notice that the first tag is not closed (<tag1><tag2> is correct HTML/XHTML). In this case, the processor
	   will check each time an "<" is opened that there is no other "<" opened. Otherwise, it will know that the last tag
	   wasn't closed, and it will act like he found an ">"
	   NOTE: Closed Smart Tags apply also to "<a></a>" syntax, but no "<" should be contained in the syntax:
						correct: <a href="">Google Link</a><next-tag>....
						correct: <a href="">Google Link<next-tag>..
					  incorrect: <a href="">Google<Link<next-tag>..
					   In last case, "Google<Link" will be interpretted this way:
								"Google" = link description (GOOD!)
								"<" = new tag opened (BAD!)
								"Link" = keyword (BAD!)
	4. NET Tags are not yet supported.
		A NET Tag looks like this: <name/.../
		The HTML equivalent will look like: <name>...</name>
	
SGML Processing Instructions
-----------------------------
EXAMPLES:
	<?>
	<?style tt = font courier>
	<?page break>
	<?experiment> ... <?/experiment>
NOTES: 1. "<" will define a HTML Tag Start, and the "?" will let us know its a processing instruction
	   2.The code will allow know that "?" is a processing instruction only if before him its an "<",
		 which means that "< ?" will not be recognized as a processing instruction. To avoid this, the
		 HTML processor should check if "<" is ID1, "?" is ID 32 or 20.
	     An ending Processing Instruction Tag will end when "/" is attached after "?"
			ie: <?> - opening tag
				<?/> - ending tag
	   3. You dont need to use quoted attribute values as long as you dont use any known keyword.
		  For example: <?a lang=en> is VALID
		               <?a lang=html> is INVALID, because HTML is a keyword and will misslead the processor.
LEXICON: 
		1. <?a lang="en">
			ID 1 - HTML Tag Start
			ID 32 - Processing Instruction Start
			ID 90 - String (keyword)
			ID 90* - String (attribute)
			ID 35 - Delimiter (=)
			ID 34 - Quote
			ID 2 - HTML Tag End		
		
HTML / XHTML
-------------
You dont have to double-check your XHTML syntax, because it will be interpreted as HTML otherwise.
For example: <br> is a valid HTML code, while <br /> is a valid XHTML code. If your document is an XHTML
type, <br> will be interpreted as <br />, so you dont have to worry.

<!-- comment  here --> is a comment, valid in all document types (even CSS !)

CSS
---

/* comment here */ is a comment, valid in all document types
		


