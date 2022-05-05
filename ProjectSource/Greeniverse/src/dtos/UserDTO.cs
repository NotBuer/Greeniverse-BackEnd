using System.ComponentModel.DataAnnotations;

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
        public string Adress { get; set; }

        [Required, StringLength(15)]
        public int Phone { get; set; }

        public NewUserDTO(string name, string email, string password, string adress, int phone)
        {
            Name = name;
            Email = email;
            Password = password;
            Adress = adress;
            Phone = phone;
        }
    }

    public class UpdateUserDTO
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Adress { get; set; }

        [Required, StringLength(15)]
        public int Phone { get; set; }

        public UpdateUserDTO(string name, string email, string password, string adress, int phone)
        {
            Name = name;
            Email = email;
            Password = password;
            Adress = adress;
            Phone = phone;
        }
    }
}
