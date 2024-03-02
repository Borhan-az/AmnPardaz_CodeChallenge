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
                await _context.Users.AddAsync(new User("admin", "admin@APC.com", "", ""));
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}