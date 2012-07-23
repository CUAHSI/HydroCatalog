using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
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
