using System;
using System.Collections.Generic;
using System.Text;
using com.hp.hpl.jena.ontology;
using com.hp.hpl.jena.rdf.model;


  public class OntologyLoader
  {
    //private OntModel ontology;
    public static OntModel loadOntology(string ontologyURL)
    {
      //OntModel ontology = new OntModel();
      OntModel ontology = ModelFactory.createOntologyModel();
      ontology.read(ontologyURL);
      return ontology;

      // return m;

    }
    public OntologyLoader()
    {
   
    }

  }
