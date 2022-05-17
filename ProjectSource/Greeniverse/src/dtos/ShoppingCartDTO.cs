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
        public int AmountProduct { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        public string Voucher { get; set; }

        [Required, StringLength(50)]
        public string DeliveryAdress { get; set; }

        public NewShoppingCartDTO(int amountProduct, PaymentMethod paymentMethod, string voucher, string deliveryAdress)
        {
            AmountProduct = amountProduct;
            PaymentMethod = paymentMethod;
            Voucher = voucher;
            DeliveryAdress = deliveryAdress;
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
        public int AmountProduct { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        public string Voucher { get; set; }

        [Required, StringLength(50)]
        public string DeliveryAdress { get; set; }

        public UpdateShoppingCartDTO(int amountProduct, PaymentMethod paymentMethod, string voucher, string deliveryAdress)
        {
            AmountProduct = amountProduct;
            PaymentMethod = paymentMethod;
            Voucher = voucher;
            DeliveryAdress = deliveryAdress;
        }
    }   
}
