using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.ResponseModel
{
    public class GetCinemaOffsetPaginationResponse
    {
        public List<GetCinemaResponse> CinemaList { get; set; } = new List<GetCinemaResponse>();

        public int TotalData { get; set; }
    }
}
