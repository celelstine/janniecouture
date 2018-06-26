using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using jannieCouture.Models;

namespace jannieCouture.Repositories
{
    public class AgeRangeRepository: IAgeRangeRepository
    {
		private readonly AppDbContext _appDbContext;

        public AgeRangeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<AgeRange> AgeRanges => _appDbContext.AgeRange.ToList();
    }
}
