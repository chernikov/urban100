using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace urban100.Model
{
	
 public partial class SqlRepository
    {
        public IQueryable<Candidate> Candidates
        {
            get
            {
                return Db.Candidates;
            }
        }

        public bool CreateCandidate(Candidate instance)
        {
            if (instance.ID == 0)
            {
                Db.Candidates.InsertOnSubmit(instance);
                Db.Candidates.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateCandidate(Candidate instance)
        {
            var cache = Db.Candidates.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
				cache.Name = instance.Name;
				cache.Phone = instance.Phone;
				cache.Email = instance.Email;
				cache.Notes = instance.Notes;
                Db.Candidates.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveCandidate(int idCandidate)
        {
            Candidate instance = Db.Candidates.FirstOrDefault(p => p.ID == idCandidate);
            if (instance != null)
            {
                Db.Candidates.DeleteOnSubmit(instance);
                Db.Candidates.Context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}