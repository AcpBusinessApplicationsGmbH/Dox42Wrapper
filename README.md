# Dox42Wrapper

## Sample
```cs

//Create the client
var server = new Dox42Server(new Dox42SoapService("http://servername:4242/Dox42Service.asmx"));

//Choose output strategy. In this case it is a Dox42 return action to receive a docx
var outputStrategy = new ReturnOutputStrategy();
outputStrategy.Format = ReturnOutputStrategy.Dox42ReturnFormat.docx;

//Prepare and setup the request with the template and add the needed params
var request = new Dox42Request(outputStrategy, Dox42Request.Dox42Operation.GenerateDocument);
request.DocTemplate = @"c:\templatepath\document.docx";
request.AddInputParameters("parameter1", "Testparameter");

//finaly fire the request
var response = server.ExecuteReport(request);

```
