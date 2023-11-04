using CourierManagementSystem.Entity.MasterData;
using CourierManagementSystem.Services.CustomerUserService.Interface;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementSystem.Services.CustomerUserService
{
    public class CustomerUserService : ICustomerUser
    {
        private readonly ApplicationDbContext _context;
        public CustomerUserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShipTracking>> GetTrackingData(string ConsignmentNumbers)
        {
            var data =  _context.ShipTrackings
                                       .Where(x => x.ConsignmentNumber.Contains(ConsignmentNumbers))
                                       .ToListAsync();


            return await data;
        }
    }
}
