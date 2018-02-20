import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';


@Component({
  selector: 'app-employee-list',
  template: `<h2>Employee List</h2>
  <ul *ngFor="let employee of employees">
  <li>
     {{employee.Name}}         
  </li> 

  </ul>
  
  `,
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
 public employees =  [];

  constructor(private _employeeService: EmployeeService) { }

  ngOnInit() {
    this.employees = this._employeeService.getEmployees();
  }

}
