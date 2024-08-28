import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { TodoService, Todo } from '../todo.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss']
})
export class TodoListComponent {
  todos$ = this.todoService.getTodos();
  newTodoValue:Todo = { id : 0, title: '', isCompleted: false };
  newTodo: string = '';
  completed: string = '';
  todos: Todo[] = [];

  constructor(public todoService: TodoService, private authService: AuthService, private router: Router) {}


  addTodo(): void {
    if (this.newTodo != '') {
      this.newTodoValue.title = this.newTodo;
      this.todoService.addTodo(this.newTodoValue).subscribe({
        next: () => {
        },
        error: (e) => {
          console.log(e);
           },
        complete: () => this.todos$ = this.todoService.getTodos()
      });
      this.newTodo = '';
    }
  }

  completeTodo(id: number): void {
    if (id > 0) {
      this.todoService.completeTodo(id).subscribe({
        next: () => {
        },
        error: (e) => {
          console.log(e);
           },
        complete: () => this.todos$ = this.todoService.getTodos()
      });
   }
  }

  deleteTodo(id: number): void {
    if (id > 0) {
      this.todoService.deleteTodo(id).subscribe({
        next: () => {
        },
        error: (e) => {
          console.log(e);
           },
        complete: () => this.todos$ = this.todoService.getTodos()
      });
   }
  }
  

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']); // Redirect to the login page
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }



  
}
