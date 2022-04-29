using Microsoft.Extensions.Configuration;
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
        private string bucketName;


        public RepositoryCoches(ContextCoches context, IConfiguration configuration)
        {
            this.context = context;
            this.bucketName = configuration.GetValue<string>("AWS:BucketName");
        }

        public List<Coche> GetCoches()
        {
            List<Coche> coches = new List<Coche>();
            var consulta = from datos in this.context.Coches
                           select datos;
            foreach(Coche coche in consulta)
            {
                string urlBucket = "https://bucket-prueba-aurora-coches.s3.amazonaws.com/";
                coche.Imagen = urlBucket + coche.Imagen;
                coches.Add(coche);
            }
            return coches;
        }

        public void InsertCoche(int idcoche, string marca, string modelo, string conductor, string imagen)
        {
            Coche c = new Coche
            {
                IdCoche = idcoche, Marca = marca, Modelo = modelo, Conductor = conductor, Imagen = imagen
            };
            this.context.Coches.Add(c);
            this.context.SaveChanges();
            //ALOJA
        }
    }
}
