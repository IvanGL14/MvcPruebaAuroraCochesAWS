using MvcPruebaAuroraCochesAWS.Data;
using MvcPruebaAuroraCochesAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPruebaAuroraCochesAWS.Repositories
{
    public class RepositoryCoches
    {
        private ContextCoches context;

        public RepositoryCoches(ContextCoches context)
        {
            this.context = context;
        }

        public List<Coche> GetCoches()
        {
            return this.context.Coches.ToList();
        }

        public void InsertCoche(int idcoche, string marca, string modelo, string conductor, string imagen)
        {
            Coche c = new Coche
            {
                IdCoche = idcoche, Marca = marca, Modelo = modelo, Conductor = conductor, Imagen = imagen
            };
            this.context.Coches.Add(c);
            this.context.SaveChanges();
        }
    }
}
