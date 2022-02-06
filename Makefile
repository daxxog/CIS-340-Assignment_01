SHELL := /bin/bash


.PHONY: exe
exe:
	csc Invoice.cs InvoiceTest.cs


.PHONY: output
output: exe
	mono InvoiceTest.exe | tee InvoiceTestOutput.txt


.PHONY: test
test: output
	@diff <(cat InvoiceTest.cs | \
			grep "//- " | \
			awk '{split($$0,a,"//- ");print a[2]}') \
		<(cat InvoiceTestOutput.txt) \
	;


.PHONY: help
help:
	@printf "available targets -->\n\n"
	@cat Makefile | grep ".PHONY" | grep -v ".PHONY: _" | sed 's/.PHONY: //g'

