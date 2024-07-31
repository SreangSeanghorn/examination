import { AfterViewInit, Component } from '@angular/core';
import * as $ from 'jquery';
declare var bootstrap: any;
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements AfterViewInit {
  modalInstance: any;

  ngAfterViewInit(): void {
    const modalElement = document.getElementById('registerModal');
    this.modalInstance = new bootstrap.Modal(modalElement);
  }

  isregistered = false;

  register(): void {
    console.log('Register');
    this.modalInstance.hide();
  }

}
