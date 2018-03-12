import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel, FormsModule} from '@angular/forms'
import { AppRoutingModule } from '../app-routing.module';
import { RouterModule, Routes, RouterLink, Router, RouterLinkWithHref } from '@angular/router';
import { AdminComponent } from '../admin/admin.component';
import {TokenService} from '../shared/token.service';
import { Token } from '../shared/token.model';
import {LocalStorageService} from 'ngx-webstorage';




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
userCheck = false;
wrongCheck = false;
test = true;
       
        
onLogIn(){
 console.log(this.data);
    this.checkEmpty();
    if(this.isEmpty == true)
    {
      console.log("")
    }
    if(this.data.username == "admin" && this.data.password == "admin")
    {
      console.log("Hi admin");
      this.userCheck = false;
    }
    else{
      console.log("Wrong username or password")
      if(this.userCheck == true)
      {
      }
     else{ 
      this.userCheck = true;
     }
    }

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


 this.mytoken = this.tokenService.getToken(this.data.username,this.data.password);

 if(mytoken!=null){
 this.router.navigateByUrl('/admin');
 
 }
 else{
   alert("Wrong credentials!");
 }
 //.subscribe(data =>console.log(data));
 //alert(this.usertoken.tokenString.toString());
}


}


