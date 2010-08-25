using System;

namespace Ruon
{
    /// <summary>
    /// This is an attribute used to signal the Class that should be loaded by
    /// the ServiceLoader. It tells the SericeLoader to load this class as the
    /// agent as well as it's id, name, and description.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class AgentAttributes : System.Attribute
    {
        private string id;
        private string name;
        private string description;
        /// <summary>
        /// Attribute Constructor
        /// </summary>
        /// <param name="id">The id of the service. Used as the service name and as 
        /// the directory name in which the binary is installed.</param>
        /// <param name="name">The full, friendly, name of the service/agent</param>
        /// <param name="description">The description of the agent</param>
        public AgentAttributes(string id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
        /// <summary>
        /// Retrieve the id
        /// </summary>
        public string Id { get { return id; } }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get { return name; } }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get { return description; } }

    }
}
