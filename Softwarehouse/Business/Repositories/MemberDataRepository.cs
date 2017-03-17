using System;
using System.Linq;
using Business.Interfaces;
using Business.Models.SoftwarehouseDB;
using ObjectCollection.RepositoryConditions;

namespace Business.Repositories
{
    public class MemberDataRepository : IRepositoryTransaction<MemberDataRepoCondition, MemberData, SoftwarehouseDBModel>
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

        public int Create(MemberData content)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();
                content.CreateDate = DateTime.Now;
                content.IsDelete = false;
                var result = db.Member.Add(content);
                State = true;
                return result.Id;
            }
            catch (Exception e)
            {
                State = false;
                return 0;
            }
        }

        public MemberData Get(int key)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();
                var result = from t in db.Member
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

        public IQueryable<MemberData> Read(MemberDataRepoCondition condition)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();

                var result = from t in db.Member
                             where t.IsDelete == false
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

        public MemberData Update(MemberDataRepoCondition condition)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();

                var source = Get(condition.ManagerID);
                if (source == null)
                {
                    State = false;
                    return null;
                }
                
                source.UpdateDate = DateTime.Now;
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

        public int UpdateAll(MemberDataRepoCondition condition)
        {
            throw new NotImplementedException();
        }

        public int Delete(MemberDataRepoCondition condition)
        {
            try
            {
                SoftwarehouseDBModel db;
                if (Context != null)
                {
                    db = Context;
                }
                else db = new SoftwarehouseDBModel();

                var source = Get(condition.ManagerID);
                if (source == null)
                {
                    State = false;
                    return 0;
                }

                source.IsDelete = true;
                db.SaveChanges();
                State = true;
                return condition.ManagerID;
            }
            catch (Exception e)
            {
                State = false;
                return 0;
            }
        }
    }
}
