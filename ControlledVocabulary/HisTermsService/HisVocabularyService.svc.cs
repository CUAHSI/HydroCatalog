using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Web;
using System.Data.SqlClient;

namespace cuahsi.his.vocabservice
{

    public class HisVocabularyService : IVocabularyService
    {
        private VocabulariesList vocabularies = new VocabulariesList();
        VocabularyTermType select_term = null;

        HisVocabularyService()
        {
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
            // TODO: see if vocabulary exists. Get the desription

            v.Name = VocabularyName;
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterVocabualaryV11"].ConnectionString))
            {
                v.VocabularyTerms.AddRange(GetTermsFromDB(VocabularyName, thisConnection)); ;

                //SqlCommand Command1 = thisConnection.CreateCommand();

                //Command1.CommandText = "SELECT Term, Definition FROM " + VocabularyName + "CV";
                //thisConnection.Open();
                //SqlDataReader rdr1 = Command1.ExecuteReader();

                //while(rdr1.Read())
                //{

                //    VocabularyTermType t = new VocabularyTermType();
                //    v.Name = VocabularyName;
                //    t.Term = rdr1.GetString(0);
                //    t.Description = rdr1.GetString(1);
                //    found = true;
                //    v.VocabularyTerms.Add(t);   
                //}

                //if (found == false)
                //{
                //    //enter invalid vocabulary, throw error?
                //    //maybe throw a custom exception 
                //}

                //return v.VocabularyTerms; //return the vocabulary that the user selected
            }//end using()
            return v;
        }//end getVocabulary()


        /**
         * getVocabularyTerm() - returns the specified term based on the specified vocabulary
         * 
         * 
         **/
        public VocabularyTermType getVocabularyTerm(string VocabularyName, string TermName)
        {
            Vocabulary _vocab = new Vocabulary();

            bool found = false;
            //TODO Validate that vocab exists

            using (SqlConnection thisConnection = new SqlConnection(@"Data Source=disrupter.sdsc.edu,1433; database=HisMasterVocabTest; User=webservice; Password=webservice;"))
            {
                var terms = GetTermsFromDB(VocabularyName, thisConnection);
                var term = from aTerm in terms where aTerm.Term == TermName select aTerm;
                return term.First();
                //thisConnection.Open();
                //SqlCommand Command1 = thisConnection.CreateCommand();

                //Command1.CommandText = "SELECT Term, Definition FROM " + VocabularyName + "CV";
                //Command1.CommandText += " WHERE Term = @term";
                //Command1.Parameters.AddWithValue("term", TermName);

                //SqlDataReader rdr1 = Command1.ExecuteReader();

                //while (rdr1.Read())
                //{
                //    VocabularyTermType _term = new VocabularyTermType();
                //    _term.Term = rdr1.GetString(0);
                //    _term.Description = rdr1.GetString(1);
                //    _term.Vocab = VocabularyName;
                //    (_vocab.VocabularyTerms).Add(_term);
                //}
                //rdr1.Close();

                //thisConnection.Close();

                //foreach (VocabularyTermType vt in _vocab.VocabularyTerms)
                //{
                //    if (TermName.Equals(vt.Term))
                //    {
                //        found = true;
                //        select_term = vt;
                //    }
                //}

                //if (found == false)
                //{
                //    //enter invalid vocabulary term, throw error?
                //    //maybe throw a custom exception 
                //}

                //return select_term;
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

                    //conn2.Open();
                    //SqlCommand Command2 = conn2.CreateCommand();

                    //foreach (string aVocab in vocabs)
                    //{
                    //    Command2.CommandText = "SELECT Term, Definition FROM " + aVocab + "CV";
                    //    SqlDataReader rdr2 = Command2.ExecuteReader();

                    //    while (rdr2.Read())
                    //    {
                    //        VocabularyTermType the_term = new VocabularyTermType();
                    //        the_term.Vocab = aVocab;
                    //        the_term.Term = rdr2.GetString(0);
                    //        the_term.Description = rdr2.GetString(1);
                    //        all_terms.Add(the_term);
                    //    }

                    //    rdr2.Close();
                    //}
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

    }//end class HisVocabService

    class Test
    {
        static void Main()
        {

        }
    }

}
