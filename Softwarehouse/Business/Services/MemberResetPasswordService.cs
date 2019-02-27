﻿using Business.Interfaces;
using Business.Repositories;
using ObjectCollection.RepositoryConditions;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using Security;
using System;
using System.Linq;

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
            if (string.IsNullOrWhiteSpace(_Resource.MemberAccount))
            {
                this.StateMessage = "請傳入MemberAccount";
                this.State = false;
                return false;
            }
            if (string.IsNullOrWhiteSpace(_Resource.NewPassword))
            {
                this.StateMessage = "請傳入NewPassword";
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
            MembersRepository membersRepo = new MembersRepository();
            MemberResetPasswordServiceResult result = new MemberResetPasswordServiceResult();
            try
            {
                var member = membersRepo.Read(new MembersRepoCondition
                {
                    Account = _Resource.MemberAccount
                }).FirstOrDefault();
                RandomSalt randomSalt = new RandomSalt();
                var salt = randomSalt.GetRandomSaltString();
                membersRepo.Update(new MembersRepoCondition
                {
                    Id= member.Id,
                    Password = Encrypt.EncryptSHA512(_Resource.NewPassword, salt),
                    SaltString = salt
                });
                if (membersRepo.State)
                {
                    result.Result = repo.DeleteAll(new MemberResetPasswordRepoCondition
                    {
                        MemberAccount = _Resource.MemberAccount
                    });
                }
                else
                {
                    throw new Exception("重設密碼失敗");
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
