import { Injectable } from '@angular/core';
import { Person } from './person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  readonly url: string = 'http://localhost:5122/api/person';

  constructor() { }

  async getPeople(): Promise<Person[]> {
    const response = await fetch(`${this.url}`);
    const data = await response.json();
    const people: Person[] = data.map((item: any) => ({
      id: item.id,
      createDate: new Date(item.createDate),
      firstName: item.firstName,
      lastName: item.lastName
    }));

    return people;
  }
}
