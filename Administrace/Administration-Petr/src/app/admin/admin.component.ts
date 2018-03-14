import { Component, OnInit, ViewChild } from '@angular/core';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatTableDataSource } from '@angular/material';
import { RouterModule, Routes, Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  displayedColumns = ['id', 'name', 'phoneNum', 'eMail', 'Adress'];
  dataSource = new MatTableDataSource<Administrators>(_DATA);
  

 
  constructor(private router : Router) { }
navigatePlayground()
  {
    this.router.navigateByUrl('/playground');
  }
  navigateHome()
  {
    this.router.navigateByUrl('/')
  }
  
  ngOnInit() {
  }
 
  }

const _DATA: Administrators[] = [
  {id: 1, name: 'Petr', phoneNum: 123456789, eMail: 'petr@gmail.com', Adress:'most 1'},
  {id: 2, name: 'Petr', phoneNum: 123456789, eMail: 'petr@gmail.com', Adress:'most 1'},
  {id: 3, name: 'Petr', phoneNum: 123456789, eMail: 'petr@gmail.com', Adress:'most 1'},
  {id: 4, name: 'Petr', phoneNum: 123456789, eMail: 'petr@gmail.com', Adress:'most 1'},
  
];

export interface Administrators
{
  id: number;
  name: string;
  phoneNum: number;
  eMail: string;
  Adress: string;
  
}
