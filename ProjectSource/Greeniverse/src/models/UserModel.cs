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
    /// <para>Date: 05/13/2022</para>
    /// </summary>

    [Table("tb_users")]
    public class UserModel
    {

        public UserModel() { }

        public UserModel(string name, string email, string password, string address, int telephone, UserType userType)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Telephone = telephone;
            UserType = userType;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Address { get; set; }

        [Required]
        public int Telephone { get; set; }

        [Required]
        public UserType UserType { get; set; }

    }

}
