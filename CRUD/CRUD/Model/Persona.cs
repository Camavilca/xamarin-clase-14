using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUD.Model
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
