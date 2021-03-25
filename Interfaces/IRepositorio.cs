using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T GetbyId(int id);
        void Remove(int id);
        void Update(int id, T entidade);
        void Add(T entidade);
        int ProximoId();

    }
}