using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuahsi.Model.Base
{
    /// <summary>
    /// Base Entity overrides the comparison operators 
    /// so that the persistence tests will work when comparing
    /// referenced entities during testing.
    /// </summary>
    /// <remarks>From http://pastie.org/434198</remarks>
    [Serializable]
    public class BaseEntity : IEquatable<BaseEntity>
    {
        public virtual long Id { get; set; }

        public virtual bool Equals(BaseEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
           // if (GetType() != other.GetType()) return false;
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            //if (GetType() != obj.GetType()) return false;
            return Equals((BaseEntity)obj);
        }

        public override int GetHashCode()
        {
            return (Id.GetHashCode() * 397) ^ GetType().GetHashCode();
        }

        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !Equals(left, right);
        }

        # region Validation
        /* these two methods ( IsValid, and  GetRuleViolations())
         * need to be implemented in each class that you want to validation
         * you cannot just implement GetRuleViolations
         * GetRuleViolotions should call
         * 
         * foreach (var violation in base.GetRuleViolations().AsEnumerable())
          {
              yield return violation;
          }

         * so that all rules can be enforced
         * */

        public virtual bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public virtual IEnumerable<RuleViolation> GetRuleViolations()
        {
            
            yield break; // basically, empty
        }
        #endregion
    }

    //Tried an extension. This just ends up calling the BaseEntity GetRuleViolations
    //public static class BaseExtensions
    //{
    //    public static bool IsValid(this BaseEntity b)
    //    {
    //        return (b.GetRuleViolations().Count() == 0);
    //    }
    //}
}
