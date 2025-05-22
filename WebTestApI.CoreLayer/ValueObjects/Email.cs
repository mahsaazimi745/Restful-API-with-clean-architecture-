using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebTestApI.CoreLayer.ValueObjects
{
    public class Email : ValueObject
    {

        public string Value { get; private set; }

        private Email() { }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ایمیل نمی‌تواند خالی باشد.");

            if (!Regex.IsMatch(value, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
                throw new ArgumentException("فرمت ایمیل معتبر نیست.");

            // ایجاد یک نمونه جدید Email با مقدار ورودی و بازگرداندن آن
            return new Email(value);
        }

        // اگر نیاز ندارید حذفش کنید
        public static Email Create(Email email)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(Email));

            return Create(email.Value); // استفاده از Create(string)
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // برای مقایسه، حروف بزرگ و کوچک نادیده گرفته می‌شود
            yield return Value.ToLower();
        }

        public override string ToString() => Value;
        // ✅ اضافه کردن operator های مقایسه
        public static bool operator ==(Email left, Email right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Email left, Email right)
        {
            return !Equals(left, right);
        }
    }
}



