using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoardingKennelBookings.Components.Data;
using BoardingKennelBookings.Components.Models;

namespace BoardingKennelBookings.Components.Services
{
    public class DogService
    {
        private readonly KennelContext _context;

        public DogService(KennelContext context)
        {
            _context = context;
        }

        public async Task<Dog> CreateDogAsync(Dog Dog)
        {
            _context.Dogs.Add(Dog);

            await _context.SaveChangesAsync();

            return Dog;
        }

        public async Task<Dog?> GetDog(Guid dogID)
        {
            return await _context.Dogs.FirstOrDefaultAsync(d => d.ID == dogID);
        }
        public async Task<List<Dog>> GetAllDogsAsync()
        {
            return await _context.Dogs// optional, include the customer info
                .ToListAsync();
        }

        public async Task<List<Dog>> GetOwnerDogsAsync(Guid OwnerID)
        {
            return await _context.Dogs
                .Where(d => d.OwnerID == OwnerID)
                .ToListAsync();
        }


        public string GetNameFromDog(Dog dog)
        {
            return dog.DogName;
        }
    }
}