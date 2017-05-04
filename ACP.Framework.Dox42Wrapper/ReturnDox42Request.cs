using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dox42;

namespace ACP.Dox42Wrapper
{
   public class ReturnDox42Request :OutputStrategy
    {
        private List<KeyValue> _returnActionParams;
        public enum Dox42ReturnFormat
        {
            doc,
            xls,
            docx,
            xlsx,
            pdf
        }
        public ReturnDox42Request()
        {
            _returnActionParams = new List<KeyValue>();
        }

        public Dox42ReturnFormat Format
        {
            set
            {
                _returnActionParams.Add(new KeyValue()
                {
                    ParamName = "Format",
                    Value = value.ToString()
                });
            }
        }
        public String Mode
        {
            set
            {
                _returnActionParams.Add(new KeyValue()
                {
                    ParamName = "Mode",
                    Value = value
                });
            }
        }


        public override void FillOutputRequestParmaeter(Dox42.GeneratorServiceMsg serviceMsg)
        {
        

            var postGenActions = new List<PostGenAction>
            {
                new PostGenAction()
                {
                    ActionName = Dox42Request.Dox42OutputAction.ReturnAction.ToString(),
                    Params = _returnActionParams.ToArray()
                }
            };

           
            serviceMsg.PostGenActions = postGenActions.ToArray();

        }
    }
}
