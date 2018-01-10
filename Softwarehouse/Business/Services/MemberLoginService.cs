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
    public class MemberLoginService : IService<MemberLoginServiceCondition, MemberLoginServiceResult>
    {
        /// <summary>
        /// 商業邏輯傳遞參數
        /// </summary>
        private MemberLoginServiceCondition _Resource;
        public MemberLoginServiceCondition Resources
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

        public bool Login(object account, object password)
        {
            throw new NotImplementedException();
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
            if(_Resource == null)
            {
                this.StateMessage = "請傳入參數";
                this.State = false;
                return false;
            }
            if (string.IsNullOrWhiteSpace(_Resource.Account))
            {
                this.StateMessage = "請傳入帳號";
                this.State = false;
                return false;
            }
            if (string.IsNullOrWhiteSpace(_Resource.Password))
            {
                this.StateMessage = "請傳入密碼";
                this.State = false;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 執行商業邏輯
        /// </summary>
        /// <returns></returns>
        public MemberLoginServiceResult Work()
        {
            MembersRepository repo = new MembersRepository();
            MemberLoginServiceResult result = new MemberLoginServiceResult();
            try
            {
                Encrypt encrypt = new Encrypt();
                var member = repo.Read(new MembersRepoCondition
                {
                    Account = _Resource.Account
                }).FirstOrDefault();
                if(member == null)
                {
                    result.Result = false;
                    result.ErrorMessage = "查無此帳號";
                }
                else
                {
                    if(member.Password != encrypt.EncryptSHA512(_Resource.Password, member.SaltString))
                    {
                        result.Result = false;
                        result.ErrorMessage = "密碼錯誤";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = "登入失敗";
            }
            return result;
        }
    }
}