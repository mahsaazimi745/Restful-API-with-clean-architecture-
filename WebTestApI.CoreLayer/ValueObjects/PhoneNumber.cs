using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestApI.CoreLayer.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; private set; }

        private PhoneNumber() { }

        private PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be empty.");

            if (!value.StartsWith("09") || value.Length != 11)
                throw new ArgumentException("Invalid phone number format.");

            Value = value;
        }

        public static PhoneNumber Create(string phoneNumber)
        {
            return new PhoneNumber(phoneNumber);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;

        public static PhoneNumber Create(PhoneNumber phoneNumber)
        {
            throw new NotImplementedException();
        }
    }

}


 
