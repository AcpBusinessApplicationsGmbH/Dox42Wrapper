
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ACP.Framework.Dox42Wrapper
{
    /// <summary>
    /// handle dox42 calls
    /// </summary>
    public class Dox42Server
    {
        private string _dox42Uri;

        /// <summary>
        /// Initialize a new Dox42Server
        /// </summary>
        public Dox42Server(string dox42Uri)
        {
            if (dox42Uri == null)
                throw new ArgumentNullException(nameof(dox42Uri));

            this._dox42Uri = dox42Uri;
        }

        /// <summary>
        /// executes the report
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Dox42Response ExecuteReport(Dox42Request request)
        {

            Dox42Response response = new Dox42Response();
            response.Request = request;

            try
            {
                Binding binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                EndpointAddress epAdress = new EndpointAddress(_dox42Uri);
                Dox42.Dox42ServiceSoapClient client = new Dox42.Dox42ServiceSoapClient(binding, epAdress);

                var serviceMessage = new Dox42.GeneratorServiceMsg();

                request.FillRequestParameters(serviceMessage);

                Dox42.GeneratorServiceResponse serviceResponse = null;
                if (request.Operation == Dox42Request.Dox42Operation.GenerateDocument)
                {
                    serviceResponse = client.GenerateDocumentAsync(serviceMessage).Result;
                }
                else
                {
                    serviceResponse = client.GenerateSpreadSheetAsync(serviceMessage).Result;
                }

                if (serviceResponse != null && serviceResponse.ResultMessage == "OK")
                {
                    response.Success = true;
                    response.Message = "Report successfully created!";
                    response.Filename = Path.GetFileNameWithoutExtension(request.DocTemplate);
                }
                else
                {
                    response.Success = false;
                    response.Message = serviceResponse.ResultMessage;
                }
            }
            catch (Exception e)
            {
                response.Message = "Error while generating the File: " + e.ToString();
                response.Success = false;
            }

            return response;
        }
    }
}
