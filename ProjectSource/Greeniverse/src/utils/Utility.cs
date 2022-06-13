using System.Text.Json.Serialization;

namespace Greeniverse.src.utils
{
    // Put all enums in here.
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType { IndividualPerson, Business }

    [JsonConverter(typeof(JsonStringEnumConverter))]   
    public enum PaymentMethod { CreditCard, Paypal, PIX, Debit, CC }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductCategory { EggsAndMeat, Vegetables, Fruits, GroceryStore, BodyAndHouse, DrinksAndDairy, NULL}

    public enum QueryFilter { Default, MinorPrice, MajorPrice, Alphabetical }    

}
