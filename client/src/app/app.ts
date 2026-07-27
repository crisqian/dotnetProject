import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { lastValueFrom } from 'rxjs/internal/lastValueFrom';

@Component({
  // matches that in index.html file
  // this means replace where app-root holds with content from ./app.html file 
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App implements OnInit {
  private http = inject(HttpClient);
  // templateUrl is considered child to this class
  // so app.html can access the title property
  protected readonly title = 'Pet Permit Portal';
  protected readonly description = 'Submit and track pet permit applications';
  protected members = signal<any>([]);

  async ngOnInit() {
    this.members.set(await this.getMembers());
  }
  
  // return a promise
  async getMembers() {
    try {
      return lastValueFrom(this.http.get('https://localhost:5001/api/members'));
    } catch (error) {
      console.error(error);
      throw error;
    }
  }

}

// Controller + model of app component
