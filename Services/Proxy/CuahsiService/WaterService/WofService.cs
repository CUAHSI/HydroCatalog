using System;
using System.Collections.Generic;
using System.Text;

namespace cuahsi.his.WaterService.Service
{
    namespace BaseService
    {
        public abstract class WofService
        {

            public WofService()
            {

            }

            #region properties

            protected string serviceNameField;
            protected string siteVocabularyField;
            protected string variableVocabularyField;

            public abstract string WebserviceVersion
            {
                get;
            }

            /// <summary>
            /// Descriptive name of the service. 
            /// This should be brief, so that it can be shown in a menu
            /// </summary>
            public string ServiceName
            {
                get { return serviceNameField; }
                set { serviceNameField = value; }

            }

            /// <summary>
            /// brief vocabulary reference for the service.
            /// This will be the prefix used for all requests. location references
            /// (e.g getSiteInfo('PREFIX:SiteCode'), 
            /// GetValues('PREFIX:SiteCode','PREFIX:VariableCode',BeginDate,EndDate)
            /// Formerly called the "Network"
            /// </summary>
            public string SiteVocabulary
            {
                get { return siteVocabularyField; }
                set { siteVocabularyField = value; }
            }

            /// <summary>
            /// brief vocabulary reference for variable
            /// This will be the prefix for all variable
            ///        /// (e.g getVariables('PREFIX:VariableCode'), 
            /// GetValues('PREFIX:SiteCode','PREFIX:VariableCode',BeginDate,EndDate)
            /// </summary>
            public string VariableVocabulary
            {
                get { return variableVocabularyField; }
                set { variableVocabularyField = value; }
            }


        }
        namespace v1_0
        {

            public class WofService : BaseService.WofService
            {
                public WofService()
                    : base()
                {

                }



                public override string WebserviceVersion
                {
                    get { return "1.0"; }
                }

            #endregion


            }


        }
        namespace v1_1
        {

            public class WofService : BaseService.WofService
            {
                public WofService()
                    : base()
                {

                }



                public override string WebserviceVersion
                {
                    get { return "1.1"; }
                }




            }
        }
    }



}