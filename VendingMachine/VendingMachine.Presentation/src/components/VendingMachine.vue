<script lang="ts">
    import VendingMachineUser from './VendingMachineUser.vue';
    import VendingMachineMoney from './VendingMachineMoney.vue';
    import VendingMachineProductSlot from './VendingMachineProductSlot.vue';
    import VendingMachineUserProduct from './VendingMachineUserProduct.vue';
    import VendingMachineService from '@/services/VendingMachine/VendingMachineService';
    import type VendingMachine from '../models/VendingMachine'
    import type User from '../models/User';
import UserService from '../services/User/UserService';
    export default {
        data() {
            return {
                money: 0,
                vendingMachine: {} as VendingMachine,
                user: {} as User
            };
        },
        methods: {
            async fetchData() {
                const service = new VendingMachineService();
                const vendingMachine = await service.get();
                this.vendingMachine = vendingMachine;

                const userService = new UserService();
                const user = await userService.get();
                this.user = user;
            }
        },
        created() {
            this.fetchData();
        },
        components: {
            VendingMachineUser,
            VendingMachineMoney,
            VendingMachineProductSlot,
            VendingMachineUserProduct
        },
    };

</script>

<template>
    <div class="vending-machine">
        <VendingMachineMoney :money="vendingMachine.money" @money-altered="fetchData()" />
        <VendingMachineUser :money="user.money" />
        <div class="vending-machine__slots">
            <h2>
                Products
            </h2>
            <VendingMachineProductSlot :slot="slot" v-for="slot in vendingMachine.slots" @product-purchased="fetchData()">
            </VendingMachineProductSlot>
        </div>
        <ol>
            <VendingMachineUserProduct :product="product" v-for="product in user.products"></VendingMachineUserProduct>
        </ol>
    </div>
</template>

<style>
    .vending-machine {
        border: 2px solid;
        height: 80vh;
        width: 60vh;
    }
</style>