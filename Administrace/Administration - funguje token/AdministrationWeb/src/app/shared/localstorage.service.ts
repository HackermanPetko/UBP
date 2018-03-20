import {LocalStorageService} from 'ngx-webstorage';
import { Injectable } from "@angular/core";

@Injectable()
export class LocalStService {
    
    constructor(private localSt: LocalStorageService){


    }
    setLocalStorage(token:string){

        this.localSt.store('token',token);
        
        }

    getLocalStorage(){

       return this.localSt.retrieve('token');

    }

    delLocalStorage(){

        this.localSt.clear('token');

    }

  

}
