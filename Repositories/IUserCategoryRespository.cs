using System;
using System.Collections.Generic;
using jannieCouture.Models;

namespace jannieCouture.Repositories
{
    public interface IUserCategoryRespository
    {
        IEnumerable<UserCategory> UserCategories { get; }
		UserCategory AddUserCategory(UserCategory newUserCategory);
    }
}
