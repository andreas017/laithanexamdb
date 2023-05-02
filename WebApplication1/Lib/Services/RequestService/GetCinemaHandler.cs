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
    public class GetCinemaHandler : IRequestHandler<GetCinemaRequest, List<GetCinemaResponse>>
    {
        CinemaDbContext _db;

        public GetCinemaHandler(CinemaDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<GetCinemaResponse>> Handle(GetCinemaRequest request, CancellationToken cancellationToken)
        {
            return await _db.Cinemas.Select(q => new GetCinemaResponse()
            {
                Name = q.Name,
                Address = q.Address
            }).AsNoTracking().ToListAsync();
        }

    }
}
