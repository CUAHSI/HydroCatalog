using System;
using NUnit.Framework;
using cuahsi.HisVocabLib;
using cuahsi.his.vocabservice;


namespace HisVocabLibTest
{
    [TestFixture]
    public class TestTerm
    {
        [Test]
        public void TestVocabTerm()
        {
            Console.WriteLine("Test VocabularyTerm: ");
            var t = new VocabularyTermType{Vocab = "test1", Term = "Test2", Description = "test3"};
            Assert.IsNotNullOrEmpty("Term Empty",t.Term);
            Assert.IsNotNullOrEmpty(t.Description);
            Assert.IsNotNullOrEmpty(t.Vocab);

            Assert.AreEqual(t.Term, "Test2", "they are equal");

            HisVocabularyService his = new HisVocabularyService();

            var t1 = new VocabularyTermType { Term = "lt", Description = "less than", Vocab = "CensorCodeSample" };
            var t2 = new VocabularyTermType { Term = "gt", Description = "greater than", Vocab = "CensorCodeSample" };
            var t3 = new VocabularyTermType { Term = "nc", Description = "not censored", Vocab = "CensorCodeSample" };
            var t4 = new VocabularyTermType { Term = "nd", Description = "non-detect", Vocab = "CensorCodeSample" };
            var t5 = new VocabularyTermType { Term = "pnq", Description = "present but not quantified", Vocab = "CensorCodeSample" };
            var voc1 = new Vocabulary { Name = "CensorCodeSample", Description = "incorrect", VocabularyTerms = { t1, t2, t3, t4, t5 } };

            Assert.AreEqual("lt", t1.Term);
            Assert.AreEqual("gt", t2.Term);
            Assert.AreEqual("not censored", t3.Description);
            Assert.AreEqual("non-detect", t4.Description);
            Assert.AreEqual("CensorCodeSample", t5.Vocab);

            Assert.AreNotEqual(t1.Term, t2.Term);
            Assert.AreNotEqual("nc", t5.Term);

            foreach(VocabularyTermType the_term in voc1.VocabularyTerms)
            {
                Assert.AreEqual("CensorCodeSample", the_term.Vocab);
                Assert.AreEqual(voc1.Name, t3.Vocab);
            }

            var term1 = new VocabularyTermType { Term = "Unknown", Description = "The data type is unknown", Vocab = "DataTypeSample" };
            var term2 = new VocabularyTermType { Term = "Median", Description = "The values represent the median over a time interval, such as daily median discharge or daily median temperature.", Vocab = "DataTypeSample" };
            var term3 = new VocabularyTermType { Term = "Variance", Description = "The values represent the variance of a set of observations made over a time interval.  Variance computed using the unbiased formula SUM((Xi-mean)^2)/(n-1) are preferred.  The specific formula used to compute variance can be noted in the methods description.", Vocab = "DataTypeSample" };
            var term4 = new VocabularyTermType { Term = "Best Easy Systematic Estimator", Description = "Best Easy Systematic Estimator BES = (Q1 +2Q2 +Q3)/4.  Q1, Q2, and Q3 are first, second, and third quartiles. See Woodcock, F. and Engel, C., 2005: Operational Consensus Forecasts.Weather and Forecasting, 20, 101-111. (http://www.bom.gov.au/nmoc/bulletins/60/article_by_Woodcock_in_Weather_and_Forecasting.pdf) and Wonnacott, T. H., and R. J. Wonnacott, 1972: Introductory Statistics. Wiley, 510 pp.", Vocab = "DataTypeSample" };
            var term5 = new VocabularyTermType { Term = "StandardDeviation", Description = "The values represent the standard deviation of a set of observations made over a time interval. Standard deviation computed using the unbiased formula SQRT(SUM((Xi-mean)^2)/(n-1)) are preferred. The specific formula used to compute variance can be noted in the methods description.", Vocab = "DataTypeSample" };
            var voc2 = new Vocabulary { Name = "DataTypeSample", Description = "something", VocabularyTerms = { term1, term2, term3, term4, term5 } };

            foreach(VocabularyTermType j in voc2.VocabularyTerms)
            {
                Assert.AreEqual(j.Vocab, voc2.Name);
                foreach(VocabularyTermType k in voc1.VocabularyTerms)
                {
                    Assert.AreNotEqual(j.Vocab, k.Vocab);
                    Assert.AreNotEqual(j, k);
                }
            }
        }

