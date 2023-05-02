using Lib.RequestModel;
using Lib.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Sql.Entity;

namespace Lib.Services.RequestService
{
    public class UpdateCinemaHandler : IRequestHandler<UpdateCinemaRequest, UpdateCinemaResponse>
    {
        CinemaDbContext _db;

        public UpdateCinemaHandler(CinemaDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<UpdateCinemaResponse> Handle(UpdateCinemaRequest request, CancellationToken cancellationToken)
        {

            var newCinema = _db.Cinemas.Where(x => x.Id == request.Id).FirstOrDefault();

            if (newCinema == null)
            {
                return new UpdateCinemaResponse() { Response = "Cinema not found" };
            }

            newCinema.Address = request.Address;

            try
            {
                await _db.SaveChangesAsync();

                return new UpdateCinemaResponse() { Response = "Success" };
            }
            catch (Exception ex)
            {
                return new UpdateCinemaResponse() { Response = ex.Message };
            }
        }
    }
}
