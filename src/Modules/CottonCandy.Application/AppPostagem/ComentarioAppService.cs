using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CottonCandy.Application.AppPostagem.Interfaces;
using CottonCandy.Domain.Entities;
using CottonCandy.Domain.Interfaces;

namespace CottonCandy.Application.AppPostagem
{

    public ComentarioAppService(IComentarioRepository comentarioRepositorio, ILogado logado)
    {
        _comentarioRepositorio = comentarioRepositorio;
        _logado - logado;
    }


    public class ComentarioAppService : IComentarioAppService
    {
        Task<Comentario> IComentarioAppService.InserirAsync(int idPostagem, ComentarioInput input)
        {
            throw new NotImplementedException();
        }

        async Task<List<Comentario>> IComentarioAppService.PegarComentariosPorIdPostagemAsync(int idPostagem)
        {
            var comentarios = await _comentarioRepository
                                     .GetByPostageIdAsync(idPostagem)
                                     .ConfigureAwait(false);

            return comentarios;
        }
    }
}
