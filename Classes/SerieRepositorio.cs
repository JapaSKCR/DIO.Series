using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> series = new List<Serie>();
        public Serie GetbyId(int id)
        {
            return series[id];
        }

        public void Add(Serie entidade)
        {
            series.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return series;
        }

        public int ProximoId()
        {
            return series.Count;
        }

        public void Remove(int id)
        {
            series[id].Excluir();
        }

        public void Update(int id, Serie entidade)
        {
            series[id] = entidade;

        }
    }
}