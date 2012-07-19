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
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class HisVocabularyService : IVocabularyService, IVocabularyRest
    {
        private VocabulariesList vocabularies = new VocabulariesList();
        VocabularyTermType select_term = null;

        public HisVocabularyService()
        {
            getVocabularies();
            //vocabularies = new Vocabularies();
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
            List<Vocabulary> all_vocab = new List<Vocabulary>();

            using (SqlConnection thisConnection = new SqlConnection(@"Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;"))
            {
                SqlCommand Command1 = thisConnection.CreateCommand();

                Command1.CommandText = "SELECT VocabularyName, VocabularyDescription FROM VocabularyDescription";
                thisConnection.Open();
                SqlDataReader rdr1 = Command1.ExecuteReader();

                while (rdr1.Read())
                {
                    Vocabulary v = new Vocabulary();
                    v.Name = rdr1.GetString(0);
                    v.Description = rdr1.GetString(1);
                    vocabularies.VocabularyList.Add(v);
                    all_vocab.Add(v);
                }
                return all_vocab.ToArray();
            }
        }

        /*
         * getVocabulary() - this method returns the vocabulary that the client selects, if it doesnt exist should throw error
         * 
         * @params: String
         * @returns: Vocabulary
         * 
         * */
        public Vocabulary getVocabulary(string VocabularyName)
        {
            bool found = false;

            Vocabulary v = new Vocabulary();
            found = vocabExists(VocabularyName);
            //see if vocabulary exists. Get the desription
            if (found == false)
            {
                throw new NotFoundException("The vocabulary you have selected in is not in the database");
            }
            
            v.Name = VocabularyName;
            /*using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterVocabualaryV11"].ConnectionString))
            {*/
            using (SqlConnection thisConnection = new SqlConnection(@"Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;"))
            {
                v.VocabularyTerms.AddRange(GetTermsFromDB(VocabularyName, thisConnection));

            }//end using()
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
            bool found = false;
            
            //Validate that vocab exists
            found = vocabExists(VocabularyName);
            if(found == false)
            {
                throw new NotFoundException("The vocabulary you have selected in is not in the database");
            }

            found = termExists(VocabularyName, TermName);
            if (found == false)
            {
                throw new NotFoundException("The term you have selected in is not in the database");
            }

            using (SqlConnection thisConnection = new SqlConnection(@"Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;"))
            {
                var terms = GetTermsFromDB(VocabularyName, thisConnection);
                var term = from aTerm in terms where aTerm.Term == TermName select aTerm;
                return term.First();
            }
        }

        public VocabularyTermType[] getAllTerms()
        {
            List<String> vocabs = new List<String>();
            List<VocabularyTermType> all_terms = new List<VocabularyTermType>();


            using (SqlConnection thisConnection = new SqlConnection(@"Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;"))
            {

                SqlCommand Command1 = thisConnection.CreateCommand();
                Command1.CommandText = "SELECT VocabularyName FROM VocabularyDescription";
                thisConnection.Open();
                SqlDataReader rdr1 = Command1.ExecuteReader();

                while (rdr1.Read())
                {
                    vocabs.Add((string)rdr1["VocabularyName"]);
                }

                using (SqlConnection conn2 = new SqlConnection(@"Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;"))
                {
                    foreach (string aVocab in vocabs)
                    {
                        all_terms.AddRange(GetTermsFromDB(aVocab, conn2));

                    }

                }

                rdr1.Close();
                thisConnection.Close();
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
            //Vocabulary = getVocabulary(Vocabulary).Name;
            Term = getVocabularyTerm(Vocabulary, Term).Term;

            skos_output = String.Format("\n\n\t<skos:concept rdf:about=\"urn:cuahsi.org/vocabulary/{0}#{1}\"\n" +
                                        "\t<skos:prefLabel xml:lang=\"en\">{2}</skos:prefLabel>\n" +
                                        "\t\t<skos:altLabel xml:lang=\"en\">{3}</skos:AltLabel>\">\n" +
                                        "\t\t<skos:definition>{4}</skos:defnition></skos:concept>", Vocabulary, Term, Term, Term, getVocabularyTerm(Vocabulary, Term).Description);
            //Console.WriteLine(skos_output);
            return skos_output;
        }
        //output vocabulary as skos

        //output term as skos
        private List<VocabularyTermType> GetTermsFromDB(string VocabularyName, SqlConnection conn)
        {
            List<VocabularyTermType> vocab = new List<VocabularyTermType>();
            SqlCommand Command2 = conn.CreateCommand();


            Command2.CommandText = "SELECT Term, Definition FROM " + VocabularyName + "CV";
            conn.Open();
            SqlDataReader rdr1 = Command2.ExecuteReader();
            while (rdr1.Read())
            {
                VocabularyTermType _term = new VocabularyTermType();
                _term.Term = rdr1.GetString(0);
                _term.Description = rdr1.GetString(1);
                _term.Vocab = VocabularyName;
                vocab.Add(_term);
            }
            rdr1.Close();
            conn.Close();
            return vocab;
        }

        private bool vocabExists(string Vocabulary)
        {
            bool exists = false;
            SqlConnection conn = new SqlConnection(@"Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;");
            
            SqlCommand Command = conn.CreateCommand();
            Command.CommandText = "SELECT VocabularyName FROM VocabularyDescription";
            conn.Open();
            SqlDataReader rdr = Command.ExecuteReader();
            while(rdr.Read())
            {
                string compare = rdr.GetString(0);
                
                if(compare.Equals(Vocabulary))
                {
                    exists = true;
                }
            }

            return exists;
        }

        private bool termExists(string Vocabulary, string Term)
        {
            bool exists = false;
            SqlConnection conn = new SqlConnection(@"Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;");

            SqlCommand Command = conn.CreateCommand();
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
