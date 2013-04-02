var ddlVocabulary = null; // DropDownList for vocabulary
var ddlTerm = null; // DropDownList for term
var hdfVocabulary = null; // Use to save vocabulary DropDownList options and restore it when page is rendering
var hdfTerm = null; ; // Use to save term DropDownList options and restore it when page is rendering
var hdfVocabularySelectValue = null; // Use to save the vocbulary DropDownList seleted optionsand restore it when page is rendering
var hdfTermSelectValue = null; // Use to save the term DropDownList seleted optionsand restore it when page is rendering

// Instance XMLHttpRequest
window.onload = function loadXMLHttp() {
    if (window.XMLHttpRequest) {
        xmlHttp = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {
        try {
            xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch (e)
        { }
    }

    ddlVocabulary = document.getElementById('ddlVocabulary');
    ddlTerm = document.getElementById('ddlTerm');
    hdfVocabulary = document.getElementById('hdfVocabulary');
    hdfTerm = document.getElementById('hdfTerm');
    hdfVocabularySelectValue = document.getElementById('hdfVocabularySelectValue');
    hdfTermSelectValue = document.getElementById('hdfTermSelectValue');
    ShowFirstOption(ddlVocabulary); // Add "Please Select a xxxx" option in the top of country DropDownList 
    RestoreDropdownList(); // Restore dropdownlist when page is rendering

}

// Restore dropdownlist when page is rendering
function RestoreDropdownlist()
{
    //restore term dropdownlist
    if (hdfTerm.value != "") 
    {
        addOption(ddlTerm, hdfTerm.value);
        ddlTerm.selectedIndex = hdfTermSelectValue.value;
    }
    ddlVocabulary.selectedIndex = hdfVocabularySelectValue.value;
}

// Remove term dropdownlist option when vocabulary dropdownlist selected option is changed.
function ddlVocabularyOnChange()
{
    ReomveOptionsFromDDL(ddlTerm);
    hdfVocabularySelectValue.value = ddlVocabulary.selectedIndex;
    var url = '';
    
}


// Enable or diasble submit button
function EnableSubmitButton(TrueOrFalse) 
{
    var obj = document.getElementById('btnSubmit');
    obj.disabled = TrueOrFalse;
}