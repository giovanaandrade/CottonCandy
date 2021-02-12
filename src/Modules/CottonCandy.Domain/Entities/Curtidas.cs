using System;
using System.Collections.Generic;
using System.Text;

namespace CottonCandy.Domain.Entities
{
    public class Curtidas
    {
        public Curtidas(Usuario usuario, Postagem postagem, string tipo)
        {
            Usuario = usuario;
            Postagem = postagem;
            Tipo = tipo;

        }

        public int Id { get; private set; }
        public Usuario Usuario { get; private set; }
        public Postagem Postagem { get; private set; }
        public string Tipo { get; private set; }


    }
}
