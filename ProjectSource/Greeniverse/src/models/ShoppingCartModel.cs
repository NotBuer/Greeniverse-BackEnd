using Greeniverse.src.utils;
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
        
        public ShoppingCartModel(int amountProduct, PaymentMethod paymentMethod, string voucher, string deliveryAddress, int fK_Purchaser, int fK_Product)
        {
            AmountProduct = amountProduct;
            PaymentMethod = paymentMethod;
            Voucher = voucher;
            DeliveryAddress = deliveryAddress;
            FK_Purchaser = fK_Purchaser;
            FK_Product = fK_Product;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public int AmountProduct { get; set; }

        [Required, StringLength(50)]
        public PaymentMethod PaymentMethod { get; set; }

        [Required, StringLength(50)]
        public string Voucher { get; set; }

        [Required, StringLength(50)]
        public string DeliveryAddress { get; set; }

        [ForeignKey("FK_Purchaser")]
        public int FK_Purchaser { get; set; }

        [ForeignKey("FK_Product")]
        public int FK_Product { get; set; }
    }

}