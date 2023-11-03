using CourierManagementSystem.Entity;
using CourierManagementSystem.Entity.MasterData;
using CourierManagementSystem.Services.AuthService;
using CourierManagementSystem.Services.CourierManagementService.Interface;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementSystem.Services.CourierManagementService
{
    public class CourierManagement: ICourierManagement
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
                var data = _context.Users.Where(x=>x.userTypeId==3).ToListAsync();
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
                var data = _context.Customers.Where(x=>x.Consignmentstatus==1).ToListAsync();
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
    }
}
