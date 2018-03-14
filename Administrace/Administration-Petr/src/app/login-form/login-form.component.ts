import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel, FormsModule} from '@angular/forms'
import { AppRoutingModule } from '../app-routing.module';
import { RouterModule, Routes, RouterLink, Router, RouterLinkWithHref } from '@angular/router';
import { AdminComponent } from '../admin/admin.component';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})

export class LoginFormComponent implements OnInit {

  constructor(public router: Router)
  { }

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
  if(this.data.username == "admin" &&this.data.password == "admin")
  this.router.navigateByUrl('/admin');
  else{
  alert("test");
  }
}
}

