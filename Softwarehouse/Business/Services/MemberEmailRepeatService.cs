using Business.Interfaces;
using Business.Repositories;
using ObjectCollection.RepositoryConditions;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using System;
using System.Linq;

namespace Business.Services
{
    public class MemberEmailRepeatService : IService<MemberEmailRepeatServiceCondition, MemberEmailRepeatServiceResult>
    {
        /// <summary>
        /// 商業邏輯傳遞參數
        /// </summary>
        private MemberEmailRepeatServiceCondition _Resource;
        public MemberEmailRepeatServiceCondition Resources
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
        public MemberEmailRepeatServiceResult Work()
        {
            MembersRepository repo = new MembersRepository();
            MemberEmailRepeatServiceResult result = new MemberEmailRepeatServiceResult();
            try
            {
                result.IsRepeat = repo.Read(new MembersRepoCondition
                {
                    Email = _Resource.Email
                }).Any();
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
