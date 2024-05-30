using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        private readonly CargoContext _cargocontext;
        public EfCargoCompanyDal(CargoContext context, CargoContext cargocontext) : base(context)
        {
            _cargocontext = cargocontext;
        }

        public int GetCargoCompanyCount()
        {
            var companyCount = _cargocontext.CargoCompanies.Count();
            return companyCount;
        }
    }
}
