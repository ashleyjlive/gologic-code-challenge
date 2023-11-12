using VendingMachine.Application.Handlers.Queries;
using VendingMachine.Application.Models.VendingMachine;
using VendingMachine.Application.Queries.VendingMachine;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;
using VendingMachine.Infrastructure.Repositories.VendingMachine;

namespace VendingMachine.Application.Tests.QueryTests
{
    public class when_get_vending_machine_query_handled
    {
        private readonly IVendingMachineRepository _vendingMachineRepository = Substitute.For<IVendingMachineRepository>();
        private readonly GetVendingMachineQueryHandler _queryHandler;
        private readonly GetVendingMachineQuery _query;
        private readonly VendingMachineDto _vendingMachineDto;

        public when_get_vending_machine_query_handled()
        {
            var product = VendingMachineProduct.Create("Foo", Money.FromAmount(10));
            var productSlot = VendingMachineProductSlot.Create(product, Quantity.FromValue(10));
            var vendingMachine = Domain.Aggregates.VendingMachine.Create(
                productSlots: new List<VendingMachineProductSlot>() { productSlot },
                moneyBox: Money.FromAmount(50));
            _vendingMachineRepository.Get().Returns(vendingMachine);

            _queryHandler = new GetVendingMachineQueryHandler(
                _vendingMachineRepository);

            _query = new GetVendingMachineQuery();

            _vendingMachineDto = _queryHandler.Handle(_query, CancellationToken.None).Result;
        }

        [Test]
        public void then_vending_machine_money_matches()
        {
            _vendingMachineDto.Money.ShouldBe(50);
        }

        [Test]
        public void then_vending_machine_slots_match()
        {
            var slot = _vendingMachineDto.Slots.ShouldHaveSingleItem();
            slot.Quantity.ShouldBe((uint)10);
            slot.Product.Name.ShouldBe("Foo");
            slot.Product.Price.ShouldBe(10);
        }
    }
}
