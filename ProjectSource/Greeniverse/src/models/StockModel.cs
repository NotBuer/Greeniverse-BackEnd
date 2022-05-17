using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Greeniverse.src.models
{
    /// <summary>
    /// <para>Resume: Class responsible for representing a product in the database.</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 05/13/2022</para>
    /// </summary>
    
    [Table("tb_stock")]
    public class StockModel
    {
        public StockModel() { }

        public StockModel(string type, string description, float price, string productName, string provider)
        {
            Type = type;
            Description = description;
            Price = price;
            ProductName = productName;
            Provider = provider;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Type { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required, StringLength(50)]
        public string ProductName { get; set; }

        [Required, StringLength(50)]
        public string Provider { get; set; }

        [JsonIgnore, InverseProperty("Product")] 
        public List<ShoppingCartModel> ProductsInCart { get; set; }   

    }

}
