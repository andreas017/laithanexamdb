using Lib.RequestModel;
using Lib.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Sql.Entity.Entity;
using Training.Sql.Entity;

namespace Lib.Services.RequestService
{
    public class CreateTheatreHandler : IRequestHandler<CreateTheatreRequest, CreateTheatreResponse>
    {
        CinemaDbContext _db;

        public CreateTheatreHandler(CinemaDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<CreateTheatreResponse> Handle(CreateTheatreRequest request, CancellationToken cancellationToken)
        {
            var checkCinema = _db.Cinemas.Where(x => x.Id == request.CinemaId).FirstOrDefault();
            var checkType = _db.TheatreTypes.Where(x => x.Id == request.TheatreTypeId).FirstOrDefault();

            if (checkCinema == null)
            {
                return new CreateTheatreResponse() { Response = "Cinema not found" };
            }

            if (checkType == null)  
            {
                return new CreateTheatreResponse() { Response = "Type not found" };
            }

            var newTheatre = new Theatre()
            {
                Name = request.Name,
                CinemaId = checkCinema.Id,
                TheatreTypeId = checkType.Id
            };

            await _db.Theatres.AddAsync(newTheatre);

            try
            {
                await _db.SaveChangesAsync();

                return new CreateTheatreResponse() { Response = "Success" };
            }
            catch (Exception ex)
            {
                return new CreateTheatreResponse() { Response = ex.Message };
            }
        }
    }
}
