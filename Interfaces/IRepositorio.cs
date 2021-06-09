using System.Collections.Generic;

namespace Animes.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorID(int id);
         void Insere(T entidade);
         void Excluir(int id);
         void Atualizar(int id, T entidade);
         int ProximoId();
    }
}