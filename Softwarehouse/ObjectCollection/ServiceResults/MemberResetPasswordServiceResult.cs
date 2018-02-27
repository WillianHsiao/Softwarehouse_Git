using ObjectCollection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollection.ServiceResults
{
    /// <summary>
    /// 會員重設密碼結果
    /// </summary>
    public class MemberResetPasswordServiceResult : IServiceResult
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
