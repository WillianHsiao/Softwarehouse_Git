using Business.Interfaces;
using Business.Models.SoftwarehouseDB;
using ObjectCollection.RepositoryConditions;
using System;
using System.Linq;

namespace Business.Repositories
{
    public class MembersRepository : IRepositoryTransaction<MembersRepoCondition, Members, SoftwarehouseDBModel>, IDisposable
    {
        private SoftwarehouseDBModel db;

        public MembersRepository()
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

        public int Create(Members content)
        {
            try
            {
                var result = db.Members.Add(content);
                db.SaveChanges();
                State = true;
                return result.Id;
            }
            catch (Exception e)
            {
                State = false;
                throw e;
            }
        }

        public Members Get(int key)
        {
            try
            {
                var result = from t in db.Members
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

        public IQueryable<Members> Read(MembersRepoCondition condition)
        {
            try
            {
                var result = from t in db.Members
                             select t;
                if (!string.IsNullOrWhiteSpace(condition.Account))
                {
                    result = result.Where(r => r.Account == condition.Account);
                }
                if (!string.IsNullOrWhiteSpace(condition.Email))
                {
                    result = result.Where(r => r.Email == condition.Email);
                }
                if (!string.IsNullOrWhiteSpace(condition.Password))
                {
                    result = result.Where(r => r.Password.Contains(condition.Password));
                }
                State = true;
                return result;
            }
            catch (Exception e)
            {
                State = false;
                throw e;
            }
        }

        public Members Update(MembersRepoCondition condition)
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

        public int UpdateAll(MembersRepoCondition condition)
        {
            throw new NotImplementedException();
        }

        public int Delete(MembersRepoCondition condition)
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
