// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Runtime.InteropServices;

namespace Ruon
{
    /// <summary>
    /// Interface for a SimpleAgent
    /// </summary>
    //[Guid("A25E9439-4972-4c66-9D9C-83A49E145A78")]
    public interface ISimpleAgent
    {
        /// <summary>
        /// Start the agent
        /// </summary>
        /// <param name="agentType">Type of Agent</param>
        /// <param name="accountId">Secret Account id (taken from the "account settings" page</param>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        bool Start(string agentType, string accountId);

        /// <summary>
        /// Report an Alarm
        /// </summary>
        /// <param name="resource">The resource that is failing</param>
        /// <param name="id">The unique "alarm type" identifier </param>
        /// <param name="description">The alarm description</param>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        bool Alarm(string resource, string id, string description);

        /// <summary>
        /// Clear an Alarm (identified by the combination of resource and id)
        /// </summary>
        /// <param name="resource">The resource that is failing</param>
        /// <param name="id">The unique "alarm type" identifier </param>
        /// <param name="description">The alarm description</param>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        bool Clear(string resource, string id, string description);

        /// <summary>
        /// Clear all alarms for this agent 
        /// </summary>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        bool ClearAll();

        /// <summary>
        /// Report an Event 
        /// </summary>
        /// <param name="resource">The resource that is failing</param>
        /// <param name="id">The unique "alarm type" identifier </param>
        /// <param name="description">The alarm description</param>
        /// <returns>'true' on success. If false, see LastError for more information.</returns>
        bool Event(string resource, string id, string description);

        /// <summary>
        /// Cleanup
        /// </summary>
        void Dispose();


        /// <summary>
        /// Return the description of the last error.
        /// </summary>
        string LastError { get; }
    }
}