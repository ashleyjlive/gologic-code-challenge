using System.Text.Json;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;
using VendingMachine.Infrastructure.Repositories.User.Models;
using VendingMachine.Infrastructure.Repositories.VendingMachine.Models;

namespace VendingMachine.Infrastructure.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly string _filePath = "data";
        private readonly string _fileName = "data/user.json";

        public Domain.Aggregates.User Get()
        {
            if (_GetFromDisk() is Domain.Aggregates.User user)
            {
                return user;
            }
            var dummy = _CreateDummy();
            Save(dummy);
            return dummy;
        }

        public void Save(Domain.Aggregates.User user)
        {
            var userString = JsonSerializer.Serialize(_ToDbType(user));
            Directory.CreateDirectory(_filePath);
            File.WriteAllText(_fileName, userString);
        }

        private Domain.Aggregates.User? _GetFromDisk()
        {
            try
            {
                var userString = File.ReadAllText(_fileName);
                var dbUser = JsonSerializer.Deserialize<DbUser>(userString)!;
                return _FromDbType(dbUser);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (DirectoryNotFoundException)
            {
                return null;
            }
        }

        private Domain.Aggregates.User _FromDbType(DbUser dbUser)
        {
            return new Domain.Aggregates.User(
                id: dbUser.Id,
                money: Money.FromAmount(dbUser.Money),
                products: dbUser.Products.Select(_FromDbType));
        }

        private VendingMachineProduct _FromDbType(DbVendingMachineProduct dbVendingMachineProduct)
        {
            return new VendingMachineProduct(
                id: dbVendingMachineProduct.Id,
                name: dbVendingMachineProduct.Name,
                price: Money.FromAmount(dbVendingMachineProduct.Price));
        }

        private DbUser _ToDbType(Domain.Aggregates.User user)
        {
            return new DbUser(user.Id, user.Money.Amount, user.Products.Select(_ToDbType).ToList());
        }

        private DbVendingMachineProduct _ToDbType(VendingMachineProduct vendingMachineProduct)
        {
            return new DbVendingMachineProduct(
                id: vendingMachineProduct.Id,
                name: vendingMachineProduct.Name,
                price: vendingMachineProduct.Price.Amount);
        }

        private Domain.Aggregates.User _CreateDummy()
        {
            return Domain.Aggregates.User.Create(Money.FromAmount(50), Enumerable.Empty<VendingMachineProduct>());
        }
    }
}