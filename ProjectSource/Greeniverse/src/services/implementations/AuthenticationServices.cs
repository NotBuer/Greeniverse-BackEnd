using Greeniverse.src.dtos;
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
            
        }
}
