import { NgFor, NgIf } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Follow } from '../follow';
import { FollowService } from '../follow.service';
import { Person } from '../person';
import { PersonService } from '../person.service';

@Component({
  selector: 'app-home',
  imports: [NgFor, NgIf],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent {
  people: Person[] = [];
  person?: Person;
  personService: PersonService = inject(PersonService);
  followService: FollowService = inject(FollowService);

  constructor() {
    this.init();
  }

  async init() {
    const result = await this.personService.getPeople();
    this.people = result;
  }

  async showDetails(person: Person) {
    this.person = person;
    this.person.following = await this.followService.getFollowers(this.person);
  }

  async deleteFollow(follow: Follow) {
    this.followService.remove(follow);
    if (this.person && this.person.following) {
      this.person.following = this.person.following.filter(f => f !== follow);
    }
  }
}
