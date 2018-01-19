﻿using Business.Interfaces;
using Business.Repositories;
using ObjectCollection.RepositoryConditions;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using System;
using System.Linq;

namespace Business.Services
{
    public class MemberAccountRepeatService : IService<MemberAccountRepeatServiceCondition, MemberAccountRepeatServiceResult>
    {
        /// <summary>
        /// 商業邏輯傳遞參數
        /// </summary>
        private MemberAccountRepeatServiceCondition _Resource;
        public MemberAccountRepeatServiceCondition Resources
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
            return true;
        }

        /// <summary>
        /// 執行商業邏輯
        /// </summary>
        /// <returns></returns>
        public MemberAccountRepeatServiceResult Work()
        {
            MembersRepository repo = new MembersRepository();
            MemberAccountRepeatServiceResult result = new MemberAccountRepeatServiceResult();
            try
            {
                result.IsRepeat = repo.Read(new MembersRepoCondition
                {
                    Account = _Resource.Account
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
