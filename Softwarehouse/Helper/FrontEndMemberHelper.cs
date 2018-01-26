using Business.Models.SoftwarehouseDB;
using Business.Repositories;
using Common.Classes;
using Common.StringDefine;
using ObjectCollection.RepositoryConditions;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helper
{
    public static class FrontEndMemberHelper
    {
        /// <summary>
        /// 取得目前登入的使用者的 SystemUser 資料
        /// </summary>
        public static Members CurrentUserObject
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session[StringDefine.KEY_CURRENT_USER] != null)
                    {
                        string sessionVal = HttpContext.Current.Session[StringDefine.KEY_CURRENT_USER].ToString();

                        string useridStr = sessionVal.Split('|')[0];


                        if (!int.TryParse(useridStr, out int userid))
                        {
                            return null;
                        }

                        MembersRepository repo = new MembersRepository();
                        return repo.Get(userid);
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 取得目前登入的使用者的常用資料資料(節省撈SQL的資料量)
        /// </summary>
        public static FrontEndMemberData CurrentMemberData
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session[StringDefine.KEY_CURRENT_USER] != null)
                    {
                        string sessionVal = HttpContext.Current.Session[StringDefine.KEY_CURRENT_USER].ToString();

                        List<string> sessionValList = sessionVal.Split('|').ToList();

                        string useridStr = sessionValList[0];


                        if (!int.TryParse(useridStr, out int tryParseIntObj))
                        {
                            return null;
                        }
                        FrontEndMemberData result;

                        using (var repo = new MembersRepository())
                        {
                            result = repo.Read(new MembersRepoCondition
                            {
                                Id = tryParseIntObj
                            }).Select(p => new FrontEndMemberData
                            {
                                Id = p.Id,
                                Account = p.Account,
                                Email = p.Email
                            }).FirstOrDefault();
                        }
                        return result;
                    }
                }
                return null;
            }
        }
    }
}
