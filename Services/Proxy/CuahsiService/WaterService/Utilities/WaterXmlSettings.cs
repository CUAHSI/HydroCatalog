﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace cuahsi.his.WaterService.Utilities
{
    public class WaterXmlSettings
    {
        public static XmlWriterSettings NoDocument()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;

            return settings;
        }
    }
}