using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urban100.Model
{
    public interface IRepository
    {
        IQueryable<T> GetTable<T>() where T : class;

        #region Role

        IQueryable<Role> Roles { get; }

        bool CreateRole(Role instance);

        bool RemoveRole(int idRole);

        #endregion

        #region User

        IQueryable<User> Users { get; }

        bool CreateUser(User instance);

        bool UpdateUser(User instance);

        User GetUser(string email);

        User Login(string email, string password);

        bool ActivateUser(User instance);

        bool ChangePassword(User instance);

        #endregion

        #region UserRole

        IQueryable<UserRole> UserRoles { get; }

        bool CreateUserRole(UserRole instance);

        bool RemoveUserRole(int idUserRole);

        #endregion

        #region Owner
        
        IQueryable<Owner> Owners { get; }
        
        bool CreateOwner(Owner instance);
        
        bool UpdateOwner(Owner instance);
        
        bool RemoveOwner(int idOwner);
        
        #endregion 

        #region Candidate
        
        IQueryable<Candidate> Candidates { get; }
        
        bool CreateCandidate(Candidate instance);
        
        bool UpdateCandidate(Candidate instance);
        
        bool RemoveCandidate(int idCandidate);
        
        #endregion 
    }
}
