﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace urban100.UnitTest.Mock.Http
{
    public class MockHttpBrowserCapabilities : Mock<HttpBrowserCapabilitiesBase>
    {
        public MockHttpBrowserCapabilities(MockBehavior mockBehavior = MockBehavior.Strict)
            : base(mockBehavior)
        {

        }
    }
}