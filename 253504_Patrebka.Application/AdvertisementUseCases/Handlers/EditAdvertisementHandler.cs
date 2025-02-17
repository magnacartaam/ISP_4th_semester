﻿using _253504_Patrebka.Application.AdvertisementUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Patrebka.Application.AdvertisementUseCases.Handlers
{
    public class EditAdvertisementHandler : IRequestHandler<EditAdvertisementQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditAdvertisementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(EditAdvertisementQuery request, CancellationToken cancellationToken)
        {
            //var advertisement = new Advertisement(request.Id, request.Name, request.CreatedAt,
            //    request.Description, request.ImagePath, request.CarId, request.Cost);
            //await _unitOfWork.AdvertisementRepository.UpdateAsync(advertisement, cancellationToken);
            var advertisement = await _unitOfWork.AdvertisementRepository.GetByIdAsync(request.Id, cancellationToken);
            if (advertisement != null)
            {
                advertisement.Name = request.Name;
                advertisement.CreatedAt = request.CreatedAt;
                advertisement.Description = request.Description;
                advertisement.ImagePath = request.ImagePath;
                advertisement.CarId = request.CarId;
                advertisement.Cost = request.Cost;

                await _unitOfWork.AdvertisementRepository.UpdateAsync(advertisement, cancellationToken);

            }
        }
    }
}
