using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Types.Common
{
    public class TypeWorkflowScheme
    {
        public TypeWorkflowScheme()
        {

        }

        /// <summary>
        /// </summary>
        /// <param name="SchemePosId">현처리코드</param>
        public string SchemePosId
        {
            get;
            set;
        }
        /// <param name="ReportToPosId">다음처리코드</param>
        public string ReportToPosId
        {
            get;
            set;
        }
        /// <param name="HierachyStatusCode">상태코드(1:Command, 2:Auto)</param>
        public int HierachyStatusCode
        {
            get;
            set;
        }
        /// <param name="HierachyDirectionCode">진행방향코드(1:Direct, 2:Reverse)</param>
        public int HierachyDirectionCode
        {
            get;
            set;
        }
        /// <param name="HierachyCommandTypeCode">명령어타입(1:true/false, 2:Accept/Suspend/Denial)</param>
        public int HierachyCommandTypeCode
        {
            get;
            set;
        }
    }
}
