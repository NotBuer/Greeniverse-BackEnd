using Greeniverse.src.utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Greeniverse.src.models
{

    /// <summary>
    /// <para>Resume: Class responsible for representing a shopping cart in the database.</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 13/05/2022</para>
    /// </summary>

    [Table("tb_shoppingcart")]
    public class ShoppingCartModel
    {
        public ShoppingCartModel() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public PaymentMethod PaymentMethod { get; set; }

        [Required, StringLength(50)]
        public string Voucher { get; set; }

        [Required, StringLength(50)]
        public string DeliveryAddress { get; set; }

        [ForeignKey("FK_Purchaser")]
        public UserModel Purchaser { get; set; }

        [ForeignKey("FK_Product")]
        public StockModel Product { get; set; }

        public ShoppingCartModel(PaymentMethod paymentMethod, string voucher, string deliveryAddress)
        {
            PaymentMethod = paymentMethod;
            Voucher = voucher;
            DeliveryAddress = deliveryAddress;
        }
    }

}