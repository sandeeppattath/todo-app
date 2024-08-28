import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn = new BehaviorSubject<boolean>(false);
  private apiUrl = 'http://localhost:5280/Login/login';
  
  constructor(private http: HttpClient) {}

  // isLoggedIn(): Observable<boolean> {
  //   return this.loggedIn.asObservable();
  // }


  login(username: string, password: string): Observable<string> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = JSON.stringify({ username, password });

    return this.http.post<{ token: string }>(this.apiUrl, body, { headers }).pipe(
      map(response => response.token) // Extract the token from the response
    );
  }
  
  
  //boolean {
  //   // Replace with real authentication logic
  //   if (username === 'user' && password === 'password') {
  //     this.loggedIn.next(true);
  //     return true;
  //   }
  //   return false;
  // }

  logout(): void {
    localStorage.removeItem('token');
    //this.loggedIn.next(false);
  }

  isLoggedIn(): boolean {
    // Check if the token exists in local storage
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
