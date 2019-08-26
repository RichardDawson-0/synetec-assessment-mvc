using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2
{
    public static class EncrptionHelper
    {
        // TODO impliment proper Encryption
        public static string Encrypt(this String str)
        {
            return str + "Encrypted";
        }
        // TODO impliment proper Encryption
        public static string Decrypt(this String str)
        {
            return str.Replace("Encrypted", "");
        }
    }
}