using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.InfrastructureLayer.Serialization.Converters
{
    public class PasswordJsonConverter: JsonConverter<Password>
    {

        public override Password Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var hashedValue = reader.GetString();

            if (hashedValue == null)
                return null;

            // استفاده از متد CreateFromHashed برای ساخت Password از مقدار هش شده
            return Password.CreateFromHashed(hashedValue);
        }

        public override void Write(Utf8JsonWriter writer, Password value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            // فقط مقدار HashedValue را به صورت رشته می‌نویسد
            writer.WriteStringValue(value.HashedValue);
        }
    }
}

