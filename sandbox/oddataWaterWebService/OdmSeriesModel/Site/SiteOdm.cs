using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Common;
using Cuahsi.Model.OdCore.Site;
using Cuahsi.Model.OdExtensibility;
using Cuahsi.Model.OdLocation;

namespace Cuahsi.Model.compatibility.Odm
{
    public class SiteOdm : Cuahsi.Model.OdCore.Site.Site
    {
        public SiteOdm()
        {
            
        }

        public SiteOdm(Cuahsi.Model.OdCore.Site.Site site)
        {
            this.Code = site.Code;
            this.AlternateSiteCodes = site.AlternateSiteCodes;
            this.GeographicLocation = site.GeographicLocation;
            this.CreatedOn = site.CreatedOn;
            this.GlobalIdentifier = new Guid();
          //  this.LastUpdate = site.LastUpdate;// not accessible Created when object is created
            this.Name = site.Name;
            this.DataService = site.DataService;
            this.SiteProperties = site.SiteProperties;
            this.SiteTypes = site.SiteTypes;
        }
        public virtual float? Elevation_m
        {
            get
            {
                var property = (PropertyDouble)SiteProperties.ReturnProperty("Elevation_m");
                if (property != null)
                {
                    return Convert.ToSingle(property.DoubleValue);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.HasValue)
                {
                    SiteProperties.AddOrUpdateProperty(
                        SitesHelper.Elevation_m(value.Value));
                }
            }
        }
        public virtual float? LocalX
        {
            get
            {
                var property = (PropertyDouble)SiteProperties.ReturnProperty("LocalX");
                if (property != null)
                {
                    return Convert.ToSingle(property.DoubleValue);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.HasValue)
                {
                    SiteProperties.AddOrUpdateProperty(
                        SitesHelper.LocalX(value.Value));
                }
            }
        }
        public virtual float? LocalY
        {
            get
            {
                var property = (PropertyDouble)SiteProperties.ReturnProperty("LocalY");
                if (property != null)
                {
                    return Convert.ToSingle(property.DoubleValue);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.HasValue)
                {
                    SiteProperties.AddOrUpdateProperty(
                        SitesHelper.LocalY(value.Value));
                }
            }
        }
        public virtual float? PosAccuracy_m
        {
            get
            {
                var property = (PropertyDouble)SiteProperties.ReturnProperty("PosAccuracy_m");
                if (property != null)
                {
                    return Convert.ToSingle(property.DoubleValue);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.HasValue)
                {
                    SiteProperties.AddOrUpdateProperty(
                        SitesHelper.PosAccuracy_m(value.Value));
                }
            }
        }
        public virtual string State
        {
            get
            {
                var property = (PropertyString)SiteProperties.ReturnProperty("State");
                if (property != null)
                {
                    return property.StringValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    SiteProperties.AddOrUpdateProperty(
                        SitesHelper.State(value));
                }
            }
        }
        public virtual string County
        {
            get
            {
                var property = (PropertyString) SiteProperties.ReturnProperty("County");
                if (property != null)
                {
                    return property.StringValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    SiteProperties.AddOrUpdateProperty(
                        SitesHelper.County(value));
                }
            }
        }
        public virtual string Comments
        {
            get
            {
                var property = (PropertyString)SiteProperties.ReturnProperty("Comments");
                if (property != null)
                {
                    return property.StringValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    SiteProperties.AddOrUpdateProperty(
                        SitesHelper.Comments(value));
                }
            }
        }
        public virtual string VerticalDatum
        {
            get
            {
                var property = (PropertyString)SiteProperties.ReturnProperty("VerticalDatum");
                if (property != null)
                {
                    return property.StringValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    SiteProperties.AddOrUpdateProperty(
                        SitesHelper.VerticalDatum(value));
                }
            }
        }
    }

    public static class SitesHelper
    {

        public static Dictionary<string, string> _properties = new Dictionary<string, string>
       {
        {"State","urn:gazetteer:adminstrative:2"},
        {"Country","urn:gazetteer:adminstrative:1"},
        {"County","urn:gazetteer:adminstrative:3"},
        {"PosAccuracy_m","urn:cuahsi.odm:measure:posiitionalAccuracy:m"},
        {"Elevation_m","urn:cuahsi.odm:measure:Elevation:m"},
        {"verticalDatum","urn:cuahsi.odm:verticalDatum"},
        {"comments", "urn:cuahsi.odm:comments"},
        { "LocalX","urn:cuahsi.odm:LocalX"},
        {"LocalY","urn:cuahsi.odm:LocalY"},
        {"LocalZ","urn:cuahsi.odm:LocalZ"}
    };

