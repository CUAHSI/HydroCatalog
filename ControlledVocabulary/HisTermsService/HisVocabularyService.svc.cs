﻿using System;
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
            //if (found == false)
            //{
            //    throw new NotFoundException("The vocabulary you have selected in is not in the database");
            //}
            
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
                    command.CommandText = "SELECT * FROM Concepts WHERE ConceptName='"+ TermName +"'";// +TermName; 
                    SqlDataReader rdr1 = command.ExecuteReader();
                    while (rdr1.Read())
                    {
                        _term.Term = rdr1.GetString(1);
                        _term.Description = rdr1.GetValue(0).ToString();
                        _term.Vocab = "Concepts";

                        id = Convert.ToInt32(_term.Description);
                    }
                    rdr1.Close();

                    _term = getLabels(_term, id);
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

        //this method retrieves the term's broader, narrower, prefLabel, altLabel, which probably only refers to the concepts at this moment
        private VocabularyTermType getLabels(VocabularyTermType _term, int id)
        {
            SqlConnection conn2 = new SqlConnection(@connectionString2);
            using(conn2)
            {
                conn2.Open();
                SqlCommand command2 = conn2.CreateCommand();

                command2.CommandText = "SELECT * FROM Synonyms WHERE ConceptID=" + id;
                SqlDataReader rdr2 = command2.ExecuteReader();
                Synonym syn = new Synonym();
                syn.altLabel = "none";
                while (rdr2.Read())
                {
                    syn.altLabel = rdr2.GetString(0);
                    //if (syn.altLabel.Equals(null))
                    //    syn.altLabel = "none";
                    _term.Synonyms.Add(syn);
                }
                rdr2.Close();
                SqlCommand command3 = conn2.CreateCommand();

                command3.CommandText = "SELECT * FROM Hierarchy WHERE ConceptID=" + id;
                SqlDataReader rdr3 = command3.ExecuteReader();
                int parentid = 0;
                while (rdr3.Read())
                {
                    parentid = (int)rdr3.GetValue(0);
                }
                rdr3.Close();

                SqlCommand command4 = conn2.CreateCommand();

                command4.CommandText = "SELECT * FROM Concepts WHERE ConceptID=" + parentid;
                SqlDataReader rdr4 = command4.ExecuteReader();
                string parentname = "none";
                LinkedConcept c = new LinkedConcept();

                while (rdr4.Read())
                {
                    parentname = rdr4.GetString(1);
                    c.cName = parentname;
                    _term.ParentConcepts.Add(c);
                }

                rdr4.Close();

                //get the narrower(child concept)
                SqlCommand command5 = conn2.CreateCommand();
                command5.CommandText = "SELECT Hierarchy.ConceptName FROM Concepts, Hierarchy WHERE Hierarchy.ParentID=" + id;
                SqlDataReader rdr5 = command5.ExecuteReader();
                LinkedConcept c2 = new LinkedConcept();
                string childname = "none";

                if (rdr5.Read())
                {
                    childname = rdr5.GetString(0);
                    c2.cName = childname;
                    _term.ChildConcepts.Add(c2);
                }
            rdr5.Close();
            }
            conn2.Close();
            return _term;

        }

        public VocabularyTermType[] getAllTerms()
        {
            List<String> vocabs = new List<String>();
            List<VocabularyTermType> vocabs2 = new List<VocabularyTermType>();
            int id = 0;
            List<VocabularyTermType> all_terms = new List<VocabularyTermType>();
            SqlConnection conn1 = new SqlConnection(@connectionString1);
            SqlConnection conn2 = new SqlConnection(@connectionString2);

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
                rdr1.Close();
                conn1.Close();
                //using (conn1)
                //{

                foreach (string aVocab in vocabs)
                {
                    if (aVocab != null) all_terms.AddRange(GetTermsFromDB(aVocab, conn1));
                }

                // }
                //conn1.Close();
            }


            //for the concepts, for some reason this doesn't work, but it works when you call get one vocabulary term, so i commentented it out for now
            //using (conn2)
            //{
            //    SqlCommand Command2 = conn2.CreateCommand();
            //    Command2.CommandText = "SELECT ConceptID, ConceptName FROM Concepts";
            //    conn2.Open();
            //    SqlDataReader rdr2 = Command2.ExecuteReader();
            //    VocabularyTermType t = new VocabularyTermType();
            //    while (rdr2.Read())
            //    {
            //        t.Term = rdr2.GetString(1);
            //        t.Description = rdr2.GetValue(0).ToString();
            //        vocabs2.Add(t);
            //        //vocabs2.Add((string)rdr2["ConceptName"]);
            //        //id.Add((int)rdr2["ConceptID"]);

            //    }
            //    //int id = 0;
            //    rdr2.Close();
            //    conn2.Close();

            //    using (conn2)
            //    {
            //        VocabularyTermType the_term = new VocabularyTermType();
                   
            //        foreach (VocabularyTermType tm in vocabs2)
            //        {
            //            id = Convert.ToInt32(tm.Description);
            //            //if (tm != null)
            //            the_term = getLabels(t, id);
            //            all_terms.Add(the_term);
            //        }

            //    }

                
            //    //conn2.Close();

            //}

            return all_terms.ToArray();

        }

        [WebGet(UriTemplate = "test/")]
        public string Test()
        {
            return "test";

        }

        //this might not be necessary as we have structured the term to be in skos format in the domain model, can be altered for more configuration
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

        //get vocabulary terms from the database
        private List<VocabularyTermType> GetTermsFromDB(string VocabularyName, SqlConnection conn)
        {
            List<VocabularyTermType> vocab = new List<VocabularyTermType>();
            Synonym syn = new Synonym();
       
            List<Synonym> s = new List<Synonym>();
            SqlConnection conn1 = new SqlConnection(@connectionString1);
            conn = conn1;
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

            return vocab;
        }

        //check if the vocabulary exists in the db
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

        //validation check for the vocabulary term, might not be necessary depending how the vocabulary is being accessed
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
