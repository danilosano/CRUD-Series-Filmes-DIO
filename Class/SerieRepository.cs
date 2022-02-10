using System.Collections.Generic;
using DIO_Series_Filmes.Interfaces;

namespace DIO_Series_Filmes.Class
{

    
    public class SerieRepository : IRepository<Series>
    {
        private List<Series> listaSerie = new List<Series>();
        public void Atualizar(int id, Series entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void insere(Series entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Series> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Series RetornaPorID(int id)
        {
            return listaSerie[id];
        }

        void IRepository<Series>.ProximoId()
        {
            throw new System.NotImplementedException();
        }
    }
}