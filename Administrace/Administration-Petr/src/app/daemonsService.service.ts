import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient, HttpParams} from '@angular/common/http'
import {HttpHeaders} from '@angular/common/http';
import { daemons, Tasks } from './daemons.model';
import {Observable} from 'rxjs/observable'




@Injectable()
export class DaemonsService {
  apiAdress: string;
  data: Array<daemons> = [];
  constructor(private _http: HttpClient){
  this.apiAdress = 'http://localhost:63699/api/Config'
  }
  getData(): Observable<Array<daemons>> {
    let headers = new HttpHeaders().set('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkRlbW8iLCJuYmYiOjE1MjE2MzIzODksImV4cCI6MTUyMjIzNzE4OSwiaWF0IjoxNTIxNjMyMzg5LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo2MzY5OSJ9.G9XLdQ1jTuxBvIg3JclMYUHT6SmRoUPUfUvfEdjJ4uA')
    return this._http.get<Array<daemons>>(this.apiAdress, {headers})
  }
}
