﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using urban100.Web.Global.Auth;
using urban100.UnitTest.Fake;
using urban100.UnitTest.Mock.Http;

namespace urban100.UnitTest
{
    [TestFixture]
    public class AdminUserControllerTest
    {

        [Test]
        public void Index_AskForDefaultPage_GetViewResult()
        {
            var auth = DependencyResolver.Current.GetService<IAuthentication>();
            var controller = DependencyResolver.Current.GetService<urban100.Web.Areas.Admin.Controllers.UserController>();
            auth.Login("admin");

            var route = new RouteData();

            route.Values.Add("controller", "User");
            route.Values.Add("action", "Index");
            route.Values.Add("area", "Admin");

            var values = new FakeValueProvider();

            values["page"] = 2;

            var httpContext = new MockHttpContext(auth).Object;
            ControllerContext context = new ControllerContext(new RequestContext(httpContext, route), controller);
            controller.ControllerContext = context;

            var controllerActionInvoker = new FakeControllerActionInvoker<ViewResult>(values);
            var result = controllerActionInvoker.InvokeAction(controller.ControllerContext, "Index");
        }

    }
}
