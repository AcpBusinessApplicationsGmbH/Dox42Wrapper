using Dox42;

namespace ACP.Framework.Dox42Wrapper
{
    public interface IDox42SoapService
    {
        GeneratorServiceResponse GenerateDocumentAsync(GeneratorServiceMsg serviceMessage);
        GeneratorServiceResponse GenerateSpreadSheetAsync(GeneratorServiceMsg serviceMessage);
    }
}