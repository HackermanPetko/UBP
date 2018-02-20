import { Injectable } from '@angular/core';

@Injectable()
export class EmployeeService {
  getEmployees()
  {return[
    {"id": 1, "Name": "Petr","age":30},
    {"id": 2, "Name": "Adam","age":15},
    {"id": 3, "Name": "Marek","age":24},
    {"id": 4, "Name": "Dan","age":53}];
  }
  constructor() { }

}
