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

  /*createPost() Zkouška nějaký kraviny
  {
    const data  = {
       Id: 7,
      IsNew: true,
      DaemonName: "Test-PC",
      DaemonMAC: "AB-68-8C-F0-21-5B",
      LastConnected: "2018-03-03T00:00:00",
      Comment: "TestováníPostu"
    }
    this.newPost = this.http.post(this.ROOT_URL + '/posts', data)
  }*/
 /* post()
{
  let headers = new HttpHeaders().set('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkRlbW8iLCJuYmYiOjE1MjE2MzIzODksImV4cCI6MTUyMjIzNzE4OSwiaWF0IjoxNTIxNjMyMzg5LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo2MzY5OSJ9.G9XLdQ1jTuxBvIg3JclMYUHT6SmRoUPUfUvfEdjJ4uA')
  const req = this.http.post(this.ROOT_URL,{
    Id: 7,
   IsNew: true,
   DaemonName: "Test-PC",
   DaemonMAC: "AB-68-8C-F0-21-5B",
   LastConnected: "2018-03-03T00:00:00",
   Comment: "TestováníPostu"
 }, {headers})
      .subscribe(
        res => {
          console.log(res);
        },
        err => {
          console.log("Error occured");
        }
      );
}*/

postUser()
{
  let headers = new HttpHeaders().set('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkRlbW8iLCJuYmYiOjE1MjE2MzIzODksImV4cCI6MTUyMjIzNzE4OSwiaWF0IjoxNTIxNjMyMzg5LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo2MzY5OSJ9.G9XLdQ1jTuxBvIg3JclMYUHT6SmRoUPUfUvfEdjJ4uA')
  const req = this.http.post("http://localhost:63699/api/backups",{
      Id: 3,
      IdDaemon: 3,
      IdTask: 1,
      State: false,
      ErrorMsg: "TestPost",
      Date: "2018-03-06T00:00:00",
      LogLocation: "JsemGodNeboNe?"
  }
 , {headers})
      .subscribe(
        res => {
          console.log(res);
        },
        err => {
          console.log("Error occured");
        }
      );
}


postConfig()
{
  let headers = new HttpHeaders().set('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkRlbW8iLCJuYmYiOjE1MjE2MzIzODksImV4cCI6MTUyMjIzNzE4OSwiaWF0IjoxNTIxNjMyMzg5LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo2MzY5OSJ9.G9XLdQ1jTuxBvIg3JclMYUHT6SmRoUPUfUvfEdjJ4uA')
  const req = this.http.post("http://localhost:63699/api/config",{
    
      Id: 2,
      idDaemon: 3,
      Comment: "TESTPOSTCANCER",
      LastChecked: "2018-03-02T00:00:00",
      TimeStamp: "2018-03-04T11:30:39+01:00",
      Tasks: [
          {
              Id: 3,
              IdConfig: 4,
              BackupType: 2,
              Format: 0,
              RepeatInterval: 0,
              Sources: [
                  {
                      Id: 1,
                      IdTask: 1,
                      SourcePath: "c:\\Source"
                  },
                  {
                      Id: 2,
                      IdTask: 1,
                      SourcePath: "c:\\Source2"
                  }
              ],
              Destinations: [
                  {
                      Id: 5,
                      IdTask: 1,
                      DestinationType: "SFTP",
                      DestinationAddress: "localhost",
                      DestinationUser: "test",
                      DestinationPassword: "test",
                      Port: "22"
                  },
                  {
                      Id: 2,
                      IdTask: 1,
                      DestinationType: "LOCAL",
                      DestinationAddress: "c:\\destination",
                      DestinationUser: null,
                      DestinationPassword: null,
                      Port: null
                  },
                  {
                      Id: 3,
                      IdTask: 1,
                      DestinationType: "LOCAL",
                      DestinationAddress: "c:\\destination2",
                      DestinationUser: null,
                      DestinationPassword: null,
                      Port: null
                  },
                  {
                      Id: 4,
                      IdTask: 1,
                      DestinationType: "FTP",
                      DestinationAddress: "localhost",
                      DestinationUser: "test",
                      DestinationPassword: "test",
                      Port: "21"
                  }
              ]
          }
      ]
  
  }
 , {headers})
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
