using BoardingKennelBookings.Components.Data;
using BoardingKennelBookings.Components.Models;

namespace BoardingKennelBookings.Components.Services
{
    public class KennelAvailabilityService
    {
        private readonly KennelContext _context;

        public KennelAvailabilityService(KennelContext context) 
        { 
            _context = context;
        }

        public async Task<bool> CheckKennelAvailability(DateTime startDate, DateTime endDate, int kennelID)
        {

            return false;
        }

        //chech all kennels
        //add is clean check later - shouldnt be hard to implement right!?
        public async Task<List<Kennel>> GetAllKennelsAvailable(DateTime startDate, DateTime endDate)
        {

        }
    }
}
