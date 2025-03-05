import { Follow } from "./follow";

export interface Person {
    id: string,
    createDate: Date,
    firstName: string,
    lastName: string,
    following: Follow[]
}