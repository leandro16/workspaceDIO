using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AppSerie.Classes
{
    internal class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie obj)
        {
            listaSerie[id] = obj;
        }

        public void atualiza(int id, Serie entidade)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }
        public void Insere(Serie obj)
        {
            listaSerie.Add(obj);
        }
        public List<Serie> Lista()
        {
            return listaSerie;
        }
        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }

    }
}
