using ACMEProperties.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACMEProperties.DataAccess.Data.Repository.IRepository
{
    public interface IUserRepository:IRepository<ApplicationUser>
    {
        void LockUser(string userId);

        void UnLockUser(string userId);
    }
}
