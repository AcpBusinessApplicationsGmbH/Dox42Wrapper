# Dox42Wrapper

## Sample
```cs
var server = new Dox42Server("http://sviefastboxtsk1:4242/Dox42Service.asmx");

var outputStrategy = new ReturnOutputStrategy();
outputStrategy.Format = ReturnOutputStrategy.Dox42ReturnFormat.docx;
var request = new Dox42Request(outputStrategy, Dox42Request.Dox42Operation.GenerateDocument);
request.DocTemplate = @"c:\templatepath\document.docx";
request.AddInputParameters("parameter1", "Testparameter");
var response = server.ExecuteReport(request);
```