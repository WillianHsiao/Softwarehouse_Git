using Business.Interfaces;
using Business.Repositories;
using ObjectCollection.RepositoryConditions;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MemberResetPasswordService : IService<MemberResetPasswordServiceCondition, MemberResetPasswordServiceResult>
    {
        /// <summary>
        /// 商業邏輯傳遞參數
        /// </summary>
        private MemberResetPasswordServiceCondition _Resource;
        public MemberResetPasswordServiceCondition Resources
        {
            get { return _Resource; }
            set { _Resource = value; }
        }

        /// <summary>
        /// 執行狀態
        /// </summary>
        public bool State
        {
            get;
            set;
        }

        /// <summary>
        /// 執行狀態訊息
        /// </summary>
        public string StateMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 檢查傳入參數
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            if (_Resource == null)
            {
                this.StateMessage = "請傳入參數";
                this.State = false;
                return false;
            }
            if (string.IsNullOrWhiteSpace(_Resource.UniqueKey))
            {
                this.StateMessage = "請傳入UniqueKey";
                this.State = false;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 執行商業邏輯
        /// </summary>
        /// <returns></returns>
        public MemberResetPasswordServiceResult Work()
        {
            MemberResetPasswordRepository repo = new MemberResetPasswordRepository();
            MemberResetPasswordServiceResult result = new MemberResetPasswordServiceResult();
            try
            {
                if(repo.Read(new MemberResetPasswordRepoCondition
                {
                    UniqueKey = _Resource.UniqueKey
                }).Any())
                {

                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
