using System;
using System.Collections.Generic;
using System.Text;

namespace CottonCandy.Domain.Entities
{
	public class Postagem
	{
		public Postagem(string texto, string fotoPost, Usuario usuario)
		{
			Texto = texto;
			FotoPost = fotoPost;
			DataPostagem = DateTime.Now;
			Usuario = usuario;
		}

        public Postagem(int id)
        {
			Id = id;
        }

		public int Id { get; private set; }
		public Usuario Usuario { get; private set; }
		public string Texto { get; private set; }
		public string FotoPost { get; private set; }
		public DateTime DataPostagem { get; private set; }


	}
}
