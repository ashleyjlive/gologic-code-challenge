<script setup lang="ts">
import type { VendingMachineProductSlot } from "../models/VendingMachine"
import VendingMachineService from "../services/VendingMachine/VendingMachineService"

    defineProps<{
        slot: VendingMachineProductSlot
    }>()

    const emit = defineEmits<{
        (e: 'product-purchased'): void
    }>()

    const notifyProductPurchased = () => {
        emit('product-purchased')
    }

    async function purchaseProduct(id: string) {
        const service = new VendingMachineService();
        await service.purchaseProduct(id);
        notifyProductPurchased();
    }
</script>

<template>
    <div class="vending-machine__product-slot">
        <button class="vending-machine__product-slot-button" @click="purchaseProduct(slot.id)">
            <span>
                {{ slot.product.name }} - ${{ slot.product.price }}
                {{ slot.quantity}} remaining
            </span>
        </button>
    </div>
</template>

<style>
    .vending-machine__product-slot-button {
        width: 100px;
        height: 100px;
    }
</style>