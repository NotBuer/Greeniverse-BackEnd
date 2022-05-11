<<<<<<< HEAD
﻿namespace Greeniverse.src.services.implementations
{
<<<<<<< HEAD
    public class AuthenticationServices : IAuthentication
=======
    public void CreateUserNoDuplicate(NewUserDTO dto)
>>>>>>> 0b2c18bce38abf0a13779a069993d461a7ee28f7
    {
        var user = _repository.GetUserByEmail(dto.Email);
        if (user != null) throw new Exception("Este email já está sendo utilizado");
        dto.Password = CodifyPassword(dto.Password);
        _repository.NewUser(dto);
=======
﻿using Greeniverse.src.dtos;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using Greeniverse.src.repositories.implementations;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace Greeniverse.src.services.implementations
{   
        public class AuthenticationServices : IAuthentication
        {
            #region Atributte

            private readonly IUser _repository;
            public IConfiguration Configuration { get; }

            #endregion

            #region Constructor

            public AuthenticationServices(IUser repository, IConfiguration configuration)
            {
                _repository = repository;
                Configuration = configuration;
            }

        #endregion

        #region Methods

        public string EncodePassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        #endregion

>>>>>>> 89c2373c0227b4239a2ef7f18bf940c317e6beb5
    }
}
