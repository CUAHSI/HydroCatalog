using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace cuahsi.his.vocabservice
{
    [ServiceContract(Namespace = "http://his.cuahsi.org/services/ontology")]
    public interface IVocabularyService
    {
        [OperationContract]
        string Test();

        [WebGet( UriTemplate="Vocabularies")]
        [OperationContract]
        Vocabulary[] getVocabularies();

        [OperationContract]
        Vocabulary getVocabulary(string VocabularyName);

        [OperationContract]
        VocabularyTermType getVocabularyTerm(string VocabularyName, string TermName);

        [OperationContract]
        VocabularyTermType[] getAllTerms();

        [OperationContract]
        String GetTermAsToSkos(string Vocabulary, string Term);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract(Name = "Vocabularies", Namespace = "http://his.cuahsi.org/ontology")]
    [Serializable]
    public class VocabulariesList
    {
        List<Vocabulary> Vocab_List = new List<Vocabulary>();
        int vocab_Count;
        
        [DataMember]
        public List<Vocabulary> VocabularyList
        {
            get 
            {
                return Vocab_List;
            }
            set
            {
          
                Vocab_List = value;
            }
        }

    }//end class VocbulariesList

    [DataContract(Namespace = "http://his.cuahsi.org/ontology")]
    public class Vocabulary
    {
        private List<VocabularyTermType> vocab_terms = new List<VocabularyTermType>();
        private string _name;
        private string _descr;
        
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [DataMember]
        public List<VocabularyTermType> VocabularyTerms
        {
            get 
            { 
                return vocab_terms; 
            }
            set
            {
                vocab_terms = value; 
            }
           
        }

        [DataMember]
        public String Description
        {
            get
            {
                return _descr;
            }
            set
            {
                _descr = value;
            }
        }
    }//end class Vocabulary


  //  [DataContract(Namespace = "http://his.cuahsi.org/ontology")]
    [DataContract(Namespace = "http://www.w3.org/2004/02/skos/core#", Name="Concept")]
    public  class VocabularyTermType
    {
        string _term;
        string _descr;
        string _voc;

        [DataMember(Name="inShceme")]
        public string Vocab
        {
            get 
            {
                return _voc;
            }
            set
            {
                _voc = value;
            }
        }

        [DataMember(Name = "prefLabel")]
        public string Term 
        {
            get 
            {
                return _term;
            }
            set 
            {
                _term = value;
            }
        }

        [DataMember(Name = "definition")]
        public string Description   
        {
            get 
            {
                return _descr;
            }
            set
            {
                _descr = value;
            }
        }
    }//end class VocabularyTermType
}
