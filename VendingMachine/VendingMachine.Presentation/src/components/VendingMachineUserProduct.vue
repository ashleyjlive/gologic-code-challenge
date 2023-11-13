<script setup lang="ts">
import type VendingMachineProduct from '@/models/VendingMachineProduct';

    defineProps<{
        product: VendingMachineProduct
    }>()
</script>

<template>
    <li class="vending-machine__user-product">
        <span> {{ product.name }} </span>
    </li>
</template>