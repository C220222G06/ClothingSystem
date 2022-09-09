using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// agregar la siguiente libreria
using ClothingSystem.EntidadesDeNegocio;
//************************************

namespace ClothingSystem.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
