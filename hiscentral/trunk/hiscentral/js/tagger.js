var mWidth = pageWidth();
var mHeight = pageHeight();
var activeVarID=null;
var activeConceptID = null;
var activeConceptKeyword = null;


function pageWidth() {return window.innerWidth != null? window.innerWidth: document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth:document.body != null? document.body.clientWidth:null;}
function pageHeight() {return window.innerHeight != null? window.innerHeight: document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight:document.body != null? document.body.clientHeight:null;}

function GetApplet2(){}

function GetApplet(){
   
//document.getElementById("appletSection").innerHTML='<applet name="TreeApplet" codebase="http://water.sdsc.edu:7788/vizserver/applets" code="STApplet.class" archive = "StarTree30c.jar" WIDTH="'+mWidth+' px" HEIGHT="'+(mHeight-396)+' px" MAYSCRIPT><PARAM="cache_option" VALUE="No"><param name="dataset" value="tree.stc"><param name="data_streaming" value="false"><param name="invoke_double_click" value="FALSE"><param name="Search_button" value="false"><param name="Help_button" value="false"><param name="Home_button" value="false"><param name="Show_PlusMinus" value="true"><param name="Display_panel" value="BOTTOM"></applet>';
var strapplet = 
    //'<applet name="TreeApplet" codebase="http://water.sdsc.edu:7788/vizserver/applets" code="STApplet.class" archive = "StarTree30c.jar" WIDTH="'+mWidth+' px" HEIGHT="'+(mHeight-396)+' px" MAYSCRIPT>'+
    '<applet name="TreeApplet" code="STApplet.class" codebase=applets archive="StarTree30c.jar" WIDTH="'+mWidth+' px" HEIGHT="'+(mHeight-220)+' px" MAYSCRIPT>'+
    '<PARAM="cache_option" VALUE="No"><param name="dataset" value="ontology_mar1.stc">'+
    '<param name="data_streaming" value="false">'+
    '<param name="invoke_double_click" value="FALSE">'+
    '<param name="Search_button" value="false">'+
    '<param name="Help_button" value="false">'+
    '<param name="Home_button" value="false">'+
    '<param name="Show_PlusMinus" value="true">'+
    '<param name="Display_panel" value="BOTTOM">'+
    '</applet>';

document.getElementById("appletSection").innerHTML=strapplet;


}

function AddVarNameToList(varid){
activeVarID = varid;
Tagger.TaggerService.GetVariableName(varid, onVarNameComplete);
}

function onVarNameComplete(varname){

document.form1.textfield.value=varname;
if (document.form1.textfield2.value!=""){
if (document.form1.textfield2.value.indexOf('_other') > -1){
document.getElementById("suggestpanel").innerHTML= '<b>Suggest:</b><br /><input type="text" name="textfield3" value="Enter suggested new category here"><br/><input type="submit" name="SuggestButton" value="Map!" onclick="MapAndSuggest();return false;" id="Submit1" style="width: 42px;position:relative;top:5px;" />';
}else{
document.getElementById("suggestpanel").innerHTML= '<input type="submit" name="MapButton" value="Map!" onclick="MapToOntology();return false;" id="cartSubmit" style="width: 42px;position:relative;top:0px;" />'
}
}
}

function AddConceptToMenu(conceptID,conceptKeyword){
    activeConceptID = conceptID;
    activeConceptKeyword = conceptKeyword;
    document.form1.textfield2.value = conceptID;
    document.form1.textfieldKeyword.value = conceptKeyword;
    
    if (document.form1.textfield.value!=""){
        if (conceptID.indexOf('_other') > -1){
            document.getElementById("suggestpanel").innerHTML= '<b>Suggest:</b><br /><input type="text" name="textfield3" value="Enter suggested new category here"><br/><input type="submit" name="SuggestButton" value="Map!" onclick="MapAndSuggest();return false;" id="Submit1" style="width: 42px;position:relative;top:5px;" />';
        }else{
            document.getElementById("suggestpanel").innerHTML= '<input type="submit" name="MapButton" value="Map!" onclick="MapToOntology();return false;" id="cartSubmit" style="width: 42px;position:relative;top:0px;" />'
        }
    }
}

function MapToOntology(){
    //updated 3
    alert(activeVarID + "," + activeConceptID + "," + activeConceptKeyword);
Tagger.TaggerService.FinalizeMapping(activeVarID,activeConceptID,activeConceptKeyword, document.form1.uem.value, onMappingComplete);
}

function onMappingComplete(){
__doPostBack('Button1','');
//__doPostBack('refreshApplet','');
}

function MapAndSuggest(){
    //updated 2
    alert(activeVarID + "," + activeConceptID + "," + activeConceptKeyword);
Tagger.TaggerService.MapAndSuggest(activeVarID,activeConceptID,activeConceptKeyword,document.form1.textfield3.value, document.form1.uem.value, onMappingComplete);
}


function STmouseOver(urlandhierarchy){}
function STsingleClick(urlandhierarchy){}
function STdoubleClick(urlandhierarchy){
    
    var locArray = urlandhierarchy.split("\t");
    if (locArray[0] != "null") {
        var msg = "";
        for (var i = 0; i < locArray.length; i++) {
            msg += ":" + i + "," + locArray[i] + "\n";
        }
        //alert(msg);
        AddConceptToMenu(locArray[0],locArray[locArray.length-1]);
    //document.form1.textfield2.value=locArray[0];
    }else{
        alert('Please Select Leaf Nodes');
    }
}


function searchTree(){
document.TreeApplet.STSetSpot(document.form1.textfield4.value,'T');
return false;


}




