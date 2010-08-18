using System;
using System.Collections.Generic;
using System.Globalization;
using Cuahsi.Model.Base;
using Cuahsi.Model.OdCore.Common;
using Cuahsi.Model.OdExtensibility;
using Cuahsi.Model.OdLocation;

namespace Cuahsi.Model.OdCore.Site
{
    public class Site : BaseEntity
    {
        private bool _deleted;

        public Site()
        {
            GlobalIdentifier = Guid.NewGuid();
            CreatedOn = DateTime.Now;
           LastChecked= DateTime.Now;
            LastUpdate = DateTime.Now; 
            SiteProperties = new List<PropertyGeneric>();
            AlternateSiteCodes = new List<GenericCode>();
            SiteTypes = new List<SiteTypeCv>();

        }

        public virtual Guid GlobalIdentifier { get; set; }
        public virtual DataServiceCode DataService { get; set; }
        public virtual string Code { get; set; }

        public virtual IList<GenericCode> AlternateSiteCodes { get; set; }

        public virtual IList<SiteTypeCv> SiteTypes { get; set; }

        public virtual string Name { get; set; }

        public virtual LocationBase GeographicLocation { get; set; }

        public virtual IList<PropertyGeneric> SharedSiteProperties { get; set; }

        public virtual IList<PropertyGeneric> SiteProperties { get; set; }

        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime LastUpdate { get; protected internal set; }
        public virtual DateTime LastChecked { get; protected internal set; }

        /// <summary>
        /// Deleted. Mark deleted, if series is not longer to be used
        /// </summary>
        /// <remarks>If during harvest, site is not found in list, it should be marked as deleted.</remarks>
        /// <remarks>LastUpdate should be set to deleted</remarks>
        public virtual bool Deleted
        {
            get
            {
                return _deleted;
            }
            set
            {
                if ((!(_deleted = value)))
                {
                    _deleted = value;
                    SetLastUpdate();
                }
            }
        }
        public virtual void SetLastUpdate()
        {
            LastUpdate = DateTime.Now;
        }

        public virtual void SetLastChecked()
        {
            LastChecked = DateTime.Now;
        }
 
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentUICulture, "{0} - {1}", this.Code, this.Name);
        }
    }
}