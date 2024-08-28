import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthService} from './auth.service';

export interface Todo {
  id: number;
  title: string;
  isCompleted: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private todos = new BehaviorSubject<Todo[]>([]);
  private nextId = 1;
  private apiBaseUrl = 'http://localhost:5280/Todo';  
  private token = this.authService.getToken();

  constructor(private http: HttpClient, private authService: AuthService ) {}

  getTodos(): Observable<Todo[]> {

    const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${this.token}` });

    return this.http.get<Todo[]>(this.apiBaseUrl, { headers });
  }
  // getTodos() {
  //   return this.todos.asObservable();
  // }

  addTodo(todo: Todo): Observable<Todo> {

    const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${this.token}` });

    const body = JSON.stringify({ todo });

    return this.http.post<Todo>(this.apiBaseUrl, todo, { headers });
  }

  completeTodo(todo: number): Observable<void> {

     const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${this.token}` });
     
     return this.http.post<void>(this.apiBaseUrl+"/complete", todo, { headers });
  }

  deleteTodo(id: number): Observable<void>{
    console.log(id);
    const headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${this.token}` });
    return this.http.delete<void>(`${this.apiBaseUrl}/${id}`, { headers });
  }
}