        public static Model.OdExtensibility.PropertyGeneric ReturnProperty(this IList<PropertyGeneric> propertyGenerics, string propertyName)
        {
            var items = propertyGenerics.Where(p => p.Name == propertyName);
            if (items != null && items.Count() > 0)
            {
                return items.First();
            }
            else
            {
                return null;
            }

        }
        public static void AddOrUpdateProperty(this IList<PropertyGeneric> propertyGenerics, PropertyGeneric propertyGeneric)
        {
            var items = propertyGenerics.Where(p => p.Name == propertyGeneric.Name && p.Uri == propertyGeneric.Uri);
            if (items != null && items.Count() > 0)
            {
                var item = items.First();
                if (!propertyGeneric.Equals(item))
                {
                    item.SetValue(propertyGeneric.GetValue());
                }
            }
            else
            {
                propertyGenerics.Add(propertyGeneric);
            }

        }
        #region property creation methods
        public static Model.OdExtensibility.PropertyGeneric State(String state)
        {
            if (!String.IsNullOrEmpty(state))
            {
                return new PropertyString
                           {
                               StringValue = state,
                               Name = "State",
                               Uri = "urn:gazetteer:adminstrative:2"
                           };
            }
            else return null;
        }
        public static Model.OdExtensibility.PropertyString Country(String Country)
        {
            if (!String.IsNullOrEmpty(Country))
            {
                return new PropertyString
                {
                    StringValue = Country,
                    Name = "Country",
                    Uri = "urn:gazetteer:adminstrative:1"
                };
            }
            else return null;
        }
        public static Model.OdExtensibility.PropertyString County(String County)
        {
            if (!String.IsNullOrEmpty(County))
            {
                return new PropertyString
                {
                    StringValue = County,
                    Name = "County",
                    Uri = "urn:gazetteer:adminstrative:3"
                };
            }
            else return null;
        }

        public static Model.OdExtensibility.PropertyDouble PosAccuracy_m(double? accruacy)
        {
            if (accruacy.HasValue)
            {
                return new PropertyDouble
                {
                    DoubleValue = accruacy.Value,
                    Name = "PosAccuracy_m",
                    Uri = "urn:cuahsi.odm:measure:posiitionalAccuracy:m"
                };
            }
            else return null;
        }
        public static Model.OdExtensibility.PropertyDouble Elevation_m(double? accruacy)
        {
            if (accruacy.HasValue)
            {
                return new PropertyDouble
                {
                    DoubleValue = accruacy.Value,
                    Name = "Elevation_m",
                    Uri = "urn:cuahsi.odm:measure:Elevation:m"
                };
            }
            else return null;
        }

        public static Model.OdExtensibility.PropertyString VerticalDatum(String verticalDatum)
        {
            if (!String.IsNullOrEmpty(verticalDatum))
            {
                return new PropertyString
                {
                    StringValue = verticalDatum,
                    Name = "verticalDatum",
                    Uri = "urn:cuahsi.odm:verticalDatum"
                };
            }
            else return null;
        }
        public static Model.OdExtensibility.PropertyString Comments(String comments)
        {
            if (!String.IsNullOrEmpty(comments))
            {
                return new PropertyString
                {
                    StringValue = comments,
                    Name = "comment",
                    Uri = "urn:cuahsi.odm:comment"
                };
            }
            else return null;
        }

        public static Model.OdExtensibility.PropertyDouble LocalX(double? localX)
        {
            if (localX.HasValue)
            {
                return new PropertyDouble
                {
                    DoubleValue = localX.Value,
                    Name = "LocalX",
                    Uri = "urn:cuahsi.odm:LocalX"
                };
            }
            else return null;
        }
        public static Model.OdExtensibility.PropertyDouble LocalY(double? localY)
        {
            if (localY.HasValue)
            {
                return new PropertyDouble
                {
                    DoubleValue = localY.Value,
                    Name = "LocalY",
                    Uri = "urn:cuahsi.odm:LocalY"
                };
            }
            else return null;
        }
        public static Model.OdExtensibility.PropertyDouble LocalZ(double? localZ)
        {
            if (localZ.HasValue)
            {
                return new PropertyDouble
                {
                    DoubleValue = localZ.Value,
                    Name = "LocalZ",
                    Uri = "urn:cuahsi.odm:LocalZ"
                };
            }
            else return null;
        }
        #endregion
    }
}