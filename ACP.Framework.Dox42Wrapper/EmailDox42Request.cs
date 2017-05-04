using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dox42Wrapper;

namespace ACP.Dox42Wrapper
{
    public class EmailDox42Request :OutputStrategy
    {
        private List<Dox42.KeyValue> _returnActionParams;
        public enum Dox42EmailMode
        {
            TxtEMail,
            HtmlEMail,
            Attachment
        }
        public EmailDox42Request()
        {
            _returnActionParams = new List<Dox42.KeyValue>();
        }
        public Dox42EmailMode Mode
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "Mode",
                    Value = value.ToString()
                });
            }
        }

        public String FileName
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "FileName",
                    Value = value
                });
            }
        }
        public String Receiver
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "Receiver",
                    Value = value
                });
            }
        }
        public String ReceiverCC
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "ReceiverCC",
                    Value = value
                });
            }
        }
        public String ReceiverBCC
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "ReceiverBCC",
                    Value = value
                });
            }
        }
        public String Sender
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "Sender",
                    Value = value
                });
            }
        }
        public String Header
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "Header",
                    Value = value
                });
            }
        }
        public String HtmlBody
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "HtmlBody",
                    Value = value
                });
            }
        }
        public String MailServer
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "MailServer",
                    Value = value
                });
            }
        }
        public String Body
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "Body",
                    Value = value
                });
            }
        }
        public String MailServerPort
        {
            set
            {
                _returnActionParams.Add(new Dox42.KeyValue()
                {
                    ParamName = "MailServerPort",
                    Value = value
                });
            }
        }
       
      


        public override void FillOutputRequestParmaeter(Dox42.GeneratorServiceMsg serviceMsg)
        {
          
            var postGenActions = new List<Dox42.PostGenAction>
            {
                new Dox42.PostGenAction()
                {
                    ActionName = Dox42Request.Dox42OutputAction.EmailAction.ToString(),
                    Params = _returnActionParams.ToArray()
                }
            };


            serviceMsg.PostGenActions = postGenActions.ToArray();

        }


    }
}
