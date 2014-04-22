using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Types.Common
{
    public class TypeTransition
    {
        public TypeTransition()
        {

        }

        /// <summary>
        /// Row는 0부터 시작
        /// </summary>
        public int Row { get; set; }
        public int Role { get; set; }
        public string UserId { get; set; }
    }
}
