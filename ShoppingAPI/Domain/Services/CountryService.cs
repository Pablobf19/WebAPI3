using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DAL;
using ShoppingAPI.DAL.Entities;
using ShoppingAPI.Domain.Interfaces;

namespace ShoppingAPI.Domain.Services
{
    public class CountryService : ICountryService
    {

        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }


        public async Task<Country> CreateCountryAsync(Country country)
        {
            

            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;

                _context.Countries.Add(country);//add permite crear el objeto en la bd
                await _context.SaveChangesAsync();//guarda el pais en la bd

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            var country = await GetCountryByIdAsync(id);
              _context.Countries.Remove(country);

            return country;
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                
                _context.Countries.Update(country);//virtualizo mi objeto
                await _context.SaveChangesAsync();
            
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            var countries = await _context.Countries.ToListAsync();

            return countries;
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);

            return country;
        }
    }
}
