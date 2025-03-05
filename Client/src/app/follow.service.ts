import { Injectable } from '@angular/core';
import { Follow } from './follow';
import { Person } from './person';

@Injectable({
  providedIn: 'root'
})
export class FollowService {
  readonly url: string = 'http://localhost:5122/api/follower';

  constructor() { }

  async getFollowers(person: Person): Promise<Follow[]> {
    const response = await fetch(`${this.url}/${person.id}`);
    const data = await response.json();
    const follows: Follow[] = data.map((item: any) => ({
      id: item.id,
      createDate: new Date(item.createDate),
      followerId: item.followerId,
      followeeId: item.followeeId,
      followerA: item.followerA,
      followerB: item.followerB,
    }));

    return follows;
  }

  async remove(follow: Follow): Promise<any> {
    const response = await fetch(`${this.url}/${follow.id}`, { method: 'DELETE' });
    return await response.json();
  }
}
