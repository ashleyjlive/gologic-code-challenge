import type ErrorResponse from "@/models/ErrorResponse";
import type VendingMachine from "@/models/VendingMachine";

export default class VendingMachineService {
    async get(): Promise<VendingMachine> {
        const response = await fetch('/api/v1.0/VendingMachine');
        if(!response.ok) {
            const error = await response.json() as ErrorResponse;
            throw new Error(error.description);
        }
        return await response.json() as VendingMachine;
    }

    async addMoney(amount: number): Promise<void> {
        const response = await fetch(`/api/v1.0/VendingMachine/Money/Add?amount=${amount}`, {
            method: 'POST'
        });
        if (!response.ok) {
            const error = await response.json() as ErrorResponse;
            throw new Error(error.description);
        }
    }

    async returnChange(): Promise<void> {
        const response = await fetch(`/api/v1.0/VendingMachine/ReturnChange`, {
            method: 'POST'
        });
        if (!response.ok) {
            const error = await response.json() as ErrorResponse;
            throw new Error(error.description);
        }
    }

    async purchaseProduct(slotId: string): Promise<void> {
        const response = await fetch(`/api/v1.0/VendingMachine/Purchase?slotId=${slotId}`, {
            method: 'POST'
        });
        if (!response.ok) {
            const error = await response.json() as ErrorResponse;
            throw new Error(error.description);
        }
    }
}