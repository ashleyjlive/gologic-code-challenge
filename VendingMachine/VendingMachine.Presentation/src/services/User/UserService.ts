import type ErrorResponse from "@/models/ErrorResponse";
import type User from "../../models/User";

export default class UserService {
    async get(): Promise<User> {
        const response = await fetch('/api/v1.0/User');
        if(!response.ok) {
            const error = await response.json() as ErrorResponse;
            throw new Error(error.description);
        }
        return await response.json() as User;
    }
}