using System.Globalization;
using Cuahsi.Model.Base;

namespace Cuahsi.Model.OdData
{
    public class Qualifier : BaseEntity
    {


        public virtual string Code { get; set; }

        public virtual string Description { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentUICulture, "{0} - {1}", this.Id, this.Code);
        }

        public static bool operator ==(Qualifier q1, Qualifier q2)
        {
            return ((q1.Id == q2.Id) && (q1.Code == q2.Code) && (q1.Description == q2.Description));
        }

        public static bool operator !=(Qualifier q1, Qualifier q2)
        {
            return !(q1 == q2);
        }

        public override bool Equals(object q2)
        {
            if (q2.GetType().Equals(this.GetType()))
            {
                var q = (Qualifier)q2;
                return ((this.Id == ((Qualifier)q).Id) && (this.Code == q.Code) && (this.Description == q.Description));
            }
            else
            {
                return false;
            }

        }
    }
}
