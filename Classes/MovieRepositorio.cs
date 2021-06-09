using System.Collections.Generic;
using Animes.Interfaces;

namespace Animes
{
    public class MovieRepositorio : IRepositorio<Movies>
    {

        private List<Movies> listaMovie = new List<Movies>(); 
        public void Atualizar(int id, Movies objeto)
        {
            listaMovie[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaMovie[id].Excluir();
        }

        public void Insere(Movies objeto)
        {
            listaMovie.Add(objeto);
        }

        public List<Movies> Lista()
        {
            return listaMovie;
        }

        public int ProximoId()
        {
            return listaMovie.Count;
        }

        public Movies RetornaPorID(int id)
        {
            return listaMovie[id];
        }
    }
}