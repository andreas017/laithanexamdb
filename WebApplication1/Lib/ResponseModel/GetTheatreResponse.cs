using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ResponseModel
{
    public class GetTheatreResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CinemaId { get; set; }

        public int TheatreTypeId { get; set; }
    }
}
