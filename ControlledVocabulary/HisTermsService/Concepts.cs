using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace cuahsi.his.vocabservice
{
    [DataContract(Name = "Concepts", Namespace = "http://his.cuahsi.org/ontology")]
    [Serializable]
    public class Concepts
    {
        private int id;
        
        [DataMember]
        public int ConceptID
        {
            get
            {
                return id;
            }
            set 
            {
                id = value;
            }
        }

        private string name;

        [DataMember]
        public String ConceptName
        {
            get
            {
                return name;
            }
            set 
            {
                name = value;
            }
        }
    }//end class Concepts

    [DataContract(Name = "Synonym", Namespace = "http://his.cuahsi.org/ontology")]
    [Serializable]
    public class Synonym
    {
        private string sName;
        [DataMember]
        public String SynonymName
        {
            get 
            { 
                return sName;
            }
            set 
            { 
                sName = value;
            }
        }

        Concepts c = new Concepts();

        [DataMember]
        public int ConceptID
        {
            get
            {
                return c.ConceptID;
            }
            set
            {
                c.ConceptID = value;
            }
        }

    }//end class Synonym

    [DataContract(Name = "Hierarchy", Namespace = "http://his.cuahsi.org/ontology")]
    [Serializable]
    public class Hierarchy
    {
        private int parentID;
        
        [DataMember]
        public int ParentID
        {
            get 
            { 
                return parentID; 
            }
            set 
            { 
                parentID = value;
            }
        }

        Concepts c = new Concepts();

        [DataMember]
        public int ConceptID
        {
            get
            {
                return c.ConceptID;
            }
            set
            {
                c.ConceptID = value;
            }
        }

        [DataMember]
        public String ConceptName
        {
            get
            {
                return c.ConceptName;
            }
            set
            {
                c.ConceptName = value;
            }
        }
    }//end class hierarchy



}