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
        public int Id { get; set; } 

        [Required, StringLength(50)]
        public string Type { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required, StringLength(50)]
        public string ProductName { get; set; }

        [Required, StringLength(20)]
        public string Provider { get; set; }

        public NewStockDTO(int id, string type, string description, float price, string productName, string provider)
        {
            Id = id;
            Type = type;
            Description = description;
            Price = price;
            ProductName = productName;
            Provider = provider;
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

        [Required, StringLength(50)]
        public string Type { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        [Required, StringLength(200)]
        public float Price { get; set; }

        [Required, StringLength(50)]
        public string ProductName { get; set; }

        [Required, StringLength(20)]
        public string Provider { get; set; }

        public UpdateStockDTO(string type, string description, float price, string productName, string provider)
        {
            Type = type;
            Description = description;
            Price = price;
            ProductName = productName;
            Provider = provider;
        }

        public UpdateStockDTO() { }
    }
}
