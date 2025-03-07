import { NgIf } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../material.module';
import { Follow } from '../follow';
import { FollowService } from '../follow.service';
import { Person } from '../person';
import { PersonService } from '../person.service';

@Component({
  selector: 'app-home',
  imports: [NgIf, MaterialModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent {
  people: Person[] = [];
  person?: Person;
  personService: PersonService = inject(PersonService);
  followService: FollowService = inject(FollowService);
  displayedColumns: string[] = ['firstName', 'lastName'];

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
    if (confirm(`Are you sure you would like to remove ${follow.followerB?.firstName} ${follow.followerB?.lastName}?`)) {
      this.followService.remove(follow);
      if (this.person && this.person.following) {
        this.person.following = this.person.following.filter(f => f !== follow);
      }
    }
  }
}
