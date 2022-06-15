using System.ComponentModel.DataAnnotations;
using Greeniverse.src.utils;

namespace Greeniverse.src.dtos
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting an shoppingcart to register</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 13/05/2022</para>
    /// </summary>
    public class NewShoppingCartDTO
    {

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        public string Voucher { get; set; }

        [Required, StringLength(50)]
        public string DeliveryAddress { get; set; }

        [Required]
        public string EmailPurchaser { get; set; }

        [Required]
        public int IdProduct { get; set; }


        public NewShoppingCartDTO(PaymentMethod paymentMethod, string voucher, string deliveryAddress, string emailPurchaser, int idProduct)
        {
            PaymentMethod = paymentMethod;
            Voucher = voucher;
            DeliveryAddress = deliveryAddress;
            EmailPurchaser = emailPurchaser;
            IdProduct = idProduct;
        }
    }

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a shoppingcart to update</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 05/13/2022</para>
    /// </summary>
    public class UpdateShoppingCartDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        public string Voucher { get; set; }

        [Required, StringLength(50)]
        public string DeliveryAddress { get; set; }

        public UpdateShoppingCartDTO(PaymentMethod paymentMethod, string voucher, string deliveryAddress)
        {
            PaymentMethod = paymentMethod;
            Voucher = voucher;
            DeliveryAddress = deliveryAddress;
        }
    }   
}
