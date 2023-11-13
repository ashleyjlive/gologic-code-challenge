import type VendingMachineProduct from "./VendingMachineProduct";

export default  interface VendingMachineProductSlot {
    id: string;
    quantity: number;
    product: VendingMachineProduct;
}