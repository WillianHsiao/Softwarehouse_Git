﻿using Business.Interfaces;
using Business.Models.SoftwarehouseDB;
using ObjectCollection.RepositoryConditions;
using System;
using System.Linq;

namespace Business.Repositories
{
    public class MemberResetPasswordRepository : IRepositoryTransaction<MemberResetPasswordRepoCondition, MemberResetPassword, SoftwarehouseDBModel>, IDisposable
    {
        private SoftwarehouseDBModel db;

        public MemberResetPasswordRepository()
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

        public int Create(MemberResetPassword content)
        {
            try
            {
                var result = db.MemberResetPassword.Add(content);
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

        public MemberResetPassword Get(int key)
        {
            try
            {
                var result = from t in db.MemberResetPassword
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

        public IQueryable<MemberResetPassword> Read(MemberResetPasswordRepoCondition condition)
        {
            try
            {
                var result = from t in db.MemberResetPassword
                             select t;
                if (!string.IsNullOrWhiteSpace(condition.MemberAccount))
                {
                    result = result.Where(r => r.MemberAccount == condition.MemberAccount);
                }
                if (!string.IsNullOrWhiteSpace(condition.UniqueKey))
                {
                    result = result.Where(r => r.UniqueKey == condition.UniqueKey);
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

        public MemberResetPassword Update(MemberResetPasswordRepoCondition condition)
        {
            try
            {
                var source = Get(condition.Id);
                if (source == null)
                {
                    State = false;
                    return null;
                }
                source.MemberAccount = condition.MemberAccount;
                source.UniqueKey = condition.UniqueKey;

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

        public int UpdateAll(MemberResetPasswordRepoCondition condition)
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
        public bool DeleteAll(MemberResetPasswordRepoCondition condition)
        {
            try
            {
                var source = Read(condition);
                if (source == null)
                {
                    State = false;
                    return State;
                }
                db.MemberResetPassword.RemoveRange(source);

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
