﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Сoncrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityBaseRepository<User,SabuncuPsikolojiDbContext>,IUserDal
    {
        public async Task<List<OperationClaim>> GetClaimsAsync(User user)
        {
            using (var context = new SabuncuPsikolojiDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name,
                             };
                return await result.ToListAsync();
            }
        }
    }
}