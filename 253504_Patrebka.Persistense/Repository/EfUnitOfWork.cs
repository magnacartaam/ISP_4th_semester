﻿using _253504_Patrebka.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Patrebka.Persistense.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Car>> _carRepository;
        private readonly Lazy<IRepository<Advertisement>> _advertisementRepository;
        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _carRepository = new Lazy<IRepository<Car>>(() => new EfRepository<Car>(context));
            _advertisementRepository = new Lazy<IRepository<Advertisement>>(() => new EfRepository<Advertisement>(context));
        }
        public IRepository<Car> CarRepository => _carRepository.Value;

        public IRepository<Advertisement> AdvertisementRepository => _advertisementRepository.Value;

        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();
        
        public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();

        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
    }
}
