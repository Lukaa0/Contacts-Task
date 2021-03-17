using Contacts_DigitalTv.Context;
using Contacts_DigitalTv.Models;
using Contacts_DigitalTv.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_DigitalTv.Services
{
    public class PersonService : IMainService<Person>,IPersonService
    {
        protected readonly ContactDbContext _context;
        public PersonService(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Set<Person>().
                            Include(x => x.Phones).ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Set<Person>()
                 .Include(x => x.Phones)
                 .Where(p => p.Id == id)
                 .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Person person)
        {
            _context.Attach(person);
            _context.Entry(person).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task CreateAsync(Person person)
        {
            _context.Attach(person);
            _context.Entry(person).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetFavorites()
        {
            return await _context.Set<Person>()
                .Where(x => x.IsFavorite == true)
                .Include(x => x.Phones).ToListAsync();
        }
    }
}
