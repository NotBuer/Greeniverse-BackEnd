using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Greeniverse.src.models
{
    
    [Table("tb_shoppingcart")]
    public class ShoppingCartModel
    {
        public ShoppingCartModel() { }
        public ShoppingCartModel(int amoutProduct, string paymentMethod, string voucher, string deliveryAdress, int fK_Purchaser, int fK_Product)
        {
            AmoutProduct = amoutProduct;
            PaymentMethod = paymentMethod;
            Voucher = voucher;
            DeliveryAdress = deliveryAdress;
            FK_Purchaser = fK_Purchaser;
            FK_Product = fK_Product;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public int AmoutProduct { get; set; }

        [Required, StringLength(50)]
        public string PaymentMethod { get; set; }

        [Required, StringLength(50)]
        public string Voucher { get; set; }

        [Required, StringLength(50)]
        public string DeliveryAdress { get; set; }

        [ForeignKey("FK_Purchaser")]
        public int FK_Purchaser { get; set; }

        [ForeignKey("FK_Product")]
        public int FK_Product { get; set; }
    }
    
}
