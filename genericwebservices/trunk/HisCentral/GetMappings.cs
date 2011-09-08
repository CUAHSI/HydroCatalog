using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using cuahsi.hiscentral.cuahsi.hiscentral;

namespace HisCentral
{
    /// <summary>
    /// This provides a way to convert variable codes to concept codes.
    /// This caches the Mappings, so if you change a mapping in HIS central,
    /// you will not see the change until this object is reloaded.
    /// </summary>
    public static class GetMappings
    {
        private static cuahsi.hiscentral.cuahsi.hiscentral.hiscentral svc;
        private static Boolean _loaded = false;
        private static Boolean _loading = false;
        private static Dictionary<int, string> _ontologyList = new Dictionary<int, string>();

        private static Dictionary<string, MappedVariable> _mappedVariables = new Dictionary<string, MappedVariable>();

         static GetMappings()
        {
           
               
        //}

        //private static void loadMappings()
        //{
            int i = 0;
            while (_loading)
            {
                i++;
                if (i > 60) throw new TimeoutException("HIS central did not return in a reasonable time");
                Thread.Sleep(500);
            }
            lock (_ontologyList)
            {
                if (Loaded == false)
                {
                    _loading = true;
                    svc = new cuahsi.hiscentral.cuahsi.hiscentral.hiscentral();
                    Dictionary<int, string> nodes = new Dictionary<int, string>();
                    svc.getOntologyTreeCompleted += (sndr, evt) =>
                                                        {
                                                            var tree = evt.Result;
                                                            tree2List(tree, nodes);
                                                            _ontologyList = nodes;



                                                            Dictionary<string, MappedVariable> mvnodes =
                                                                new Dictionary<string, MappedVariable>();
                                                            var mvtree = svc.GetMappedVariables2(String.Empty,
                                                                                                 String.Empty);
                                                            foreach (var mappedVariable in mvtree)
                                                            {
                                                                if (!String.IsNullOrEmpty(mappedVariable.conceptCode)
                                                                    &&
                                                                    !String.IsNullOrEmpty(mappedVariable.variableCode))
                                                                {
                                                                    try
                                                                    {
                                                                        mvnodes.Add(mappedVariable.variableCode,
                                                                                    mappedVariable);
                                                                    }
                                                                    catch
                                                                    {
                                                                        //
                                                                    }
                                                                }
                                                            }
                                                            _mappedVariables = mvnodes;
                                                            _loaded = true;
                                                            _loading = false;
                                                        };
                    svc.getOntologyTreeAsync(null);
                }
            }
        }

        public static Boolean Loaded
        {
            get { return _loaded; }
        }
        
        public static Dictionary<int, string> OntologyList
        {
         get
         {
             while (!Loaded) { Thread.Sleep(100); }
            // if (!Loaded) loadMappings();
             //{
             //    Dictionary<int, string> nodes = new Dictionary<int, string>();
             //    var tree = svc.getOntologyTree(null);
             //    tree2List(tree, nodes);
             //    _ontologyList = nodes;
                 

             //} 
             return _ontologyList;

         }
            set { _ontologyList = value; }
        }

        private static void tree2List(OntologyNode node,  Dictionary<int, string> nodes)
        {
            
            
            if (node == null) return;
            
            if (node.childNodes != null)
            {
                foreach (OntologyNode child in node.childNodes)
                {
                     tree2List(child, nodes);
                }
            }
            if (node.conceptid != null && !String.IsNullOrEmpty(node.keyword))
            {
              try
              {
                  nodes.Add(node.conceptid, node.keyword.Trim());
              }
                catch
                {
                    // log
                }
            }
           
        }
        public  static Dictionary<string, MappedVariable> MappedVariables
        {
            get
            {

              //  if (!Loaded) loadMappings(); 
                while (!Loaded) { Thread.Sleep(100); }
                if (_mappedVariables == null || _mappedVariables.Count == 0)
                {
                    Dictionary<string, MappedVariable> nodes = new Dictionary<string, MappedVariable>();
                    var tree = svc.GetMappedVariables2(String.Empty,String.Empty);
                    foreach (var mappedVariable in tree)
                    {
                       if ( !String.IsNullOrEmpty(mappedVariable.conceptCode) 
                           && !String.IsNullOrEmpty(mappedVariable.variableCode) )
                        {
                           try
                           {
                               nodes.Add(mappedVariable.variableCode, mappedVariable);
                           } catch
                           {
                               //
                           }
                        }
                    }
                    _mappedVariables = nodes;


                }
                return _mappedVariables;

            }
            set { _mappedVariables = value; }
        }
        public static String GetConceptForVariable(String variableCode)
        {
           // if (!Loaded) loadMappings();
            while (!Loaded){Thread.Sleep(100);}
            var mv = MappedVariables;
            if (mv.Keys.Contains(variableCode))
            {
                if (MappedVariables[variableCode] != null)
                {
                    int cCode = -1;

                    if (Int32.TryParse(MappedVariables[variableCode].conceptCode, out cCode))
                    {
                        string s;
                        if (!String.IsNullOrEmpty(OntologyList[cCode]))
                        {
                            return OntologyList[cCode].Trim();
                        }

                    }

                }
            }
            return null;
        }
    }
}
