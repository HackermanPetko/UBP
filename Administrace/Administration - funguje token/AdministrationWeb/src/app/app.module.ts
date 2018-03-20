import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule } from '@angular/http';
import { AppRoutingModule} from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { AdminComponent } from './admin/admin.component';
import { RouterModule, Routes } from '@angular/router';
import {TokenService} from './shared/token.service';
import { HttpClientModule } from '@angular/common/http';
import {Ng2Webstorage, LocalStorage} from 'ngx-webstorage';
import { LocalStService } from './shared/localstorage.service';





@NgModule({
  declarations: [
    LoginFormComponent,
    AppComponent,
    AdminComponent,
    
    
    
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    Ng2Webstorage
   
  ],
  providers: [TokenService, HttpClientModule, LocalStService],
  bootstrap: [AppComponent]
})
export class AppModule { }
