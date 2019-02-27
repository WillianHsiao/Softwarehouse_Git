using Business.Interfaces;
using Business.Repositories;
using ObjectCollection.RepositoryConditions;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using Security;
using System;
using System.Linq;

namespace Business.Services
{
    public class MemberCheckResetPasswordUrlService : IService<MemberCheckResetPasswordUrlServiceCondition, MemberCheckResetPasswordUrlServiceResult>
    {
        /// <summary>
        /// 商業邏輯傳遞參數
        /// </summary>
        private MemberCheckResetPasswordUrlServiceCondition _Resource;
        public MemberCheckResetPasswordUrlServiceCondition Resources
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
            if (string.IsNullOrWhiteSpace(_Resource.MemberAccount))
            {
                this.StateMessage = "請傳入MemberAccount";
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
        public MemberCheckResetPasswordUrlServiceResult Work()
        {
            MemberResetPasswordRepository repo = new MemberResetPasswordRepository();
            MemberCheckResetPasswordUrlServiceResult result = new MemberCheckResetPasswordUrlServiceResult();
            try
            {
                var MemberResetPasswords = repo.Read(new MemberResetPasswordRepoCondition
                {
                    MemberAccount = _Resource.MemberAccount
                });
                bool UniqueKeyEffective = false;
                MemberResetPasswords.ToList().ForEach(p =>
                {
                    if(Encrypt.EncryptSHA512(Encrypt.AESDecrypt(_Resource.UniqueKey), p.SaltString) == p.UniqueKey)
                    {
                        UniqueKeyEffective = true;
                    }
                });
                if (UniqueKeyEffective)
                {
                    result.Result = true;
                }
                else
                {
                    throw new Exception("參數驗證錯誤");
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
