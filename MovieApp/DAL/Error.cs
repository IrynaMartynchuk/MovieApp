using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MovieApp.DAL
{
    public class Error
    {
        public static void logError(string method, Exception e)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\\DAL\error_log.txt"), true);
                streamWriter.WriteLine(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + 
                    " " + DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==>"+ ": "
                    + method + " ==> " + "==>" + e.Message + (e.InnerException == null ? "" : ("==>" + e.InnerException.Message)) + "<br/>");
                streamWriter.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
