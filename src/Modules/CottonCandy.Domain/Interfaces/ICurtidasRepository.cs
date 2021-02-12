using CottonCandy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CottonCandy.Domain.Interfaces
{
    public interface ICurtidasRepository
    {
        Task<int> InsertAsync(Curtidas curtidas);
        Task<List<Curtidas>> GetByUserIdAsync(int usuarioId);
    }
}
