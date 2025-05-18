using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestApI.CoreLayer.ValueObjects
{
   public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents()
                .Zip(other.GetEqualityComponents(), (a, b) => (a, b))
                .All(pair =>
                    (pair.a == null && pair.b == null) ||
                    (pair.a != null && pair.a.Equals(pair.b))
                );
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(0, (hash, obj) =>
                    HashCode.Combine(hash, obj?.GetHashCode() ?? 0)
                );
        }
    }
}
  
