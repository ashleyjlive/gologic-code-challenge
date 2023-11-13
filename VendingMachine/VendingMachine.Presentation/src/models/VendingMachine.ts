import type VendingMachineProductSlot from "./VendingMachineProductSlot";

export default interface VendingMachine {
    money: number;
    slots: VendingMachineProductSlot[]
}