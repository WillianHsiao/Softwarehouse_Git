using Business.Interfaces;
using Business.Models.SoftwarehouseDB;
using ObjectCollection.RepositoryConditions;
using System;
using System.Linq;

namespace Business.Repositories
{
    public class VipUsersRepository : IRepositoryTransaction<VipUsersRepoCondition, VipUsers, SoftwarehouseDBModel>, IDisposable
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
                db.SaveChanges();
                return result.Id;
            }
            catch (Exception e)
            {
                State = false;
                throw e;
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
                throw e;
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
                throw e;
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
            catch (Exception e)
            {
                State = false;
                throw e;
            }
        }

        public int UpdateAll(VipUsersRepoCondition condition)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int key)
        {
            try
            {
                var source = Get(key);
                if (source == null)
                {
                    State = false;
                }

                db.SaveChanges();
                State = true;
            }
            catch (Exception e)
            {
                State = false;
                throw e;
            }
            return State;
        }
        public bool DeleteAll(VipUsersRepoCondition condition)
        {
            try
            {
                var source = Read(condition);
                if (source == null)
                {
                    State = false;
                    return State;
                }
                db.VipUsers.RemoveRange(source);

                db.SaveChanges();
                State = true;
            }
            catch (Exception e)
            {
                State = false;
                throw e;
            }
            return State;
        }
        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
    }
}
