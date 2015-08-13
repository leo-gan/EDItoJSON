using System;
using System.Collections.Generic;

namespace GLD.EDItoJSON.ErrorHandling
{
    /// <summary>
    /// It consolidates the parsing errors.
    /// </summary>
    public class Errors
    {
        public  List<string> Logs = new List<string>();

        /// <summary>
        /// Outputs composed Logs.
        /// </summary>
        public  void Report()
        {
            if (Logs.Count == 0) return;

            Console.WriteLine("Errors:");
            foreach (var log in Logs)
                Console.WriteLine("    " + log);
            //Console.WriteLine("Press Enter to finish.");
            //Console.ReadLine();
        }

        public  void NewError(string errorText)
        {
            Logs.Add(errorText);
        }
       /// <summary>
       /// if validation failed, add a new error. Do not throw an exception.
       /// </summary>
       /// <param name="validateFunc"></param>
       /// <param name="errorText"></param>
        public  bool Assert(Func<bool> validateFunc ,string errorText)
       {
           var result = validateFunc();
           if (!result) NewError(errorText);
           return result;
       }
    }
}
