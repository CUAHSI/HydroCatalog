using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;
using Microsoft.ApplicationServer.Http;
using Microsoft.ApplicationServer.Http.Dispatcher;

namespace $rootnamespace$.Resources
{
    // TODO: Use Visual Studio refactoring to rename "MyModelType" to your desired type.
    //       Then you can move the model to its own file.
    public class MyModelType
    {
        public int Id { get; set; }
    }

    [ServiceContract]
    // TODO: Use Visual Studio refactoring to rename "MyModelResource" to desired name.
    public class MyModelResource
    {
        // TODO: replace with your own "real" Repository implementation
        private static readonly Dictionary<int, MyModelType> repository = new Dictionary<int, MyModelType>();

        [WebGet(UriTemplate = "{id}")]
        public HttpResponseMessage<MyModelType> Get(int id)
        {
            MyModelType item;
            if (!repository.TryGetValue(id, out item))
            {
                var notFoundResponse = new HttpResponseMessage();
                notFoundResponse.StatusCode = HttpStatusCode.NotFound;
                notFoundResponse.Content = new StringContent("Item not found");
                throw new HttpResponseException(notFoundResponse);
            }
            var response = new HttpResponseMessage<MyModelType>(item);

            // set it to expire in 5 minutes
            response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(30));
            return response;
        }

        [WebInvoke(UriTemplate = "", Method = "POST")]
        public HttpResponseMessage<MyModelType> Post(MyModelType item)
        {
            item.Id = (repository.Keys.Count == 0 ? 1 : repository.Keys.Max() + 1);
            repository.Add(item.Id, item);

            var response = new HttpResponseMessage<MyModelType>(item);
            response.StatusCode = HttpStatusCode.Created;
            response.Headers.Location = new Uri("Contacts/" + item.Id, UriKind.Relative);
            return response;
        }

        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        public MyModelType Put(int id, MyModelType item)
        {
            repository[id] = item;
            return item;
        }

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        public MyModelType Delete(int id)
        {
            var deleted = repository[id];
            repository.Remove(id);
            return deleted;
        }
    }
}