import {Token} from './token.model';
import { Injectable } from "@angular/core";
import {Http} from '@angular/http';
import {HttpHeaders, HttpClient} from '@angular/common/http';



@Injectable()
export class TokenService {
    private _options = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    constructor(private http: HttpClient, private http2: Http){


    }

    getToken(username: string, password: string) {

        return this.http.post('http://localhost:63699/api/Token',{username,password},this._options).subscribe(data =>console.log(data));
       

    }

  

}


