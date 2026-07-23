import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';

@Component({
  // matches that in index.html file
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private http = inject(HttpClient);
  // templateUrl is considered child to this class
  // so app.html can access the title property
  protected readonly title = 'Dating app';
  protected members: any;

  ngOnInit(): void {
    // http requests will auto unsubscribe 
    this.http.get('https://localhost:5001/api/members').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.error(error),
      complete: () => console.log('fetch members request completed')
    });
  }

}
