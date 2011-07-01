<%@ Page Language="C#" AutoEventWireup="true" Inherits="pub_map3" Codebehind="pub_map3.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="EN">
	<head>
	<style>
		html,body {
			height: 99%;
			width: 99%;
		}
		#map {
			width: 100%;
			height: 100%;
			border: 1px solid black;
		}	
	</style>
	<script src='http://openlayers.org/api/OpenLayers.js'></script>
	<script type="text/javascript">
		  
			var box_extents = [
                [-10, 50, 5, 60],
                [-75, 41, -71, 44],
                [-122.6, 37.6, -122.3, 37.9],
                [10, 10, 20, 20]
            ];
      var map;
      function init(){
                map = new OpenLayers.Map('map');

                var ol_wms = new OpenLayers.Layer.WMS( "OpenLayers WMS",
                    "http://labs.metacarta.com/wms/vmap0?", {layers: 'basic'} );

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

                map.addLayers([ol_wms, boxes]);
                map.addControl(new OpenLayers.Control.LayerSwitcher());
                map.zoomToMaxExtent();
            }
			
		</script>
	</head>
	<body onload="init()">
		<div id='map'></div>
		
	</body>
</html>
