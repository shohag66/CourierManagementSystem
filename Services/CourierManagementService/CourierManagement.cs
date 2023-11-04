using CourierManagementSystem.Entity;
using CourierManagementSystem.Entity.MasterData;
using CourierManagementSystem.Services.AuthService;
using CourierManagementSystem.Services.CourierManagementService.Interface;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementSystem.Services.CourierManagementService
{
    public class CourierManagement : ICourierManagement
    {
        private readonly ApplicationDbContext _context;

        public CourierManagement(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            try
            {
                var data = _context.Customers.ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllShipper()
        {
            try
            {
                var data = _context.Users.Where(x => x.userTypeId == 3).ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task<IEnumerable<Customer>> GetAllOrderedPlacedList()
        {
            try
            {
                var data = _context.Customers.Where(x => x.Consignmentstatus == 1).ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<Customer>> GetAllPickupOrderedPlacedList()
        {
            try
            {
                var data = _context.Customers.Where(x => x.Consignmentstatus == 2).ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllDeliveredOrderedPlacedList()
        {
            try
            {
                var data = _context.Customers.Where(x => x.Consignmentstatus == 3).ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<OrderDetails>> GetAlLOrderDetails()
        {
            try
            {
                var data = _context.OrderDetails.ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> SaveOrderDetails(OrderDetails orderDetails)
        {
            try
            {
                if (orderDetails.Id != 0)
                {
                    _context.OrderDetails.Update(orderDetails);
                }
                else
                {
                    _context.OrderDetails.Add(orderDetails);
                }

                await _context.SaveChangesAsync();
                return orderDetails.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveUserCustomer(Customer customer)
        {
            try
            {
                if (customer.Id != 0)
                {
                    _context.Customers.Update(customer);
                }
                else
                {
                    _context.Customers.Add(customer);
                }

                await _context.SaveChangesAsync();
                return customer.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> SaveShipTracking(ShipTracking model)
        {
            try
            {
                if (model.Id != 0)
                {
                    _context.ShipTrackings.Update(model);
                }
                else
                {
                    _context.ShipTrackings.Add(model);
                }

                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateCustomerStatus(int id,int status)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer != null)
                {
                    _context.Entry(customer).State = EntityState.Detached;
                    customer.Consignmentstatus = status;
                    _context.Customers.Attach(customer);
                    _context.Entry(customer).Property(x => x.Consignmentstatus).IsModified = true;
                    await _context.SaveChangesAsync();
                    return customer.Id;
                }
                else
                {
                    throw new Exception("Customer not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;







            }
        }
    }
}
