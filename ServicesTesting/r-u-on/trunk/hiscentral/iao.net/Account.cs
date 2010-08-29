using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;

namespace Ruon
{
    /// <summary>
    /// A collection of account related methods to support different agent creation schemes.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Use this method to resolve the id of an existing account 
        /// </summary>
        /// <param name="email">Account identifier</param>
        /// <param name="password">The password</param>
        /// <returns>The account id</returns>
        /// <throws>
        /// Will throw a IAOException in case of communication errors
        /// or if an error was returned by the server.
        /// In case of communication errors the inner exception will indicate
        /// the IOException.
        /// </throws>
        public static string ResolveAccountID(string email, string password)
        {
            return Guid(Url("email", email, "password", password));
        }

        /// <summary>
        /// Use this method to create a new account and get its newly created account identifier.
        /// The account has to be associated with a parent account for accountability purposes
        /// as well as possible future functionality.
        /// </summary>
        /// <param name="email">New account identifier</param>
        /// <param name="password">New account password</param>
        /// <param name="parentAccountID">Parent account to which this newly created account is associated</param>
        /// <returns>The new account id</returns>
        /// <throws>
        /// Will throw a IAOException in case of communication errors
        /// or if an error was returned by the server.
        /// In case of communication errors the inner exception will indicate
        /// the IOException.
        /// </throws>
        public static string CreateAccount(string email, string password, string parentAccountID)
        {
            return Guid(Url("email", email, "password", password, "parent", parentAccountID, "create"));
        }

        #region private_parts

        private static string Url(params string[] pp)
        {
            bool name = true;
            StringBuilder sb = new StringBuilder();
#if RUONDEV
            sb.Append("http://ruondev:8080/resolveGUID?");
#else
            sb.Append("https://www.r-u-on.com/resolveGUID?");
#endif
            foreach (string p in pp)
            {
                sb.Append(p);
                sb.Append(name ? "=" : "&");
                name = !name;
            }
            sb.Length = sb.Length - 1;
            return sb.ToString();
        }

        private static string Guid(string url)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(resp.GetResponseStream());
                    return Guid(doc);
                }
                finally
                {
                    resp.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof (IAOException))
                {
                    throw new IAOException(ex.Message, ex);
                }
                else
                {
                    throw;
                }
            }
        }

        private static string Guid(XmlDocument doc)
        {
            XmlNode node = doc.ChildNodes[0];
            if ("error" == node.Name)
            {
                throw new IAOException(node.InnerText);
            }
            else if ("guid" == node.Name)
            {
                return node.InnerText;
            }
            else
            {
                throw new IAOException("Unknown protocol response " + node.InnerText);
            }
        }

        #endregion
    }
}