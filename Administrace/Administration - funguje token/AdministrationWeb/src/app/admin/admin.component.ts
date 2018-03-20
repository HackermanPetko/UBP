import { Component, OnInit } from '@angular/core';
import{ LocalStService } from '../shared/localstorage.service';
import { AppRoutingModule } from '../app-routing.module';
import { RouterModule, Routes, RouterLink, Router, RouterLinkWithHref } from '@angular/router';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private router: Router, private localSt:LocalStService) { }

  ngOnInit() {
  }

logoutUser(){
this.localSt.delLocalStorage();
this.router.navigateByUrl('/');
alert("You have been logged out!")

}


}
