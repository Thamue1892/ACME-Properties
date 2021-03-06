﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACMEProperties.DataAccess.Data.Repository.IRepository;
using ACMEProperties.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACMEProperties.DataAccess.Data.Repository
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        private readonly ApplicationDbContext _db;

        public RentalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetRentalListForDropDown()
        {
            return _db.Rental.Select(r => new SelectListItem()
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });
        }

        public void Update(Rental rental)
        {
            var objFromDb = _db.Rental.FirstOrDefault(r => r.Id == rental.Id);

            objFromDb.Name = rental.Name;
            objFromDb.DurationInMonths = rental.DurationInMonths;

            _db.SaveChanges();
        }
    }
}
