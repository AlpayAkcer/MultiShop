using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public void TDelete(int id)
        {
            _cargoDetailDal.Delete(id);
        }

        public List<CargoDetail> TGetAllList()
        {
            return _cargoDetailDal.GetAllList();
        }

        public CargoDetail TGetById(int id)
        {
            return _cargoDetailDal.GetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            _cargoDetailDal.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetailDal.Update(entity);
        }
    }
}
