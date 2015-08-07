using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLD.EDItoJSON.Parser
{
    /// <summary>
    /// It consolidates the parsing errors.
    /// </summary>
    public static class Errors
    {
        public static List<string> Log = new List<string>();

        /// <summary>
        /// Outputs composed Log.
        /// </summary>
        public static void Report() {}
    }
}
