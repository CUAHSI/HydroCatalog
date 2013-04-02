using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using cuahsi.HisVocabLib;

namespace cuahsi.his.vocabservice
{
    [ServiceContract(Namespace = "http://his.cuahsi.org/services/ontology")]

    public interface IVocabularyService
    {
        [OperationContract]
        string Test();

      //  [WebGet( UriTemplate="/Vocabularies", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract(Name = "GetVocabularies")]
        Vocabulary[] getVocabularies();

        [OperationContract(Name = "GetVocabulary")]
        Vocabulary getVocabulary(string VocabularyName);

        [OperationContract(Name = "GetVocabularyTerm")]
        VocabularyTermType getVocabularyTerm(string VocabularyName, string TermName);

        [OperationContract]
        VocabularyTermType[] getAllTerms();

        [OperationContract]
        String GetTermAsToSkos(string Vocabulary, string Term);
    }


   
}
