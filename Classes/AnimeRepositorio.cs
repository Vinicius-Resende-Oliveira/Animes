using System.Collections.Generic;
using Animes.Interfaces;

namespace Animes
{
    public class AnimeRepositorio : IRepositorio<Animes>
    {
        private List<Animes> listaAnime = new List<Animes>();
        public void Atualizar(int id, Animes objeto)
        {
            listaAnime[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaAnime[id].Excluir();
        }

        public void Insere(Animes objeto)
        {
            listaAnime.Add(objeto);
        }

        public List<Animes> Lista()
        {
            return listaAnime;
        }

        public int ProximoId()
        {
            return listaAnime.Count;
        }

        public Animes RetornaPorID(int id)
        {
            return listaAnime[id];
        }
    }
}