using System.ComponentModel.DataAnnotations;

namespace Greeniverse.src.dtos
{
    
    public class NewStockDTO
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

        public NewStockDTO(int id, string type, string description, float price, string productName, string provider)
        {
            Id = id;
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

        public UpdateStockDTO(int id, string type, string description, float price, string productName, string provider)
        {
            Id = id;
            Type = type;
            Description = description;
            Price = price;
            ProductName = productName;
            Provider = provider;
        }
    }

}
