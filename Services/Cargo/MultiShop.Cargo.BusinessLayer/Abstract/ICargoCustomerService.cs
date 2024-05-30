using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        CargoCustomer TGetCargoCustomerById(string id);

        List<CargoCustomer> TGetCargoCustomerList(string id);
        int TGetCargoCustomerCount();
    }
}
