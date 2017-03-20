using Business.Interfaces;
using Business.Models.SoftwarehouseDB;
using ObjectCollection.RepositoryConditions;
using System;
using System.Linq;

namespace Business.Repositories
{
    public class VipUsersRepository : IRepositoryTransaction<VipUsersRepoCondition, VipUsers, SoftwarehouseDBModel>
    {
        private SoftwarehouseDBModel db;

        public VipUsersRepository()
        {
            if (Context != null)
            {
                db = Context;
            }
            else db = new SoftwarehouseDBModel();
        }

        public SoftwarehouseDBModel Context
        {
            get;
            set;
        }

        public bool State
        {
            get;
            set;
        }

        public int Create(VipUsers content)
        {
            try
            {
                var result = db.VipUsers.Add(content);
                State = true;
                return result.Id;
            }
            catch (Exception e)
            {
                State = false;
                return 0;
            }
        }

        public int Delete(VipUsersRepoCondition condition)
        {
            try
            {
                var source = Get(condition.Id);
                if (source == null)
                {
                    State = false;
                    return 0;
                }

                db.SaveChanges();
                State = true;
                return condition.Id;
            }
            catch (Exception e)
            {
                State = false;
                return 0;
            }
        }

        public VipUsers Get(int key)
        {
            try
            {
                var result = from t in db.VipUsers
                             where t.Id == key
                             select t;
                State = true;
                return result.First();
            }
            catch (Exception e)
            {
                State = false;
                return null;
            }
        }

        public IQueryable<VipUsers> Read(VipUsersRepoCondition condition)
        {
            try
            {
                var result = from t in db.VipUsers
                             select t;
                State = true;
                return result;
            }
            catch (Exception e)
            {
                State = false;
                return null;
            }
            throw new NotImplementedException();
        }

        public VipUsers Update(VipUsersRepoCondition content)
        {
            try
            {
                var source = Get(content.Id);
                if (source == null)
                {
                    State = false;
                    return null;
                }
                source.Account = content.Account;
                source.Password = content.Password;
                source.Email = content.Email;

                db.SaveChanges();
                State = true;
                return source;
            }
            catch (Exception ex)
            {
                State = false;
                return null;
            }
        }

        public int UpdateAll(VipUsersRepoCondition condition)
        {
            throw new NotImplementedException();
        }
    }
}
