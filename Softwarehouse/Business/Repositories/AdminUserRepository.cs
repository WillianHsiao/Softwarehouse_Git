using System;
using System.Linq;
using Business.Interfaces;
using Business.Models.SoftwarehouseDB;
using ObjectCollection.RepositoryConditions;

namespace Business.Repositories
{
    public class AdminUserRepository : IRepositoryTransaction<AdminUserRepoCondition, AdminUser, SoftwarehouseDBModel>
    {
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

        public int Create(AdminUser content)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();

                var result = db.AdminUsers.Add(content);
                State = true;
                return result.Id;
            }
            catch (Exception e)
            {
                State = false;
                return 0;
            }
        }

        public AdminUser Get(int key)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();
                var result = from t in db.AdminUsers
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

        public IQueryable<AdminUser> Read(AdminUserRepoCondition condition)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();

                var result = from t in db.AdminUsers
                             select t;
                State = true;
                return result;
            }
            catch (Exception e)
            {
                State = false;
                return null;
            }
        }

        public AdminUser Update(AdminUserRepoCondition condition)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();

                var source = Get(condition.Id);
                if (source == null)
                {
                    State = false;
                    return null;
                }
                
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

        public int UpdateAll(AdminUserRepoCondition condition)
        {
            throw new NotImplementedException();
        }

        public int Delete(AdminUserRepoCondition condition)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();

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
    }
}
