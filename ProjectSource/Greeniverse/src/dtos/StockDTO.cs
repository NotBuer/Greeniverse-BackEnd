using Greeniverse.src.utils;
using System.ComponentModel.DataAnnotations;

namespace Greeniverse.src.dtos
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a product to register</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 05/13/2022</para>
    /// </summary>

    public class NewStockDTO
    {
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

        public NewStockDTO(ProductCategory productCategory, string description, float price, string productName, int productAmount, string provider, string productPhoto)
        {
            ProductCategory = productCategory;
            Description = description;
            Price = price;
            ProductName = productName;
            ProductAmount = productAmount;
            Provider = provider;
            ProductPhoto = productPhoto;
        }

        public NewStockDTO() { }
    }

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a product to update</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 05/13/2022</para>
    /// </summary>

    public class UpdateStockDTO
    {
        [Required]
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

        public UpdateStockDTO(int id, ProductCategory productCategory, string description, float price, string productName, int productAmount, string provider, string productPhoto)
        {
            Id = id;
            ProductCategory = productCategory;
            Description = description;
            Price = price;
            ProductName = productName;
            ProductAmount = productAmount;
            Provider = provider;
            ProductPhoto = productPhoto;
        }

        public UpdateStockDTO() { }
    }
}
