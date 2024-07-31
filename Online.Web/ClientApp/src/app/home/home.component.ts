import { Component, ViewChild } from '@angular/core';
import { RegisterComponent } from '../components/student/register/register.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css',
  ]
})
export class HomeComponent {
  title = 'app';
  showRegister: boolean = false;

  @ViewChild(RegisterComponent) register!: RegisterComponent;

  Register() {
    this.showRegister = true;
  }
}
