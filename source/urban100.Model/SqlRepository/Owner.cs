using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace urban100.Model
{
	
 public partial class SqlRepository
    {
        public IQueryable<Owner> Owners
        {
            get
            {
                return Db.Owners;
            }
        }

        public bool CreateOwner(Owner instance)
        {
            if (instance.ID == 0)
            {
                Db.Owners.InsertOnSubmit(instance);
                Db.Owners.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateOwner(Owner instance)
        {
            var cache = Db.Owners.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
				cache.Name = instance.Name;
				cache.SubTitle = instance.SubTitle;
				cache.Image = instance.Image;
				cache.Twitter = instance.Twitter;
				cache.Facebook = instance.Facebook;
				cache.Google = instance.Google;
				cache.Instagram = instance.Instagram;
				cache.Skype = instance.Skype;
                cache.Cell = instance.Cell;
                Db.Owners.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveOwner(int idOwner)
        {
            Owner instance = Db.Owners.FirstOrDefault(p => p.ID == idOwner);
            if (instance != null)
            {
                Db.Owners.DeleteOnSubmit(instance);
                Db.Owners.Context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}