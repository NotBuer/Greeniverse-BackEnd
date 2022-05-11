using System.ComponentModel.DataAnnotations;

namespace Greeniverse.src.dtos
{
    
    public class NewStockDTO
    {
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

        public NewStockDTO(string type, string description, float price, string productName, string provider)
        {
            Type = type;
            Description = description;
            Price = price;
            ProductName = productName;
            Provider = provider;
        }
    }
    
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
    }
}
