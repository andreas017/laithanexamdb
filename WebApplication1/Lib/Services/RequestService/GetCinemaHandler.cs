using Lib.Interface;
using Lib.RequestModel;
using Lib.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Sql.Entity;
using Training.Sql.Entity.Entity;

namespace Lib.Services.RequestService
{
    public class GetCinemaHandler : IRequestHandler<GetCinemaRequest, GetCinemaOffsetPaginationResponse>
    {
        CinemaDbContext _db;
        private readonly IStorageProvider _storageProvider;

        public GetCinemaHandler(CinemaDbContext dbContext, IStorageProvider storageProvider)
        {
            _db = dbContext;
            _storageProvider = storageProvider;
        }

        public async Task<GetCinemaOffsetPaginationResponse> Handle(GetCinemaRequest request, CancellationToken cancellationToken)
        {
            var query = _db.Cinemas;
            var listCinema = await query.Skip(request.Limit * request.Offset).Take(request.Limit).Select(Q => new GetCinemaResponse
            {
                Id = Q.Id,
                Name = Q.Name,
                Address = Q.Address,
                BlobId= Q.BlobId,
                FileName = Q.Blob.FileName
                
            }).AsNoTracking().ToListAsync();

            foreach (var cinema in listCinema)
            {
                if (cinema.BlobId != null)
                {
                    cinema.FileUrl = await _storageProvider.GetPresignedUrl(cinema.BlobId.Value.ToString());
                }
            }

            var totalData = await query.CountAsync();

            return new GetCinemaOffsetPaginationResponse()
            {
                CinemaList = listCinema,
                TotalData = totalData
            };
        }

        
    }
}



/*public async Task<List<GetCinemaResponse>> Handle(GetCinemaRequest request, CancellationToken cancellationToken)
{
    return await _db.Cinemas.Select(q => new GetCinemaResponse()
    {
        Id = q.Id,
        Name = q.Name,
        Address = q.Address
    }).AsNoTracking().ToListAsync();
}*/