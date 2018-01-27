using Business.Interfaces;
using Business.Repositories;
using Common.Enums;
using Common.StringDefine;
using ObjectCollection.RepositoryConditions;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using Security;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

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
            MemberLoginServiceResult result = new MemberLoginServiceResult
            {
                ErrorMessage = "",
                LoginResult = LoginResultEnum.LoginSuccess,
                Result = true
            };
            try
            {
                // 登入時清空所有 Session 資料
                HttpContext.Current.Session.RemoveAll();

                Encrypt encrypt = new Encrypt();
                var member = repo.Read(new MembersRepoCondition
                {
                    Account = _Resource.Account
                }).FirstOrDefault();
                if(member == null)
                {
                    result.Result = false;
                    result.LoginResult = LoginResultEnum.AccountNotFound;
                    result.ErrorMessage = "";
                }
                else
                {
                    if(member.Password != encrypt.EncryptSHA512(_Resource.Password, member.SaltString))
                    {
                        result.Result = false;
                        result.LoginResult = LoginResultEnum.PasswordError;
                        result.ErrorMessage = "";
                    }
                    else
                    {
                        bool isPersistent = false;

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                          1,
                          member.Account,
                          DateTime.Now,
                          DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                          isPersistent,
                          member.Id.ToString(),
                          FormsAuthentication.FormsCookiePath);

                        string encTicket = FormsAuthentication.Encrypt(ticket);

                        HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                        HttpContext.Current.Session[StringDefine.KEY_CURRENT_USER] = member.Id.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                result.Result = false;
                result.LoginResult = LoginResultEnum.UnKnowFail;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}