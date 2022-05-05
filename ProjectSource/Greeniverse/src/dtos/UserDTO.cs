using System.ComponentModel.DataAnnotations;
using Greeniverse.src.utils;

namespace Greeniverse.src.DTOS
{

    public class NewUserDTO
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Address { get; set; }

        [Required, StringLength(15)]
        public int Phone { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public NewUserDTO(string name, string email, string password, string address, int phone, UserType userType)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Phone = phone;
            UserType = userType;
        }
    }

    public class UpdateUserDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Address { get; set; }

        [Required, StringLength(15)]
        public int Phone { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public UpdateUserDTO(string name, string email, string password, string address, int phone, UserType userType)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Phone = phone;
            UserType = userType;
        }
    }
}
