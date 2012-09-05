using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Data.SqlClient;
using cuahsi.HisVocabLib;

namespace cuahsi.his.vocabservice
{
    /* 
     * THIS IS NOW DONE IN CODE IN global.asmx
     *  void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteTable.Routes.Add(new ServiceRoute("Terms", new ServiceHostFactory(), typeof(HisVocabularyService)));
        }
     * 
     * combined with 
     * <modules runAllManagedModulesForAllRequests="true">
			  <add name="UrlRoutingModule" type="System.Web.Routing.UrlRoutingModule, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
		  </modules>

		  <handlers>
			  <add name="UrlRoutingHandler" preCondition="integratedMode" verb="*" path="UrlRouting.axd"/>
		  </handlers>
     * and
     * 
     * <system.serviceModel>
    <services>
      <service name="cuahsi.his.vocabservice.HisVocabularyService" behaviorConfiguration="serveBehav">
        <endpoint address="rest" binding="webHttpBinding" behaviorConfiguration="restBehavior" contract="cuahsi.his.vocabservice.IVocabularyRest" />
        <endpoint address="soap" binding="basicHttpBinding"  contract="cuahsi.his.vocabservice.IVocabularyService" />
        <endpoint contract="IMetadataExchange" binding="mexHttpBinding" address="mex" />
      </service>
    </services>
    <behaviors>
      <serviceBehaviors>
        <behavior name="serveBehav">
			
          <!-- To avoid disclosing metadata information, set the value below to false and remove the metadata endpoint above before deployment -->
          <serviceMetadata httpGetEnabled="true" />
          <!-- To receive exception details in faults for debugging purposes, set the value below to true.  Set to false before deployment to avoid disclosing exception information -->
          <serviceDebug includeExceptionDetailInFaults="true"/>
          
        </behavior>
      </serviceBehaviors>
      <endpointBehaviors>
        <behavior name ="restBehavior">
         
          <webHttp helpEnabled="true"/>
   
        </behavior>
      </endpointBehaviors>
    </behaviors>
	  <serviceHostingEnvironment multipleSiteBindingsEnabled="true"  aspNetCompatibilityEnabled="true">
		  <serviceActivations>
			  <!-- example of how to do the config without the vocab-->
			<!--  <add   relativeAddress="His.svc" service="cuahsi.his.vocabservice.HisVocabularyService"  />
		  -->
		  </serviceActivations>
	  </serviceHostingEnvironment>
  </system.serviceModel>
     * 
     * */
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class HisVocabularyService : IVocabularyService, IVocabularyRest
    {
        private String[] tableNames = {"CensorCodeCV", "DataTypeCV", "GeneralCatogoryCV", "SampleMediumCV", "SampleTypeCV", "SiteTypeCV", 
                                          "SpeciationCV", "TopicCategory", "ValueTypeCV", "VariableNameCV", "VerticalDatumCV", "Concepts"};

        private string connectionString1 = "Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;";

        private string connectionString2 = "Data Source=kyle.ucsd.edu; database=HisMasterVocabTest; User=webservice; Password=webservice;";
        private string tName;

        //private static SqlConnection conn1 = new SqlConnection(@"Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;");
        //private static SqlConnection conn2 = new SqlConnection(@"Data Source=kyle.ucsd.edu; database=HisMasterVocabTest; User=webservice; Password=webservice;");
        private VocabulariesList vocabularies = new VocabulariesList();
       
        public HisVocabularyService()
        {
            getVocabularies();
        }

        /*
         * getVocabularies() - this method should return all the vocabularies and their description in the cuahsi DB
         *                    
         * @params: none
         * @returns: VocabulariesList
         * */
        [WebGet(UriTemplate = "Vocabularies")]
        public Vocabulary[] getVocabularies()
        {
            SqlConnection conn1 = new SqlConnection(@connectionString1);
            List<VocabularyDescription> all_vocab = new List<VocabularyDescription>();

            using (conn1)
            {
                SqlCommand Command1 = conn1.CreateCommand();

                Command1.CommandText = "SELECT VocabularyName, VocabularyDescription FROM VocabularyDescription";
                conn1.Open();
                SqlDataReader rdr1 = Command1.ExecuteReader();

                while (rdr1.Read())
                {
                    VocabularyDescription v = new VocabularyDescription();
                    v.Name = rdr1.GetString(0);
                    v.Description = rdr1.GetString(1);
                    vocabularies.VocabularyList.Add(v);
                    all_vocab.Add(v);
                }
                rdr1.Close();
                conn1.Close();
               return all_vocab.ConvertAll(vocab => new Vocabulary(vocab)).ToArray();
            }
        }

        /*
         * getVocabulary() - this method returns the vocabulary that the client selects, if it doesnt exist should throw error
         * 
         * @params: String
         * @returns: VocabularyDescription
         * 
         * */
        public Vocabulary getVocabulary(string VocabularyName)
        {
            SqlConnection conn1 = new SqlConnection(@connectionString1);
            bool found = false;

            Vocabulary v = new Vocabulary();
            found = vocabExists(VocabularyName);
            //see if vocabulary exists. Get the desription
            if (found == false)
            {
                throw new NotFoundException("The vocabulary you have selected in is not in the database");
            }
            
            v.Name = VocabularyName;
            //using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterVocabualaryV11"].ConnectionString))
            //{
            using (conn1)
            {
                v.VocabularyTerms.AddRange(GetTermsFromDB(VocabularyName, conn1));

            }//end using()

            conn1.Close();
            return v;
        }//end getVocabulary()


        /**
         * getVocabularyTerm() - returns the specified term based on the specified vocabulary
         * 
         * 
         **/
        [Serializable]
        public class NotFoundException : Exception
        {
            public NotFoundException(string message)
                : base(message) { }

        }

        public VocabularyTermType getVocabularyTerm(string VocabularyName, string TermName)
        {
            SqlConnection conn1 = new SqlConnection(@connectionString1);
            SqlConnection conn2 = new SqlConnection(@connectionString2);
            bool found = false;
            //Commenting out the validation for now, may not be necessary...
            ////Validate that vocab exists
            //found = vocabExists(VocabularyName);
            //if(found == false)
            //{
            //    throw new NotFoundException("The vocabulary you have selected in is not in the database");
            //}

            ////found = termExists(VocabularyName, TermName);
            //if (found == false)
            //{
            //    throw new NotFoundException("The term you have selected in is not in the database");
            //}
            if (VocabularyName.Equals("Concepts"))
            {
                VocabularyTermType _term = new VocabularyTermType();

                using (conn2)
                {
                    conn2.Open();
                    SqlCommand command = conn2.CreateCommand();
                    int id = 0;
                    command.CommandText = "SELECT * FROM Concepts WHERE ConceptName='" + TermName + "'"; 
                    SqlDataReader rdr1 = command.ExecuteReader();
                    while (rdr1.Read())
                    {
                        _term.Term = rdr1.GetString(1);
                        _term.Description = rdr1.GetValue(0).ToString();
                        _term.Vocab = "Concepts";

                        id = Convert.ToInt32(_term.Description);
                    }
                    rdr1.Close();

                    SqlCommand command2 = conn2.CreateCommand();

                    command2.CommandText = "SELECT * FROM Synonyms WHERE ConceptID=" + id;
                    SqlDataReader rdr2 = command2.ExecuteReader();
                    Synonym syn = new Synonym();
                    syn.altLabel = "none";
                    while (rdr2.Read())
                    {
                        syn.altLabel = rdr2.GetString(0);
                        _term.Synonyms.Add(syn);
                    }
                    conn2.Close();
                }
                return _term;
            }

            else
            {
                using (conn1)
                {
                    tName = TermName;
                    var terms = GetTermsFromDB(VocabularyName, conn1);
                    var term = from aTerm in terms
                               where aTerm.Term.Equals(TermName, StringComparison.InvariantCultureIgnoreCase)
                               select aTerm;
                    conn1.Close();
                    return term.First();
                }
            }

        }

        public VocabularyTermType[] getAllTerms()
        {
            List<String> vocabs = new List<String>();
            List<VocabularyTermType> all_terms = new List<VocabularyTermType>();
            SqlConnection conn1 = new SqlConnection(@connectionString1);

            using (conn1)
            {
                SqlCommand Command1 = conn1.CreateCommand();
                Command1.CommandText = "SELECT VocabularyName FROM VocabularyDescription";
                conn1.Open();
                SqlDataReader rdr1 = Command1.ExecuteReader();

                while (rdr1.Read())
                {
                    vocabs.Add((string)rdr1["VocabularyName"]);
                }

                using (conn1)
                {
                    foreach (string aVocab in vocabs)
                    {
                        if (aVocab != null) all_terms.AddRange(GetTermsFromDB(aVocab, conn1));
                    }

                }

                rdr1.Close();
                conn1.Close();
            }


            return all_terms.ToArray();

        }

        [WebGet(UriTemplate = "test/")]
        public string Test()
        {
            return "test";

        }

        public String GetTermAsToSkos(string Vocabulary, string Term)
        {
            string skos_output;
            //VocabularyDescription = getVocabulary(VocabularyDescription).Name;
            Term = getVocabularyTerm(Vocabulary, Term).Term;

            skos_output = String.Format("\t<skos:concept rdf:about=\"urn:cuahsi.org/vocabulary/{0}#{1}\"\n" +
                                        "\t<skos:prefLabel xml:lang=\"en\">{2}</skos:prefLabel>\n" +
                                        "\t\t<skos:altLabel xml:lang=\"en\">{3}</skos:AltLabel>\">\n" +
                                        "\t\t<skos:definition>{4}</skos:defnition></skos:concept>\n", Vocabulary, Term, Term, Term, getVocabularyTerm(Vocabulary, Term).Description);
            return skos_output;
        }

        private List<VocabularyTermType> GetTermsFromDB(string VocabularyName, SqlConnection conn)
        {
;
            List<VocabularyTermType> vocab = new List<VocabularyTermType>();
            Synonym syn = new Synonym();
       
            List<Synonym> s = new List<Synonym>();
         
            if(VocabularyName.Equals("Concepts"))
            {
                VocabularyTermType _term = new VocabularyTermType();
           
                using (conn)
                {
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();

                    command.CommandText = "SELECT * FROM Concepts"; //"SELECT Concepts.ConceptName, Concepts.ConceptID, Synonyms.Synonym FROM Concepts,Synonyms WHERE (Concepts.ConceptName='" + tName + "')";// AND Synonyms.ConceptID = Concepts.ConceptID";// + termName +;//"SELECT Concepts.ConceptName, Concepts.ConceptID, Synonyms.Synonym FROM Concepts, Synonyms INNER JOIN Concepts ON Synonyms.ConceptID";// +",Synonyms";// " WHERE Concepts.ConceptID=Synonyms.ConceptID ";
                    
                    //"SELECT Concepts.ConceptName, Synonyms.Synonym FROM concepts INNER JOIN Synonyms ON Concepts.ConceptID = Synonyms.ConceptID"
                   SqlDataReader rdr1 = command.ExecuteReader();
                    while (rdr1.Read())
                    {
                        _term.Term = rdr1.GetString(1);
                        //_term.Term = rdr12.GetString(0);
                        _term.Description = rdr1.GetValue(0).ToString();
                        _term.Vocab = "Concepts";
                

                        vocab.Add(_term);

                    }
                    rdr1.Close();

                    conn.Close();
                }

            }

            else
            {
                using (conn)
                {
                    
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = "SELECT Term, Definition FROM " + VocabularyName + "CV";
                    conn.Open();
                    SqlDataReader rdr1 = command.ExecuteReader();

                    while (rdr1.Read())
                    {
                        VocabularyTermType _term = new VocabularyTermType();
                        _term.Term = rdr1.GetString(0);
                        _term.Description = rdr1.GetString(1);
                        _term.Vocab = VocabularyName;
                        _term.Synonyms = s;
                        vocab.Add(_term);
                    }
                    rdr1.Close();
                    conn.Close();
                }
            }

            return vocab;
        }

        private bool vocabExists(string Vocabulary)
        {
            SqlConnection conn1 = new SqlConnection(@connectionString1);
            bool exists = false;
            SqlCommand Command = conn1.CreateCommand();
            Command.CommandText = "SELECT VocabularyName FROM VocabularyDescription";
            conn1.Open();
            SqlDataReader rdr = Command.ExecuteReader();
            while(rdr.Read())
            {
                string compare = rdr.GetString(0);
                
                if(compare.Equals(Vocabulary))
                {
                    exists = true;
                }
            }
            rdr.Close();
            conn1.Close();

            return exists;
        }

        private bool termExists(string Vocabulary, string Term)
        {
            SqlConnection conn1 = new SqlConnection(@connectionString1);
            bool exists = false;
            SqlCommand Command = conn1.CreateCommand();
            conn1.Open();
            Command.CommandText = "SELECT Term FROM " + Vocabulary + "CV";
            SqlDataReader rdr = Command.ExecuteReader();
            while(rdr.Read())
            {
                string compare = rdr.GetString(0);

                if (compare.Equals(Term))
                {
                    exists = true;
                }
            }
            rdr.Close();
            conn1.Close();
            return exists;
        }

    }//end class HisVocabService

    class Test
    {
        static void Main()
        {

        }
    }

}
