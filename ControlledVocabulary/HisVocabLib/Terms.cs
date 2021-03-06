﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace cuahsi.HisVocabLib
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract(Name = "Vocabularies", Namespace = "http://his.cuahsi.org/ontology")]
    [Serializable]
    public class VocabulariesList
    {
        List<VocabularyDescription> Vocab_List = new List<VocabularyDescription>();
        int vocab_Count;

        [DataMember]
        public List<VocabularyDescription> VocabularyList
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
    public class VocabularyDescription
    {
      // if this is not null, it will show up as an element.
        // So 
        // private List<VocabularyTermType> vocab_terms = new List<VocabularyTermType>();
        private List<VocabularyTermType> vocab_terms = null;
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
    }//end class VocabularyDescription
    [DataContract(Namespace = "http://his.cuahsi.org/ontology")]
    public class Vocabulary: VocabularyDescription
    {

        private List<VocabularyTermType> vocab_terms = null;

        public Vocabulary ()
        {
            vocab_terms = new List<VocabularyTermType>();
        }
        public Vocabulary(VocabularyDescription vocabularyDescription)
        {
            vocab_terms = null;
            Description = vocabularyDescription.Description;
            Name = vocabularyDescription.Name;
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
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
    }

    //  [DataContract(Namespace = "http://his.cuahsi.org/ontology")]
    [DataContract(Namespace = "http://www.w3.org/2004/02/skos/core#", Name = "Concept")]
    public class VocabularyTermType
    {
        string _term;
        string _descr;
        string _voc;
        //string _synonym;
        //string _child;
        //string _parent;

        [DataMember(Name = "resource",IsRequired = false)]
        public string Identifier
        {
            get;

            set;
            
        }

        [DataMember(Name = "inShceme")]
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

        [DataMember(Name = "description")]
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
        List<Synonym> _syns = new List<Synonym>();
        [DataMember]
        public List<Synonym> Synonyms
        {
            get
            {
                return _syns;
            }
            set
            {
                _syns = value;
            }

        }
        //are there a list of parents and a list of children (broader and narrower terms)?
        List<LinkedConcept> parents = new List<LinkedConcept>();
        [DataMember(Name="broader")]
        public List<LinkedConcept> ParentConcepts 
        { 
            get
            {
                return parents;
            }
            set
            {
                parents = value;
            }
        }

        List<LinkedConcept> children = new List<LinkedConcept>();
        [DataMember(Name="narrower")]
        public List<LinkedConcept> ChildConcepts
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }
    }//end class VocabularyTermType

    public class LinkedConcept
    {
        private string con;
        public String cName
        {
            get
            {
                return con;
            }
            set
            {
                con = value;
            }
        }

    }

    public class Synonym
    {
        private string syn;
        [DataMember(Name="altlabel")]
        public String altLabel
        {
            get
            {
                return syn;
            }
            set
            {
                syn = value;
            }
        }
    }

}
