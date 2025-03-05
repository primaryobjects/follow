import { Person } from "./person";

export interface Follow {
    id: string,
    createDate: Date,
    followerId: string,
    followeeId: string,
    followerA?: Person,
    followerB?: Person
}