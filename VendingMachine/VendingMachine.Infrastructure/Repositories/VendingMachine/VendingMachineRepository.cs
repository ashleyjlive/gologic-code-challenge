using System.Text.Json;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;
using VendingMachine.Infrastructure.Repositories.VendingMachine.Models;

namespace VendingMachine.Infrastructure.Repositories.VendingMachine
{
    public class VendingMachineRepository : IVendingMachineRepository
    {
        private readonly string _filePath = "data";
        private readonly string _fileName = "data/vendingMachine.json";

        public Domain.Aggregates.VendingMachine Get()
        {
            return _GetFromDisk() ?? throw new InvalidOperationException();
        }

        public void Save(Domain.Aggregates.VendingMachine vendingMachine)
        {
            var vendingMachineString = JsonSerializer.Serialize(_ToDbType(vendingMachine));
            Directory.CreateDirectory(_filePath);
            File.WriteAllText(_fileName, vendingMachineString);
        }

        private Domain.Aggregates.VendingMachine? _GetFromDisk()
        {
            try
            {
                var vendingMachineString = File.ReadAllText(_fileName);
                var dbVendingMachine = JsonSerializer.Deserialize<DbVendingMachine>(vendingMachineString)!;
                return _FromDbType(dbVendingMachine);
            } catch (FileNotFoundException)
            {
                return null;
            } catch (DirectoryNotFoundException)
            {
                return null;
            }
        }

        private Domain.Aggregates.VendingMachine _FromDbType(DbVendingMachine vendingMachine)
        {
            return new Domain.Aggregates.VendingMachine(
                id: vendingMachine.Id,
                productSlots: vendingMachine.Slots.Select(_FromDbType),
                moneyBox: Money.FromAmount(vendingMachine.Money));
        }

        private VendingMachineProductSlot _FromDbType(DbVendingMachineProductSlot dbVendingMachineProductSlot)
        {
            return new VendingMachineProductSlot(
                id: dbVendingMachineProductSlot.Id,
                product: _FromDbType(dbVendingMachineProductSlot.Product),
                stock: Quantity.FromValue(dbVendingMachineProductSlot.Quantity));
        }

        private VendingMachineProduct _FromDbType(DbVendingMachineProduct dbVendingMachineProduct)
        {
            return new VendingMachineProduct(
                id: dbVendingMachineProduct.Id,
                name: dbVendingMachineProduct.Name,
                price: Money.FromAmount(dbVendingMachineProduct.Price));
        }

        private DbVendingMachine _ToDbType(Domain.Aggregates.VendingMachine vendingMachine)
        {
            return new DbVendingMachine(
                id: vendingMachine.Id,
                money: vendingMachine.MoneyBox.Amount,
                slots: vendingMachine.ProductSlots.Select(_ToDbType).ToList());
        }

        private DbVendingMachineProductSlot _ToDbType(VendingMachineProductSlot vendingMachineProductSlot)
        {
            return new DbVendingMachineProductSlot(
                id: vendingMachineProductSlot.Id,
                product: _ToDbType(vendingMachineProductSlot.Product),
                quantity: vendingMachineProductSlot.Stock.Value);
        }

        private DbVendingMachineProduct _ToDbType(VendingMachineProduct vendingMachineProduct)
        {
            return new DbVendingMachineProduct(
                id: vendingMachineProduct.Id,
                name: vendingMachineProduct.Name,
                price: vendingMachineProduct.Price.Amount);
        }
    }
}
