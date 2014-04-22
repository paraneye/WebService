using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Element.Shared.Common
{
    
    public class SigmaResultType
    {
        public string JsonDataSet;
        public bool IsSuccessful;
        public int AffectedRow; // DataSet Count
        public string ErrorCode;
        public string ErrorMessage;
        public int ScalarValue; // Total Count
        public string StringValue; // Multi
    }

}
