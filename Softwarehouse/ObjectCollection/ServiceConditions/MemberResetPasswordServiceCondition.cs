using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollection.ServiceConditions
{
    public class MemberResetPasswordServiceCondition
    {
        public string MemberAccount { get; set; }
        public string NewPassword { get; set; }
    }
}
