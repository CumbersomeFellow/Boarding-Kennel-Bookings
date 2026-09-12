using BoardingKennelBookings.Components.Data;
using BoardingKennelBookings.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardingKennelBookings.Components.Services
{
    public class KennelService
    {
        private readonly KennelContext _context;

        public KennelService(KennelContext context)
        {
            _context = context;
        }

        public async Task<Kennel> CreateKennelAsync(Kennel kennel)
        {

            if (await _context.Kennels.AnyAsync(k => k.KennelNumber == kennel.KennelNumber)) {
                throw new InvalidOperationException("Kennel already exists.");
            }

            _context.Kennels.Add(kennel);

            await _context.SaveChangesAsync();

            return kennel;
        }

        public async Task<List<Kennel>> GetAllKennels()
        {
            return await _context.Kennels.ToListAsync();
        }

        public async Task<Kennel> GetKennel(int kennelID)
        {
            List<Kennel> allKennels = await _context.Kennels.ToListAsync();

            return allKennels.Where(kennel => kennel.KennelID == kennelID).Single();
        }
    }
}
