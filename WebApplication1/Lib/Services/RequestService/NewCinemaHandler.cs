using Lib.RequestModel;
using Lib.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Sql.Entity;
using Training.Sql.Entity.Entity;

namespace Lib.Services.RequestService
{
    public class NewCinemaHandler : IRequestHandler<NewCinemaRequest, NewCinemaResponse>
    {
        CinemaDbContext _db;

        public NewCinemaHandler(CinemaDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<NewCinemaResponse> Handle(NewCinemaRequest request, CancellationToken cancellationToken)
        {
            var newUser = new Cinema()
            {
                Name = request.Name,
                Address = request.Address
            };

            await _db.Cinemas.AddAsync(newUser);

            try
            {
                await _db.SaveChangesAsync();

                return new NewCinemaResponse() { Response = "Success" };
            }
            catch (Exception ex)
            {
                return new NewCinemaResponse() { Response = ex.Message };
            }
        }
    }
}