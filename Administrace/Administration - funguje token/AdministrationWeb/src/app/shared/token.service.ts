import {Token} from './token.model';
import { Injectable } from "@angular/core";
import {Http} from '@angular/http';
import {HttpHeaders, HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import { map } from 'rxjs/operators';





@Injectable()
export class TokenService {
    private _options = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    constructor(private http: HttpClient, private http2: Http){


    }
    getToken(username: string, password: string): Observable<any> {

        return this.http.post('http://localhost:63699/api/Login',{username,password},this._options);

    }

    checkToken(): Observable<any> {

        return this.http.post('http://localhost:63699/api/Check',{},this._options);

    }

  

}


