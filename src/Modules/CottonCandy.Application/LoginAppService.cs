using CottonCandy.Application.AppUser.Output;
using CottonCandy.Application.AppUsuario.Interfaces;
using CottonCandy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CottonCandy.Application.AppUsuario
{
    class LoginAppService : ILoginAppService
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public LoginAppService(IUsuarioRepository UsuarioRepository)
        {
            _userRepository = UsuarioRepository;
        }

        public async Task<UsuarioViewModel> LoginAsync(string email, string senha)
        {
            var usuario = await _userRepository
                                .GetByLoginAsync(email)
                                .ConfigureAwait(false);

            if (usuario is null)
            {
                throw new Exception("Usuário não encontrado");
            }

            if (!usuario.SenhaEhIgual(senha))
            {
                return default;
            }

            return new UsuarioViewModel()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Genero = usuario.Genero,
                FotoPerfil = usuario.FotoPerfil,
                Cargo = usuario.Cargo,
                Cidade = usuario.Cidade
            };
        }
    }
}
