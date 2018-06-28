using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using jannieCouture.Models;

namespace jannieCouture.Repositories
{
    public class UserCategoryRespository: IUserCategoryRespository
    {
		private readonly AppDbContext _appDbContext;

		public UserCategoryRespository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IEnumerable<UserCategory> UserCategories => _appDbContext.UserCategory.ToList();

		public UserCategory AddUserCategory(UserCategory newUserCategory)
		{
			_appDbContext.UserCategory.Add(newUserCategory);
			_appDbContext.SaveChanges();
			return newUserCategory;
		}
    }
}
