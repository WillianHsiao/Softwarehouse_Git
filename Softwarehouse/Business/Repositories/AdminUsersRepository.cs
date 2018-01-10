using System;
using System.Linq;
using Business.Interfaces;
using Business.Models.SoftwarehouseDB;
using ObjectCollection.RepositoryConditions;

namespace Business.Repositories
{
    public class AdminUsersRepository : IRepositoryTransaction<AdminUsersRepoCondition, AdminUsers, SoftwarehouseDBModel>, IDisposable
    {
        private SoftwarehouseDBModel db;

        public AdminUsersRepository()
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

        public int Create(AdminUsers content)
        {
            try
            {
                var result = db.AdminUsers.Add(content);
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

        public AdminUsers Get(int key)
        {
            try
            {
                var result = from t in db.AdminUsers
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

        public IQueryable<AdminUsers> Read(AdminUsersRepoCondition condition)
        {
            try
            {
                var result = from t in db.AdminUsers
                             select t;
                State = true;
                return result;
            }
            catch (Exception e)
            {
                State = false;
                throw e;
            }
        }

        public AdminUsers Update(AdminUsersRepoCondition condition)
        {
            try
            {
                var source = Get(condition.Id);
                if (source == null)
                {
                    State = false;
                    return null;
                }
                source.Account = condition.Account;
                source.Password = condition.Password;
                source.Email = condition.Email;
                
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

        public int UpdateAll(AdminUsersRepoCondition condition)
        {
            throw new NotImplementedException();
        }

        public int Delete(AdminUsersRepoCondition condition)
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
                throw e;
            }
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
