using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Greeniverse.src.utils;

namespace Greeniverse.src.models
{
    /// <summary>
    /// <para>Abstract: Responsible Class for represent tb_users in the bank.</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 13/05/2022</para>
    /// </summary>

    [Table("tb_users")]
    public class UserModel
    {

        public UserModel() { }

        public UserModel(string name, string email, string password, string address, string telephone, UserType userType, int walletCoins)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Telephone = telephone;
            UserType = userType;
            WalletCoins = walletCoins;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Telephone { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [JsonIgnore, InverseProperty("Purchaser")]
        public ShoppingCartModel MyCart { get; set; }

        public int WalletCoins { get; set; }

    }

}
