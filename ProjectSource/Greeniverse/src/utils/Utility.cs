using System.Text.Json.Serialization;

namespace Greeniverse.src.utils
{
    // Put all enums in here.
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType { IndividualPerson, Business }

    [JsonConverter(typeof(JsonStringEnumConverter))]   
    public enum PaymentMethod { CreditCard, Paypal, PIX, Debit, CC }

}
