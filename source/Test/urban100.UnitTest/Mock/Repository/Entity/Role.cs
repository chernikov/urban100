using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using urban100.Model;
using Moq;

namespace urban100.UnitTest.Mock.Repository
{
    public partial class MockRepository
    {
        public List<Role> Roles { get; set; }

        public void GenerateRoles()
        {
            Roles = new List<Role>();
            Roles.Add(new Role()
            {
                ID = 1,
                Code = "admin",
                Name = "Administrator"
            });

            this.Setup(p => p.Roles).Returns(Roles.AsQueryable());
        }
    }
}
