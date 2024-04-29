using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace implement.Core.Helpers
{
    public static class SecurityHelpers
    {
        public static void InsertToLog(bool insertLog, string logText, string type = "Error", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            try
            {
                if (insertLog)
                    switch (type)
                    {
                        case "Error":
                            Log.Error(logText, lineNumber + " at line " + lineNumber + " (" + caller + ")" + "\n");
                            break;
                        case "Info":
                            Log.Information(logText, lineNumber + " at line " + lineNumber + " (" + caller + ")" + "\n");
                            break;
                        default:
                            break;
                    }
            }
            catch (Exception)
            {

            }
        }
    }
}
