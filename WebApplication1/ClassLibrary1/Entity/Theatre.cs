using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Sql.Entity.Entity
{
    public class Theatre
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; } = new Cinema();
        public int TheatreTypeId { get; set; }
        public TheatreType TheatreType { get; set; } = new TheatreType();
    }
}
