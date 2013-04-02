using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace cuahsi.his.vocabservice
{
    [DataContract(Name = "SKOS", Namespace = "http://his.cuahsi.org/ontology")]
    [Serializable]
    public class Concepts
    {
        private string name;

        [DataMember(Name = "Concept")]
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


        [DataMember(Name = "prefLabel")]
        public String prefName
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

        private string sName;
        [DataMember(Name = "altLabel")]
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

        private string parentName;

        //[DataMember(Name="broader")]

    }//end class Concepts

    //[DataContract(Name = "Synonym", Namespace = "http://his.cuahsi.org/ontology")]
    //[Serializable]
    //public class Synonym
    //{


    //    Concepts c = new Concepts();

    //    [DataMember]
    //    public int ConceptID
    //    {
    //        get
    //        {
    //            return c.ConceptID;
    //        }
    //        set
    //        {
    //            c.ConceptID = value;
    //        }
    //    }

    //}//end class Synonym

    //[DataContract(Name = "Hierarchy", Namespace = "http://his.cuahsi.org/ontology")]
    //[Serializable]
    //public class Hierarchy
    //{
    //    private int parentID;
        
    //    [DataMember]
    //    public int ParentID
    //    {
    //        get 
    //        { 
    //            return parentID; 
    //        }
    //        set 
    //        { 
    //            parentID = value;
    //        }
    //    }

    //    Concepts c = new Concepts();

    //    [DataMember (Name="broader")]
    //    public String ConceptName
    //    {
    //        get
    //        {
    //            return c.ConceptName;
    //        }
    //        set
    //        {
    //            c.ConceptName = value;
    //        }
    //    }
    //}//end class hierarchy

}