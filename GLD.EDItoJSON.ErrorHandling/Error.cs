using System;
using System.Collections.Generic;

namespace GLD.EDItoJSON.ErrorHandling
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

        public static void NewError(string errorText)
        {
            Log.Add(errorText);
        }
       /// <summary>
       /// if validation failed, add a new error. Do not throw an exception.
       /// </summary>
       /// <param name="validateFunc"></param>
       /// <param name="errorText"></param>
        public static void Validate(Func<bool> validateFunc ,string errorText)
        {
           if (!validateFunc()) NewError(errorText);
        }
    }
}
