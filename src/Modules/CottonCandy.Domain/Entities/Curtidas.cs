using System;
using System.Collections.Generic;
using System.Text;

namespace CottonCandy.Domain.Entities
{
    public class Curtidas
    {
        public Curtidas(int usuarioId, int postagemId, string tipo)
        {
            UsuarioId = usuarioId;
            PostagemId = postagemId;
            Tipo = tipo;

        }

        public Curtidas(int id, int usuarioId, int postagemId)
        {
            Id = id;
            UsuarioId = usuarioId;
            PostagemId = postagemId;

        }

        public Curtidas(int postagemId, int usuarioId)
        {
            UsuarioId = usuarioId;
            PostagemId = postagemId;

        }

        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public int PostagemId { get; private set; }
        public string Tipo { get; private set; }


    }
}
