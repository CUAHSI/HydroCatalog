using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HisTermsService.Selection
{
    public partial class VocabularySelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client onclick event for submit button
            btnSubmit.Attributes.Add("onclick", "SaveSelectedData();");

        }

        //Bind VocabularyDescription dropdownlist
        public void BindddlVocabulary()
        {
          //  HisVocabularyService.getVocabularies();   
        }
    }


}