        [Test]
        public void TestVocabulary()
        {
            Console.WriteLine("Test Vocabulary: ");
            HisVocabularyService his = new HisVocabularyService();
            /*
             * Using the CensorCodeCV to test Vocabulary Structure
             */
            var t1 = new VocabularyTermType{ Term = "lt", Description = "less than", Vocab = "CensorCodeSample" };
            var t2 = new VocabularyTermType { Term = "gt", Description = "greater than", Vocab = "CensorCodeSample" };
            var t3 = new VocabularyTermType { Term = "nc", Description = "not censored", Vocab = "CensorCodeSample" };
            var t4 = new VocabularyTermType { Term = "nd", Description = "non-detect", Vocab = "CensorCodeSample" };
            var t5 = new VocabularyTermType { Term = "pnq", Description = "present but not quantified", Vocab = "CensorCodeSample" };
            var voc = new Vocabulary{ Name = "CensorCodeSample", Description = "incorrect", VocabularyTerms = { t1, t2, t3, t4, t5 } };

            VocabularyTermType [] termsSample = voc.VocabularyTerms.ToArray();
            VocabularyTermType[] terms = his.getVocabulary("CensorCode").VocabularyTerms.ToArray();
            
            for (int i = 0; i < terms.Length; i++)
            {
                Assert.AreEqual(terms[i].Term, termsSample[i].Term);
                Assert.AreEqual(terms[i].Description, termsSample[i].Description);
            }

            Assert.IsNotNullOrEmpty(voc.Name);
            Assert.IsNotNullOrEmpty(voc.Description);
            foreach(VocabularyTermType t in terms)
            {
                Assert.IsNotNullOrEmpty(t.Term);
                Assert.IsNotNullOrEmpty(t.Description);
                Assert.AreEqual("CensorCode", t.Vocab);
            }

            Console.WriteLine("Vocab Description: " + voc.Description);

        }
        //test

        [Test]
        public void testGetVocabularies()
        {
            Console.WriteLine("Test: getVocabularies()\n\t\t--this method should return all the vocabularies with a given description\n" );
            HisVocabularyService his = new HisVocabularyService();
            Vocabulary[] v;
            v = his.getVocabularies();
            foreach(Vocabulary vocab in v)
            {
                Console.WriteLine("Name: " + vocab.Name + "\nDescription: " + vocab.Description + "\n");
            }
        }

        [Test]
        public void testGetVocabulary()
        {
            Console.WriteLine("Test : getVocabulary()");
            HisVocabularyService his = new HisVocabularyService();
            Vocabulary v1, v2;
            v1 = his.getVocabulary("SampleType");
            string[] terms = {"Unknown", "No Sample", "FD", "FF", "FL", "LF", "GW", "PB", "PD", "PE", "PI", "PW", "RE", "SE", "SR", 
                                 "SS", "SW", "TE", "TI", "TW", "VE", "VI", "VW", "Grab", "Automated", "meteorological" };
            int i = 0;
            foreach(VocabularyTermType vt in v1.VocabularyTerms)
            {
                Assert.AreEqual(vt.Term, terms[i]);
                i++;
            }

            v2 = his.getVocabulary("DataType");

            foreach (VocabularyTermType vt in v2.VocabularyTerms)
            {
                foreach (VocabularyTermType vtt in v1.VocabularyTerms)
                {
                    Assert.AreNotEqual(vt, vtt);
                }
            }
      }

        [Test]
        public void testGetVocabularyTerm()
        {
            Console.WriteLine("Test: getVocabulary()" );
            HisVocabularyService his = new HisVocabularyService();
            VocabularyTermType term1, term2;

            term1 = his.getVocabularyTerm("SampleType", "TI");
         
            Assert.AreEqual(term1.Term, "TI");
            Assert.AreEqual(term1.Description, "Throughfall Increment");
            Assert.AreEqual(term1.Vocab, "SampleType");

            term2 = his.getVocabularyTerm("SampleType", "Unknown");
          
            Assert.AreEqual(term2.Vocab, "SampleType");
            Assert.AreNotEqual(term1, term2);
        }

        [Test]
        public void TestExceptions()
        {
            Console.WriteLine("Testing Exceptions: \n");
            HisVocabularyService his = new HisVocabularyService();
            //his.getVocabularies();
            try
            {
                his.getVocabularyTerm("NonExistentVocab", "lt");
                //his.getVocabularyTerm("CensorCode", "incorrect_term");


            }
            catch( Exception e )
            {
                Console.WriteLine("Test with incorrect vocabulary: " + e.Message);
                Assert.Pass( "Unexpected exception of type {0} caught: \n{1}", e.GetType(), e.Message);
            }

            finally
            {
                try
                {
                    HisVocabularyService his2 = new HisVocabularyService();
                    his2.getVocabularyTerm("CensorCode", "incorrect_term");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Test with incorrect vocabulary term: " + ex.Message);
                    Assert.Pass("Unexpected exception of type {0} caught: \n{1}", ex.GetType(), ex.Message);
                }
                finally
                {

                    try
                    {
                        his.getVocabulary("Incorrect_Vocabulary");
                    }
                    catch (Exception e)
                    {
                        Assert.Pass("Unexpected exception of type {0} caught: \n{1}", e.GetType(), e.Message);
                    }

                }
            }
        }//end TestExceptions()

        [Test]
        public void TestSkos()
        {
            HisVocabularyService his = new HisVocabularyService();

            string result1, result2;

            result1 = his.GetTermAsToSkos("CensorCode", "lt");
            result2 = his.GetTermAsToSkos("SampleType", "Unknown");

            Console.WriteLine(result1 + result2);
        }
    }
}
