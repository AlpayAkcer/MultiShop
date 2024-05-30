using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargocontext;

        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
            _cargocontext = context;
        }

        public CargoCustomer GetCargoCustomerById(string id)
        {
            var values = _cargocontext.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
            return values;
        }

        public int GetCargoCustomerCount()
        {
            int value = _cargocontext.CargoCustomers.Count();
            return value;
        }

        public List<CargoCustomer> GetCargoCustomerList(string id)
        {
            var values = _cargocontext.CargoCustomers.Where(x => x.UserCustomerId == id).ToList();
            return values;
        }
    }
}
