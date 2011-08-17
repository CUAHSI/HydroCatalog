using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using NUnit.Mocks;

namespace WfsHandlerTest
{
   
//public class API_Moq_HttpContext
//    {           
//        public Mock<HttpContextBase> MockContext { get; set; }
//        public Mock<HttpRequestBase> MockRequest { get; set; }
//        public Mock<HttpResponseBase> MockResponse { get; set; }
//        public Mock<HttpSessionStateBase> MockSession { get; set; }
//        public Mock<HttpServerUtilityBase> MockServer { get; set; }
//        public Mock<IPrincipal> MockUser { get; set; }
//        public Mock<IIdentity> MockIdentity { get; set; }
       
//        public HttpContextBase HttpContextBase  { get; set; }
//        public HttpRequestBase HttpRequestBase  { get; set; }
//        public HttpResponseBase HttpResponseBase  { get; set; }       
       
//        public API_Moq_HttpContext()
//        {
//            createBaseMocks();
//            setupNormalRequestValues();
//        }
       
//        public API_Moq_HttpContext createBaseMocks()
//        {
//            MockContext = new Mock<HttpContextBase>();
//            MockRequest = new Mock<HttpRequestBase>();
//            MockResponse = new Mock<HttpResponseBase>();
//            MockSession = new Mock<HttpSessionStateBase>();
//            MockServer = new Mock<HttpServerUtilityBase>();
           
   
//            MockContext.Setup(ctx => ctx.Request).Returns(MockRequest.Object);
//            MockContext.Setup(ctx => ctx.Response).Returns(MockResponse.Object);
//            MockContext.Setup(ctx => ctx.Session).Returns(MockSession.Object);
//            MockContext.Setup(ctx => ctx.Server).Returns(MockServer.Object);
            
            
//             HttpContextBase = MockContext.Object;
//             HttpRequestBase = MockRequest.Object;
//             HttpResponseBase = MockResponse.Object;
                         
//             return this;
//        }
       
//        public API_Moq_HttpContext setupNormalRequestValues()
//        {
//            //Context.User
//            var MockUser = new Mock<IPrincipal>();
//            var MockIdentity = new Mock<IIdentity>();       
//            MockContext.Setup(context => context.User).Returns(MockUser.Object);
//             MockUser.Setup(context => context.Identity).Returns(MockIdentity.Object);
            
//             //Request
//             MockRequest.Setup(request =>request.InputStream).Returns(new MemoryStream());
            
//             //Response
//             MockResponse.Setup(response =>response.OutputStream).Returns(new MemoryStream());
//             return this;
//        }
//    }

}
