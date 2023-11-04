using CourierManagementSystem.Entity.MasterData;
using CourierManagementSystem.Services.ShipperService.Interface;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementSystem.Services.ShipperService
{
    public class Shipper:IShipper
    {
        private readonly ApplicationDbContext _context;

        public Shipper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetShipperAssignOrderedList(string shipperId)
        {
			try
			{
                var data=_context.Customers.Include(x => x.ApplicationUser).Where(x => x.ApplicationUserId == shipperId && x.Consignmentstatus==1).ToListAsync();
                return await data;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }
        public async Task<IEnumerable<Customer>> GetShipperPickupOrderedList(string shipperId)
        {
            try
            {
                var data = _context.Customers.Include(x => x.ApplicationUser).Where(x => x.ApplicationUserId == shipperId && x.Consignmentstatus == 2).ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<Customer>> GetShipperDeliveredOrderedList(string shipperId)
        {
            try
            {
                var data = _context.Customers.Include(x => x.ApplicationUser).Where(x => x.ApplicationUserId == shipperId && x.Consignmentstatus == 3).ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllDetailsPickupByShipper()
        {
            try
            {
                var data = _context.Customers.Include(x => x.ApplicationUser).Where(x=>x.Consignmentstatus==2 || x.Consignmentstatus == 3).ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Customer> GetOrderInfoById(int Id)
        {
            try
            {
                var data = _context.Customers.Include(x => x.ApplicationUser).Where(x => x.Id==Id).FirstOrDefaultAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
