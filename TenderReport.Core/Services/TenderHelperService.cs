using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TenderReport.Core.Services
{
    public static class TenderHelperService
    {
        public static string ToTitleCase(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToTitleCase(name.ToLower());
        }
    }
}
