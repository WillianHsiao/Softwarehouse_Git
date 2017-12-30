using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollection.Interfaces
{
    public interface IServiceResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        bool Result { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        string ErrorMessage { get; set; }
    }
}
