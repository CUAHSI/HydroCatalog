<%@ Page Language="C#" AutoEventWireup="true" Inherits="pub_map" Codebehind="pub_map.aspx.cs" %>

<%@ Register Src="HeaderControl.ascx" TagName="HeaderControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" lang="EN">
	<head>

	<script src='maps/OpenLayers.js'></script>
	<script type="text/javascript">
		  

      var map
      function init(){
             map = new OpenLayers.Map('map');

            var ol_wms = new OpenLayers.Layer.WMS( "OpenLayers WMS",
                "http://labs.metacarta.com/wms/vmap0?", {layers: 'basic'} );



            map.addLayer(ol_wms);
            map.addControl(new OpenLayers.Control.LayerSwitcher());
            mapbounds = new OpenLayers.Bounds(-130,25,-75,65);
            map.zoomToExtent(mapbounds);
        //}
    //function drawBoxes(){
          //var boxes_outline  = new OpenLayers.Layer.Boxes( "boxes_outline" );
          //var boxes  = new OpenLayers.Layer.Vector( "Boxes" );
          map.addLayer(ol_wms);
          for (var i = 0; i < box_extents.length; i++) {
              var boxes_outline = new OpenLayers.Layer.Boxes("id:" +i );
              ext = box_extents[i];
              bounds = new OpenLayers.Bounds(ext[0], ext[1], ext[2], ext[3]);
              var box = new OpenLayers.Marker.Box(bounds);
              box.index = "my name"+i;
              //box = new OpenLayers.Feature.Vector(bounds.toGeometry());
              box.events.register("click", box, function (e) {
                  this.setBorder("blue");alert(box.index);
              });
              boxes_outline.addMarker(box);
              map.addLayer(boxes_outline);
              //boxes.addFeatures(box);
          }
         
          //map.addLayer(boxes_outline);
    
    }            
			
		</script>

    <link href="styles/his.css" rel="stylesheet" type="text/css" />
    <link href="styles/his.css" rel="stylesheet" type="text/css" />
	</head>
	<body><form runat=server>
		<div id='map' style="left: 287px; width: 841px; position: absolute; top: 223px; height: 492px"></div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CentralHISConnectionString %>" SelectCommand="SELECT [NetworkID], [Xmin], [Xmax], [Ymin], [Ymax] FROM [HISNetworks]"></asp:SqlDataSource>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <uc1:HeaderControl ID="HeaderControl1" runat="server" />
    </form>
	</body>
</html>

