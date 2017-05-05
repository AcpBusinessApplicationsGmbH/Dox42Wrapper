using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dox42;

namespace ACP.Framework.Dox42Wrapper
{
   public class ReturnOutputStrategy : OutputStrategy
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
        public ReturnOutputStrategy()
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
