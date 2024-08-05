using Newtonsoft.Json;
using System;

namespace DesignPatternsInCSharp.Adapter.ThirdPartyApi;

public static class Gender_Extensions
{
    public static Gender ConvertToGender(this object input, Gender defaultValue = Gender.NotApplicable)
    {
        if (input == null)
        {
            return defaultValue;
        }

        if (input is Gender gender)
        {
            return gender;
        }

        if (input is string str)
        {
            if (Enum.TryParse(str, true, out Gender parsedGender))
            {
                return parsedGender;
            }
        }

        if (input is int intVal && Enum.IsDefined(typeof(Gender), intVal))
        {
            return (Gender)intVal;
        }

        return defaultValue;
    }
}

public class GenderConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {

        Gender gender = value.ConvertToGender();
        writer.WriteValue(gender.ToString());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var enumString = (string)reader.Value;

        if (enumString == "n/a") return Gender.NotApplicable;

        return Enum.Parse(typeof(Gender), enumString, true);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(string);
    }
}
