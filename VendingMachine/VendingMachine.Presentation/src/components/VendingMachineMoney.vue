<script setup lang="ts">
    import VendingMachineService from "../services/VendingMachine/VendingMachineService";

    defineProps<{
        money: number
    }>()

    const emit = defineEmits<{
        (e: 'money-altered'): void
    }>()

    const notifyMoneyAltered = () => {
        emit('money-altered')
    }

    async function returnChange() {{
        const service = new VendingMachineService();
        await service.returnChange();
        notifyMoneyAltered();
    }}

    async function addMoney() {
        const moneyStr = prompt('How much money?');
        if (!moneyStr) {
            return;
        }
        const money = Number.parseFloat(moneyStr);
        const service = new VendingMachineService();
        await service.addMoney(money);
        notifyMoneyAltered();
    }
</script>

<template>
    <div class="vending-machine__money">
        Inserted money
        <span> ${{ money }}</span>
        <br />
        <button @click="addMoney()">
            Add money
        </button>
        <button @click="returnChange()">
            Return change
        </button>
    </div>
</template>