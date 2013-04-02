using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using cuahsi.his.OpenSearchUri;

namespace OpenSearchUriTemplateTest
{
    [TestFixture]
    public class TemplateTest
    {
        [TestCase("/?query={name}", "name" )]
        [TestCase("/?query={name.name}", "name.name")]
        [TestCase("/?query={name:aname}", "name:aname")]
        [TestCase("/?query={name:name?}", "name:name?")]
        public void testExactMatch (string uri, string templateMatch)
        {
            var urlTemplate = new Template("http://localhost", uri);
            var strings = urlTemplate.ListVariables();
            Assert.Contains(templateMatch.ToUpperInvariant(), strings);
        }

        [TestCase("/?query={name}", "name")]
        [TestCase("/?query={name.name}", "name.name")]
        [TestCase("/?query={name:aname}", "name:aname")]
        [TestCase("/?query={name:name?}", "name:name")]
        public void testMatch(string uri, string templateMatch)
        {
            var urlTemplate = new Template("http://localhost", uri);
            var strings = urlTemplate.ListVariables().ToList();
           
            Assert.IsTrue(strings.Exists(x => x.StartsWith(templateMatch.ToUpperInvariant())) );
        }

        [TestCase("/?query={name}", "name", "fill", "http://localhost/?query=fill","http://localhost" )]
        [TestCase("/?query={name.name}", "name.name", "fill", "http://localhost/?query=fill", "http://localhost")]
        [TestCase("/?query={name:name}", "name:name", "fill", "http://localhost/?query=fill", "http://localhost")]
        [TestCase("/?query={name:name?}", "name:name?", "fill", "http://localhost/?query=fill", "http://localhost")]
        [TestCase("/?query={name:name?}&query2={nothing}", "name:name?", "fill", "http://localhost/?query=fill", "http://localhost")]
        [TestCase("/?query={nothing}&query2={name:name?}", "name:name?", "fill", "http://localhost/?query2=fill", "http://localhost")]
        public void testFill(string uri, string templateMatch, string fillString, string result, string baseUrl)
        {
            var urlTemplate = new Template(baseUrl,uri);
            var strings = urlTemplate.ListVariables();
            var properties = new Dictionary<string, string>();
            properties.Add(templateMatch, fillString);
            var finalUrl = urlTemplate.GetUrl(properties);
            Assert.AreEqual(result, finalUrl);
        }

        [TestCase("/?query2={name:name?}&query={name:name?}", "name:name?", "fill", "http://localhost/?query=fill&query2=fill", "http://localhost")]
       [ExpectedException()]
        public void testFillFail(string uri, string templateMatch, string fillString, string result, string baseUrl)
        {
            var urlTemplate = new Template(baseUrl, uri);
            var strings = urlTemplate.ListVariables();
            var properties = new Dictionary<string, string>();
            properties.Add(templateMatch, fillString);
            var finalUrl = urlTemplate.GetUrl(properties);
            Assert.AreEqual(result, finalUrl);
        }
    }
}
