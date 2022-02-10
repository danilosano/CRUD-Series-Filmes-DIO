using System.Collections.Generic;

namespace DIO_Series_Filmes.Interfaces
{
    public interface IRepository<T>
    {
         List<T> Lista();
         T RetornaPorID(int id);
         void insere(T entidade);
         void Excluir(int id);
         void Atualizar(int id, T entidade);
         void ProximoId();
    }
}