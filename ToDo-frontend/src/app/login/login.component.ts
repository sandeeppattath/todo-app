import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  error: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.username, this.password).subscribe({
      next: (token) => {
        console.log('JWT Token:', token);
        localStorage.setItem('token', token); // Store the token for later use
      },
      error: (e) => {
           console.error('Login failed', e);
         },
      complete: () => this.router.navigate(['/todos'])
    });

  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']); // Redirect to the login page
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }
}
