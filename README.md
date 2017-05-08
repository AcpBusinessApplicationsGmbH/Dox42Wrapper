# Dox42Wrapper
Dox42Wrapper is a simple library for C# to abstract away the SOAP service of *dox42 Server*.
It is compiled with .NET Standard 1.2 and can be used with .NET Core >= 1.0 and .NET Framework >= 4.5.1 and so on.

dox42 itself is a awesome reportgenarator which allows you to design your reports easily in Microsoft Word or Excel. The best on it is, that you can combine many datasources like SQL Server, XML, Webservices, ...
More infos about can be found at: http://www.dox42.com

## Sample
```cs

//Create the client
var client = new Dox42Client(new Dox42SoapService("http://servername:4242/Dox42Service.asmx"));

//Choose output strategy. In this case it is a Dox42 return action to receive a docx
var outputStrategy = new ReturnOutputStrategy();
outputStrategy.Format = ReturnOutputStrategy.Dox42ReturnFormat.docx;

//Prepare and setup the request with the template and add the needed params
var request = new Dox42Request(outputStrategy, Dox42Request.Dox42Operation.GenerateDocument);
request.DocTemplate = @"c:\templatepath\document.docx";
request.AddInputParameters("parameter1", "Testparameter");

//finaly fire the request
var response = client.ExecuteReport(request);

```
