using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Sql.Entity.Entity
{
    public class TheatreType
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Theatre> Theatres { get; set; } = new List<Theatre>();
    }
}
