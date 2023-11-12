export default interface VendingMachine {
    money: number;
    slots: VendingMachineProductSlot[]
}

export interface VendingMachineProductSlot {
    id: string;
    quantity: number;
    product: VendingMachineProduct;
}

export interface VendingMachineProduct {
    id: string;
    name: string;
    price: number;
}