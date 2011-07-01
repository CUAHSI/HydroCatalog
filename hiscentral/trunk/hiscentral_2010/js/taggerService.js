Type.registerNamespace('Tagger');
Tagger.TaggerService = function() {
    Tagger.TaggerService.initializeBase(this);
    this._timeout = 0;
    this._userContext = null;
    this._succeeded = null;
    this._failed = null;
}
Tagger.TaggerService.prototype = {
    GetVariableName: function(varID, succeededCallback, failedCallback, userContext) {
        return this._invoke(Tagger.TaggerService.get_path(), 'GetVariableName', false, { varID: varID }, succeededCallback, failedCallback, userContext);
    },
    FinalizeMapping: function(varID, conceptID, keyword, userName, succeededCallback, failedCallback, userContext) {
        return this._invoke(Tagger.TaggerService.get_path(), 'FinalizeMapping', false, { varID: varID, conceptID: conceptID, keyword: keyword, userName: userName }, succeededCallback, failedCallback, userContext);
    },
    MapAndSuggest: function(activeVarID, activeConceptID, suggestion, userName, succeededCallback, failedCallback, userContext) {
        return this._invoke(Tagger.TaggerService.get_path(), 'MapAndSuggest', false, { activeVarID: activeVarID, activeConceptID: activeConceptID, suggestion: suggestion, userName: userName }, succeededCallback, failedCallback, userContext);
    },
    MapAndRemovePendingStatus: function(activeVarID, activeConceptID, otherConceptID, userName, succeededCallback, failedCallback, userContext) {
        return this._invoke(Tagger.TaggerService.get_path(), 'MapAndRemovePendingStatus', false, { activeVarID: activeVarID, activeConceptID: activeConceptID, otherConceptID: otherConceptID, userName: userName }, succeededCallback, failedCallback, userContext);
    },
    RefreshTree: function(succeededCallback, failedCallback, userContext) {
        return this._invoke(Tagger.TaggerService.get_path(), 'RefreshTree', false, {}, succeededCallback, failedCallback, userContext);
    },
    GetPendingMappingInfo: function(varID, succeededCallback, failedCallback, userContext) {
        return this._invoke(Tagger.TaggerService.get_path(), 'GetPendingMappingInfo', false, { varID: varID }, succeededCallback, failedCallback, userContext);
    },
    CheckIfUnique: function(conceptID, succeededCallback, failedCallback, userContext) {
        return this._invoke(Tagger.TaggerService.get_path(), 'CheckIfUnique', false, { conceptID: conceptID }, succeededCallback, failedCallback, userContext);
    } 
}
Tagger.TaggerService.registerClass('Tagger.TaggerService', Sys.Net.WebServiceProxy);
Tagger.TaggerService._staticInstance = new Tagger.TaggerService();
Tagger.TaggerService.set_path = function(value) {
    var e = Function._validateParams(arguments, [{ name: 'path', type: String}]); if (e) throw e; Tagger.TaggerService._staticInstance._path = value;
}
Tagger.TaggerService.get_path = function() { return Tagger.TaggerService._staticInstance._path; }
Tagger.TaggerService.set_timeout = function(value) {
    var e = Function._validateParams(arguments, [{ name: 'timeout', type: Number}]); if (e) throw e; if (value < 0) { throw Error.argumentOutOfRange('value', value, Sys.Res.invalidTimeout); }
    Tagger.TaggerService._staticInstance._timeout = value;
}
Tagger.TaggerService.get_timeout = function() {
    return Tagger.TaggerService._staticInstance._timeout;
}
Tagger.TaggerService.set_defaultUserContext = function(value) {
    Tagger.TaggerService._staticInstance._userContext = value;
}
Tagger.TaggerService.get_defaultUserContext = function() {
    return Tagger.TaggerService._staticInstance._userContext;
}
Tagger.TaggerService.set_defaultSucceededCallback = function(value) {
    var e = Function._validateParams(arguments, [{ name: 'defaultSucceededCallback', type: Function}]); if (e) throw e; Tagger.TaggerService._staticInstance._succeeded = value;
}
Tagger.TaggerService.get_defaultSucceededCallback = function() {
    return Tagger.TaggerService._staticInstance._succeeded;
}
Tagger.TaggerService.set_defaultFailedCallback = function(value) {
    var e = Function._validateParams(arguments, [{ name: 'defaultFailedCallback', type: Function}]); if (e) throw e; Tagger.TaggerService._staticInstance._failed = value;
}
Tagger.TaggerService.get_defaultFailedCallback = function() {
    return Tagger.TaggerService._staticInstance._failed;
}
Tagger.TaggerService.set_path("/hiscentral_old/TaggerService.asmx");
Tagger.TaggerService.GetVariableName = function(varID, onSuccess, onFailed, userContext) { Tagger.TaggerService._staticInstance.GetVariableName(varID, onSuccess, onFailed, userContext); }
Tagger.TaggerService.FinalizeMapping = function(varID, conceptID, keyword, userName, onSuccess, onFailed, userContext) { Tagger.TaggerService._staticInstance.FinalizeMapping(varID, conceptID, keyword, userName, onSuccess, onFailed, userContext); }
Tagger.TaggerService.MapAndSuggest = function(activeVarID, activeConceptID, suggestion, userName, onSuccess, onFailed, userContext) { Tagger.TaggerService._staticInstance.MapAndSuggest(activeVarID, activeConceptID, suggestion, userName, onSuccess, onFailed, userContext); }
Tagger.TaggerService.MapAndRemovePendingStatus = function(activeVarID, activeConceptID, otherConceptID, userName, onSuccess, onFailed, userContext) { Tagger.TaggerService._staticInstance.MapAndRemovePendingStatus(activeVarID, activeConceptID, otherConceptID, userName, onSuccess, onFailed, userContext); }
Tagger.TaggerService.RefreshTree = function(onSuccess, onFailed, userContext) { Tagger.TaggerService._staticInstance.RefreshTree(onSuccess, onFailed, userContext); }
Tagger.TaggerService.GetPendingMappingInfo = function(varID, onSuccess, onFailed, userContext) { Tagger.TaggerService._staticInstance.GetPendingMappingInfo(varID, onSuccess, onFailed, userContext); }
Tagger.TaggerService.CheckIfUnique = function(conceptID, onSuccess, onFailed, userContext) { Tagger.TaggerService._staticInstance.CheckIfUnique(conceptID, onSuccess, onFailed, userContext); }
var gtc = Sys.Net.WebServiceProxy._generateTypedConstructor;
if (typeof (Tagger.PendingMappingObject) === 'undefined') {
    Tagger.PendingMappingObject = gtc("Tagger.PendingMappingObject");
    Tagger.PendingMappingObject.registerClass('Tagger.PendingMappingObject');
}
