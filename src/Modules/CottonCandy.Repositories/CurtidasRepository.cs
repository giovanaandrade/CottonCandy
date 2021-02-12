using CottonCandy.Domain.Entities;
using CottonCandy.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CottonCandy.Repositories
{
    public class CurtidasRepository : ICurtidasRepository
    {

        private readonly IConfiguration _configuration;

        public CurtidasRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Curtidas>> GetByUserIdAsync(int usuarioId)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT Id,
                                       Tipo,
                                       PostagemId,
                                       UsuarioId
                                FROM 
	                                Curtidas
                                WHERE 
	                                UsuarioId= '{usuarioId}'";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                        .ExecuteReaderAsync()
                                        .ConfigureAwait(false);

                    var curtidasUsuario = new List<Curtidas>();

                    while (reader.Read())
                    {
                        var curtidas = new Curtidas(new Usuario(int.Parse(reader["UsuarioId"].ToString())),
                                                    new Postagem(int.Parse(reader["PostagemId"].ToString())),
                                                    reader["Tipo"].ToString());


                        curtidasUsuario.Add(curtidas);
                    }

                    return curtidasUsuario;
                }
            }
        }

        public async Task<int> InsertAsync(Curtidas curtidas)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @"INSERT INTO
                                 Curtidas (Tipo,
                                            PostagemId,
                                            UsuarioId)
                                VALUES (@tipo,
                                        @postagemId,
                                        @usuarioId); SELECT scope_identity();";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("tipo", curtidas.Tipo);
                    cmd.Parameters.AddWithValue("postagemId", curtidas.Postagem.Id);
                    cmd.Parameters.AddWithValue("usuarioId", curtidas.Usuario.Id);

                    con.Open();
                    var id = await cmd.ExecuteScalarAsync().ConfigureAwait(false);

                    return int.Parse(id.ToString());


                }
            }
        }
    }
}
