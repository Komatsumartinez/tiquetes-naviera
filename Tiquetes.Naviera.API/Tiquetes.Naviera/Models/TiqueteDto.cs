using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiquetes.Naviera.Models
{
    public class TiqueteDto
    {
        public Guid Id { get; set; }
        public required string Destino { get; set; }
        public required string Pasajeros { get; set; }
        public DateTime Fecha { get; set; }
        public required string Nombre { get; set; }
        public required string Apellidos { get; set; }
        public required string Documento { get; set; }
        public required string Sexo { get; set; }
        public required string Nacionalidad { get; set; }
        public required DateTime FechaNacimiento { get; set; }
    }
}
