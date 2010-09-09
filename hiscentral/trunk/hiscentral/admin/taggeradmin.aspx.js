var mWidth = pageWidth();
var mHeight = pageHeight();
var activeVarID=null;
var activeConceptID=null;
var siblingConcept=null;
var originalConcept=null;


function pageWidth() {return window.innerWidth != null? window.innerWidth: document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth:document.body != null? document.body.clientWidth:null;}
function pageHeight() {return window.innerHeight != null? window.innerHeight: document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight:document.body != null? document.body.clientHeight:null;}



function GetApplet(){

document.getElementById("appletSection").innerHTML='<input type="image" src="but-on.jpg" height="0px" width="0px" border="0px" padding="0px" name="refreshApplet"/><applet name="TreeApplet" codebase="http://water.sdsc.edu:7788/vizserver/applets" code="STApplet.class" archive = "StarTree30c.jar" WIDTH="'+mWidth+' px" HEIGHT="'+(mHeight-200)+' px" MAYSCRIPT><PARAM="cache_option" VALUE="No"><param name="dataset" value="tree.stc"><param name="data_streaming" value="TRUE"><param name="invoke_double_click" value="FALSE"><param name="Search_button" value="false"><param name="Help_button" value="false"><param name="Home_button" value="false"><param name="Show_PlusMinus" value="true"><param name="Display_panel" value="BOTTOM"></applet>';
Tagger.TaggerService.CheckIfUnique(document.form1.textfield5.value);
}

function AddPendingMappingToList(varid){
activeVarID = varid;
Tagger.TaggerService.GetPendingMappingInfo(varid, onMapInfoComplete);
}

function onMapInfoComplete(mapObject){
document.TreeApplet.STSetSpot(mapObject.ConceptID,'u');
document.form1.textfield.value=mapObject.VariableName;
document.form1.textfield2.value=mapObject.ConceptID;
siblingConcept = mapObject.ConceptID;
originalConcept = mapObject.ConceptID;
document.form1.textfield6.value=mapObject.Suggestion;
document.getElementById("createConceptPanel").style.visibility="visible";
//document.getElementById("suggestpanel").innerHTML= '<b>Create New Concept:</b><br /><input type="text" name="textfield3" value="'+mapObject.Suggestion+'"><br/><input type="submit" name="SuggestButton" value="Map!" onclick="MapAndSuggest();return false;" id="Submit1" style="width: 42px;position:relative;top:5px;" />';
}

function AddConceptToMenu(conceptID){
activeConceptID=conceptID;
document.form1.textfield2.value=conceptID;
if (document.form1.textfield.value!=""){
if (conceptID.indexOf('_other') > -1){
document.getElementById("createConceptPanel").style.visibility="visible";
siblingConcept = conceptID;
}else{
document.getElementById("createConceptPanel").style.visibility="hidden";
document.getElementById("suggestpanel").innerHTML= '<input type="submit" name="MapButton" value="Map!" onclick="MapAndRemovePendingStatus();return false;" id="cartSubmit" style="width: 42px;position:relative;top:0px;" />'
}
}
}


function MapAndRemovePendingStatus(){
//updated 1
Tagger.TaggerService.MapAndRemovePendingStatus(activeVarID,activeConceptID,originalConcept,document.form1.uem.value, onMappingComplete);
}

function CreateNewConcept(){

var newConceptID = document.form1.textfield5.value;
var firstChar = newConceptID.substring(0,1);
var beginsWithNumber = (firstChar==0 ||firstChar==1 || firstChar==2 || firstChar==3 || firstChar==4 || firstChar==5 || firstChar==6 || firstChar==7 || firstChar==8 || firstChar==9); 
var containsUnwantedCharacters = (newConceptID.indexOf("@")>-1 || newConceptID.indexOf("~")>-1 || newConceptID.indexOf("/")>-1 || newConceptID.indexOf("^")>-1 || newConceptID.indexOf(",")>-1 || newConceptID.indexOf(".")>-1 || newConceptID.indexOf(" ")>-1 || newConceptID.indexOf("#")>-1 || newConceptID.indexOf("'")>-1 || newConceptID.indexOf("!")>-1 || newConceptID.indexOf("*")>-1 || newConceptID.indexOf("&")>-1 || newConceptID.indexOf("%")>-1);
if (!beginsWithNumber && !containsUnwantedCharacters){
Tagger.TaggerService.CheckIfUnique(document.form1.textfield5.value, CheckIfUniqueComplete);
}else{
alert('Incorrect syntax for ConceptCode. ConceptCode shouldn\'t start with a number. It can not contain spaces, symbols and punctuation except - and _ ');
}
}

function CheckIfUniqueComplete(isUnique){
if (isUnique){

document.form1.conceptID.value = document.form1.textfield5.value;
activeConceptID = document.form1.textfield5.value;
document.form1.parentID.value = document.form1.textfield2.value;
document.form1.conceptLabel.value = document.form1.textfield6.value;
__doPostBack('Button2','');
MapAndRemovePendingStatus();
setTimeout(alert(document.form1.message.value),3800);
}else{
alert('There already exists a concept with the provided concept code. Please try a different one');
}
}

function onCreateConceptComplete(){
__doPostBack('refreshApplet','');

}

function MapToOntology(){
//update 3
Tagger.TaggerService.FinalizeMapping(activeVarID,activeConceptID, document.form1.uem.value, onMappingComplete);
}

function onMappingComplete(){
__doPostBack('Button1','');
//__doPostBack('refreshApplet','');
}

function MapAndSuggest(){
//update 2
Tagger.TaggerService.MapAndSuggest(activeVarID,activeConceptID,document.form1.textfield3.value, document.form1.uem.value, onMappingComplete);
}


function STmouseOver(urlandhierarchy){}
function STsingleClick(urlandhierarchy){}
function STdoubleClick(urlandhierarchy){
var locArray = urlandhierarchy.split("\t");
if (locArray[0] != "null"){
AddConceptToMenu(locArray[0]);
//var len = locArray.length;
//alert(locArray[0]+' '+locArray[len-2]);
//document.form1.parentLabel.value = locArray[len-2];
//document.form1.textfield2.value=locArray[0];
}else{
alert('Please Select Leaf Nodes');
}
}


function searchTree(){
document.TreeApplet.STSetSpot(document.form1.textfield4.value,'u');
return false;


}




