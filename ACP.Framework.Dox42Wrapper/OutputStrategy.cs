using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACP.Dox42Wrapper
{
    public abstract class OutputStrategy
    {

        public abstract void FillOutputRequestParmaeter(Dox42.GeneratorServiceMsg serviceMsg);
    }
}
