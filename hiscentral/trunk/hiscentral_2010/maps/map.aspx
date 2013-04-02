<%@ Page Language="C#" AutoEventWireup="true" Inherits="maps_map" Codebehind="map.aspx.cs" %>

<%@ Register Src="../HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" lang="EN">
	<head>

	<script src='OpenLayers.js'></script>
	<script type="text/javascript">
		  

      var map
      function init(){
             map = new OpenLayers.Map('map');

            var ol_wms = new OpenLayers.Layer.WMS( "OpenLayers WMS",
                "http://labs.metacarta.com/wms/vmap0?", {layers: 'basic'} );



            map.addLayer(ol_wms);
            map.addControl(new OpenLayers.Control.LayerSwitcher());
            map.zoomToMaxExtent();
        //}
    //function drawBoxes(){
          var boxes  = new OpenLayers.Layer.Boxes( "Boxes" );

          for (var i = 0; i < box_extents.length; i++) {
              ext = box_extents[i];
              bounds = new OpenLayers.Bounds(ext[0], ext[1], ext[2], ext[3]);
              box = new OpenLayers.Marker.Box(bounds);
              box.events.register("click", box, function (e) {
                  this.setBorder("yellow");
              });
              boxes.addMarker(box);
          }
          map.addLayers([ol_wms,boxes]);
    
    }            
			
		</script>

    <link href="styles/his.css" rel="stylesheet" type="text/css" />
	</head>
	<body>
		<div id='map' style="left: 91px; width: 841px; position: absolute; top: 284px; height: 492px"></div>
    <uc1:HeaderControl ID="HeaderControl1" runat="server" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>" SelectCommand="SELECT [NetworkID], [Xmin], [Xmax], [Ymin], [Ymax] FROM [HISNetworks]"></asp:SqlDataSource>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
	</body>
</html>

