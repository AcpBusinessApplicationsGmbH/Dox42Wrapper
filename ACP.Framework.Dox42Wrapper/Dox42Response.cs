using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACP.Framework.Dox42Wrapper
{
    /// <summary>
    /// A responseklasse. The object contains all necessary infos about the dox42 response
    /// </summary>
    public class Dox42Response
    {
        /// <summary>
        /// The filename
        /// </summary>
        public String Filename { get; set; }

        /// <summary>
        /// the binary file itself
        /// </summary>
        public byte[] File { get; set; }

        private bool success = false;
        /// <summary>
        /// inidicates if everything is fine
        /// </summary>
        public bool Success { get { return success; } set { success = value; } }

        /// <summary>
        /// The original request
        /// </summary>
        public Dox42Request Request { get; set; }

        /// <summary>
        /// For example the error message when something went wrong
        /// </summary>
        public string Message { get; set; }
    }
}
