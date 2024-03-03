using APC.Application.Common.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APC.Infrastructure.Persistance
{
    public class ApplicationDbContextInitializer
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task SeedAsync()
        {
            try
            {
                //seed updated
                var salt = PasswordHasher.GenerateSalt();
                var hash = PasswordHasher.HashPassword("admin", salt);
                await _context.Users.AddAsync(new User("admin", "admin@APC.com", Convert.ToBase64String(hash), Convert.ToBase64String(salt)));
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}