using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NUnit.Framework;
using NUnit.Mocks;

namespace WfsHandlerTest
{
    [TestFixture()]
    public class WfsHandlerTest
    {
        private DynamicMock contextMock;
        private HttpContext context = null;
        private DynamicMock requestMock = null;
        private DynamicMock responseMock = null;

        [SetUp()]
        public void Setup()
        {

            //requestMock = (HttpRequest) new DynamicMock(typeof(HttpRequestBase));
            //responseMock = new DynamicMock(typeof(HttpResponse));

            //context = new HttpContext(responseMock, responseMock);
        }
    }

 
}
