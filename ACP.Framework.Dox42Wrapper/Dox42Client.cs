
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
    public class Dox42Client
    {
        private IDox42SoapService _soapSvc;

        /// <summary>
        /// Initialize a new Dox42Server
        /// </summary>
        public Dox42Client(IDox42SoapService dox42SoapSvc)
        {
            if (dox42SoapSvc == null)
                throw new ArgumentNullException(nameof(dox42SoapSvc));

            _soapSvc = dox42SoapSvc;
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

                var serviceMessage = new Dox42.GeneratorServiceMsg();

                request.FillRequestParameters(serviceMessage);

                Dox42.GeneratorServiceResponse serviceResponse = null;
                if (request.Operation == Dox42Request.Dox42Operation.GenerateDocument)
                {
                    serviceResponse = _soapSvc.GenerateDocumentAsync(serviceMessage);
                }
                else
                {
                    serviceResponse = _soapSvc.GenerateSpreadSheetAsync(serviceMessage);
                }

                if (serviceResponse != null && serviceResponse.ResultMessage == "OK")
                {
                    response.Success = true;
                    response.Message = "Report successfully created!";
                    response.Filename = Path.GetFileNameWithoutExtension(request.DocTemplate);
                    response.File = serviceResponse.GeneratedDocs[0].Bytes;
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
