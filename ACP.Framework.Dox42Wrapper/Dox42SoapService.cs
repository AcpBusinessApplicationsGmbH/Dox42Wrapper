using Dox42;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace ACP.Framework.Dox42Wrapper
{
    public class Dox42SoapService : IDox42SoapService
    {
        private Dox42.Dox42ServiceSoapClient _client;

        public Dox42SoapService(string _dox42Uri)
        {
            Binding binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            EndpointAddress epAdress = new EndpointAddress(_dox42Uri);
            _client = new Dox42.Dox42ServiceSoapClient(binding, epAdress);
        }

        public GeneratorServiceResponse GenerateDocumentAsync(GeneratorServiceMsg serviceMessage)
        {
            return _client.GenerateDocumentAsync(serviceMessage).Result;
        }

        public GeneratorServiceResponse GenerateSpreadSheetAsync(GeneratorServiceMsg serviceMessage)
        {
            return _client.GenerateSpreadSheetAsync(serviceMessage).Result;

        }
    }
}
