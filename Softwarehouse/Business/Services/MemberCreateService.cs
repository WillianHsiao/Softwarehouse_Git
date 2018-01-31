using Business.Interfaces;
using Business.Models.SoftwarehouseDB;
using Business.Repositories;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using Security;
using System;

namespace Business.Services
{
    public class MemberCreateService : IService<MemberCreateServiceCondition, CreateMemberServiceResult>
    {
        /// <summary>
        /// 商業邏輯傳遞參數
        /// </summary>
        private MemberCreateServiceCondition _Resource;
        public MemberCreateServiceCondition Resources
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
            if (string.IsNullOrWhiteSpace(_Resource.Email))
            {
                this.StateMessage = "請傳入Email";
                this.State = false;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 執行商業邏輯
        /// </summary>
        /// <returns></returns>
        public CreateMemberServiceResult Work()
        {
            MembersRepository repo = new MembersRepository();
            CreateMemberServiceResult result = new CreateMemberServiceResult();
            try
            {
                Encrypt encrypt = new Encrypt();
                RandomSalt randomSalt = new RandomSalt();
                var salt = randomSalt.GetRandomSaltString();
                repo.Create(new Members
                {
                    Account = _Resource.Account,
                    Password = encrypt.EncryptSHA512(_Resource.Password, salt),
                    Name = _Resource.Name,
                    Email = _Resource.Email,
                    SaltString = salt
                });
                result.Result = true;
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
