import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel, FormsModule} from '@angular/forms'
import { AppRoutingModule } from '../app-routing.module';
import { RouterModule, Routes, RouterLink, Router, RouterLinkWithHref } from '@angular/router';
import { AdminComponent } from '../admin/admin.component';
import {TokenService} from '../shared/token.service';
import { Token } from '../shared/token.model';
import {LocalStorageService} from 'ngx-webstorage';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Observable';




@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})

export class LoginFormComponent implements OnInit {
  usertoken: Token;
  mytoken: string;
 
  constructor(private router: Router, private tokenService: TokenService, private localSt: LocalStorageService)
  {
    
   }

  ngOnInit() {
    
  }

data = {username: "",
        password: ""};
isEmpty = false;

wrongCheck = false;
test = true;
       
        
onLogIn(){
 
 

}

checkEmpty()
{
  if(this.data.username ==""){
  this.isEmpty = true;
  console.log("Username is empty")
 }
  else{
  if (this.data.password ==""){
    this.isEmpty = true;
    console.log("Password is Empty")
  }
    else{
    this.isEmpty = false;
  }
 }
 }
  testNavigate()
{
//  if(this.data.username == "admin" &&this.data.password == "admin")
 // this.router.navigateByUrl('/admin');
 // else{
 // alert("test");
 // }


if(!this.isEmpty){
  this.tokenService.getToken(this.data.username,this.data.password).subscribe(data => {
    this.mytoken=data;
    this.setLocalStorage();
    this.router.navigateByUrl('/admin')
  },
  error => { console.log("hello world"); console.log(error); });
  }

setTimeout(()=>{
if(this.mytoken!=null){

  this.setLocalStorage();
  this.router.navigateByUrl('/admin')

}

},1000)

 //.subscribe(data =>console.log(data));
 //alert(this.usertoken.tokenString.toString());
}

errorHandler(error: Response){

  if(error.status===404||error.status==503||error.status==401||error.status==402){
  
    alert("Chyba");
  }
    
  }
  
setLocalStorage(){

this.localSt.store('token',this.mytoken);

}

}


