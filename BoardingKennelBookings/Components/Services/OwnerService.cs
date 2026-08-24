using BoardingKennelBookings.Components.Data;
using BoardingKennelBookings.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardingKennelBookings.Components.Services
{
    public class OwnerService
    {
        private readonly KennelContext _context;

        public OwnerService(KennelContext context)
        {
            _context = context;
        }

        public async Task<Owner> CreateOwnerAsync(Owner Owner)
        {
            _context.Owners.Add(Owner);

            await _context.SaveChangesAsync();

            return Owner;
        }

        public async Task<List<Owner>> GetAllOwnersAsync()
        {
            return await _context.Owners
                .ToListAsync();
        }

        public async Task<Owner?> FindOwnerAsync(Guid ownerID)
        {
            return await _context.Owners.FirstOrDefaultAsync(x => x.OwnerID == ownerID);
        }

        public async Task<List<Owner?>> FindOwnersByNameAsync(string name)
        {
            List<Owner> sameFirstNames = new();
            List<Owner> sameLastNames = new();
            List<Owner> allResults = new();

            sameFirstNames = await _context.Owners.Where(owner => owner.FirstName == name).ToListAsync();
            sameLastNames = await _context.Owners.Where(owner => owner.LastName == name).ToListAsync();

            allResults.AddRange(sameFirstNames);
            allResults.AddRange(sameLastNames);

            return allResults;
        }

        public string GetNameFromOwner(Owner owner)
        {
            return owner.FirstName + " " + owner.LastName;
        }
    }
}