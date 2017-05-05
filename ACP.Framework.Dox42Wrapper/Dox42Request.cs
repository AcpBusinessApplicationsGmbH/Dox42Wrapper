using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACP.Framework.Dox42Wrapper
{
    public class Dox42Request
    {
        private OutputStrategy _strategy;
        public enum Dox42Operation
        {
            GenerateDocument,
            GenerateSpreadSheet
        }
        public enum Dox42OutputAction
        {
            ReturnAction,
            EmailAction
        }

        public String DocTemplate { get; set; }
        public String DataMap { get; set; }
        public Dox42Operation Operation { get; set; }
        private List<Dox42.KeyValue> _inputParams = new List<Dox42.KeyValue>();


        public Dox42Request(OutputStrategy strategy, Dox42Operation operation)
        {
            _strategy = strategy;
            Operation = operation;


        }

        public void AddInputParameters(string key, string value)
        {
            Dox42.KeyValue kv = new Dox42.KeyValue
            {
                ParamName = key,
                Value = value
            };
            _inputParams.Add(kv);
        }

        public void FillRequestParameters(Dox42.GeneratorServiceMsg serviceMsg)
        {
            serviceMsg.InputParams = _inputParams.ToArray();
            if (Operation == Dox42Operation.GenerateDocument)
            {
                if (String.IsNullOrWhiteSpace(DocTemplate))
                    throw new ArgumentException("No templatePath in request!");
                serviceMsg.DocTemplate = DocTemplate;
            }
            else if (Operation == Dox42Operation.GenerateSpreadSheet)
            {
                if (String.IsNullOrWhiteSpace(DataMap))
                    throw new ArgumentException("No datamapPath in request!");
                serviceMsg.DataMap = DataMap;
            }
            else
            {
                throw new NotImplementedException("The operation " + Operation.ToString() + " is not implemented!");
            }

            _strategy.FillOutputRequestParmaeter(serviceMsg);
        }
    }

}

