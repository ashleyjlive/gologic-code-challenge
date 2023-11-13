import type  VendingMachineProduct from "./VendingMachineProduct";

export default interface User {
    money: number;
    products: VendingMachineProduct[];
}