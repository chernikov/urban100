using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using urban100.Model;

namespace urban100.Web.Global.Auth
{
    public interface IUserable : IIdentity
    {
        User User { get; }
    }
}