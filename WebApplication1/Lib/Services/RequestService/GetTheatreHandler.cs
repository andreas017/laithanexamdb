using Lib.RequestModel;
using Lib.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Sql.Entity;

namespace Lib.Services.RequestService
{
    public class GetTheatreHandler : IRequestHandler<GetTheatreRequest, List<GetTheatreResponse>>
    {
        CinemaDbContext _db;

        public GetTheatreHandler(CinemaDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<GetTheatreResponse>> Handle(GetTheatreRequest request, CancellationToken cancellationToken)
        {
            return await _db.Theatres.Select(q => new GetTheatreResponse()
            {
                Id = q.Id,
                Name = q.Name,
                CinemaId = q.CinemaId,
                TheatreTypeId = q.TheatreTypeId
            }).AsNoTracking().ToListAsync();
        }



    }
}
