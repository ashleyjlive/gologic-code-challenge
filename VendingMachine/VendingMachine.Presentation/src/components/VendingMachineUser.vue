<script setup lang="ts">
    defineProps<{
        money: number
    }>()
</script>

<template>
    <div class="vending-machine__user-money">
        User money
        <span> ${{ money }}</span>
        <br />
    </div>
</template>