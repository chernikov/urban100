﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;

namespace urban100.Model
{
    public partial class SqlRepository
    {
        public IQueryable<User> Users
        {
            get
            {
                return Db.Users;
            }
        }

        public bool CreateUser(User instance)
        {
            if (instance.ID == 0)
            {
                instance.AddedDate = DateTime.Now;
                instance.LastVisitDate = DateTime.Now;
                instance.ActivatedLink = StringExtension.GenerateNewFile();
                Db.Users.InsertOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public User GetUser(string email)
        {
            return Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }

        public User Login(string email, string password)
        {
            return Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }

        public bool UpdateUser(User instance)
        {
            var cache = Db.Users.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.Email = instance.Email;
                cache.AvatarPath = instance.AvatarPath;
                cache.FirstName = instance.FirstName;
                cache.LastName = instance.LastName;
                Db.Users.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool ActivateUser(User instance)
        {
            var cache = Db.Users.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.ActivatedDate = DateTime.Now;
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }


        public bool ChangePassword(User instance)
        {
            var cache = Db.Users.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.Password = instance.Password;
                Db.Users.Context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
