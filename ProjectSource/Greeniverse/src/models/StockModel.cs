using Greeniverse.src.utils;
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

        public StockModel(ProductCategory productCategory, string description, float price, string productName, int productAmount, string provider)
        {
            ProductCategory = productCategory;
            Description = description;
            Price = price;
            ProductName = productName;
            ProductAmount = productAmount;
            Provider = provider;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public ProductCategory ProductCategory { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required, StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        public int ProductAmount { get; set; }

        [Required, StringLength(50)]
        public string Provider { get; set; }

        [Required, StringLength(255)]
        public string ProductPhoto { get; set; }

        [JsonIgnore, InverseProperty("Product")]
        public List<ShoppingCartModel> ProductsInCart { get; set; }

    }

}
