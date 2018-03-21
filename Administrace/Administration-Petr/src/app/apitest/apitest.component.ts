import { Component, OnInit } from '@angular/core';
import { DaemonsService } from '../daemonsService.service';
import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient, HttpParams} from '@angular/common/http'
import 'rxjs/add/operator/map'
import {Http} from '@angular/http';
import {HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import { map } from 'rxjs/operators';
import { NgModule} from '@angular/core'
import { daemons } from '../daemons.model';
import {TokenInterceptor} from './token.interceptor';

@Component({
  selector: 'app-apitest',
  templateUrl: './apitest.component.html',
  styleUrls: ['./apitest.component.css']
})
export class ApiTestComponent implements OnInit {
  constructor(private http: HttpClient) { }

  readonly ROOT_URL = 'http://localhost:63699/api/Config';
  posts: Observable<any>;
  newPost: Observable<any>;

  getPosts()
  {
      let headers = new HttpHeaders().set('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkRlbW8iLCJuYmYiOjE1MjEzNzM5MjYsImV4cCI6MTUyMTk3ODcyNiwiaWF0IjoxNTIxMzczOTI2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo2MzY5OSJ9.Bg2kNnllrEhJNQc2EVvhWcno9c2fTb-9801Dgeahz8s')
    let params = new HttpParams().set('id', '1')
    this.posts = this.http.get(this.ROOT_URL, {headers})
  }

  createPost()
  {
    const data  = [{
       Id: 2,
      IsNew: true,
      DaemonName: "Test-PC",
      DaemonMAC: "AB-68-8C-F0-21-5B",
      LastConnected: "2018-03-03T00:00:00",
      Comment: "TestováníPostu"
    }]
    let headers = new HttpHeaders().set('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkRlbW8iLCJuYmYiOjE1MjEzNzM5MjYsImV4cCI6MTUyMTk3ODcyNiwiaWF0IjoxNTIxMzczOTI2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo2MzY5OSJ9.Bg2kNnllrEhJNQc2EVvhWcno9c2fTb-9801Dgeahz8s')
    this.newPost = this.http.post(this.ROOT_URL , data, {headers})
  }
  post()
{
  let headers = new HttpHeaders().set('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkRlbW8iLCJuYmYiOjE1MjEzNzM5MjYsImV4cCI6MTUyMTk3ODcyNiwiaWF0IjoxNTIxMzczOTI2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo2MzY5OSJ9.Bg2kNnllrEhJNQc2EVvhWcno9c2fTb-9801Dgeahz8s')
  const req = this.http.post(this.ROOT_URL,{headers} )
      .subscribe(
        res => {
          console.log(res);
        },
        err => {
          console.log("Error occured");
        }
      );
}

  ngOnInit() {
  }

}
