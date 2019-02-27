using Business.Interfaces;
using Business.Models.SoftwarehouseDB;
using Business.Repositories;
using ObjectCollection.RepositoryConditions;
using ObjectCollection.ServiceConditions;
using ObjectCollection.ServiceResults;
using Security;
using System;
using System.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Common.StringDefine;

namespace Business.Services
{
    public class MemberSendResetPasswordEmailService : IAsyncService<MemberSendResetPasswordEmailServiceCondition, MemberSendResetPasswordEmailServiceResult>
    {
        /// <summary>
        /// 商業邏輯傳遞參數
        /// </summary>
        private MemberSendResetPasswordEmailServiceCondition _Resource;
        public MemberSendResetPasswordEmailServiceCondition Resources
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
        public async Task<MemberSendResetPasswordEmailServiceResult> Work()
        {
            MemberResetPasswordRepository repo = new MemberResetPasswordRepository();
            MembersRepository MemberRepo = new MembersRepository();
            MemberSendResetPasswordEmailServiceResult result = new MemberSendResetPasswordEmailServiceResult();
            try
            {
                RandomSalt randomSalt = new RandomSalt();
                var salt = randomSalt.GetRandomSaltString();
                Members Member = MemberRepo.Read(new MembersRepoCondition
                {
                    Email = _Resource.Email
                }).FirstOrDefault();
                string UniqueKey = Guid.NewGuid().ToString();
                if (repo.Create(new MemberResetPassword
                {
                    MemberAccount = Member.Account,
                    UniqueKey = Encrypt.EncryptSHA512(UniqueKey, salt),
                    SaltString = salt
                }) > 0)
                {
                    var client = new SendGridClient(StringDefine.SendGridAPIKey);
                    var from = new EmailAddress("softwarehouse_tw@hotmail.com", "SoftwareHouse");
                    List<EmailAddress> tos = new List<EmailAddress>
                    {
                        new EmailAddress(Member.Email, Member.Name)
                    };
                    var subject = "變更密碼";
                    var htmlContent = HttpContext.Current.Request.Url.Scheme +
                        "://" +
                        HttpContext.Current.Request.Url.Host +
                        "/ForgotPassword/ResetPassword?MemberAccount=" + Member.Account +
                        "&UniqueKey=" +
                        Encrypt.AESEncrypt(UniqueKey);
                    var displayRecipients = false; // set this to true if you want recipients to see each others mail id 
                    var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", htmlContent, displayRecipients);
                    var response = await client.SendEmailAsync(msg);
                }
                else
                {
                    throw new Exception("發生錯誤，請重試");
                }
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
