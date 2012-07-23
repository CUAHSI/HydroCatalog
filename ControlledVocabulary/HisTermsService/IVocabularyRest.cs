using System.ServiceModel;
using System.ServiceModel.Web;
using cuahsi.HisVocabLib;

namespace cuahsi.his.vocabservice
{
    [ServiceContract(Namespace = "http://his.cuahsi.org/services/ontology")]
    interface IVocabularyRest
    {
        [WebGet(UriTemplate = "/Vocabularies" )]  
        Vocabulary[] getVocabularies();
    }
}
