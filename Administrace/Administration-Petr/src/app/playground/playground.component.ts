import { Component, OnInit } from '@angular/core';
import { DaemonsService } from '../daemonsService.service';
import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import 'rxjs/add/operator/map'
import {Http} from '@angular/http';
import {HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import { map } from 'rxjs/operators';
import { NgModule} from '@angular/core'
import { daemons } from '../daemons.model';


@Component({
  selector: 'app-playground',
  templateUrl: './playground.component.html',
  styleUrls: ['./playground.component.css']
})

export class PlaygroundComponent implements OnInit {
  providers: [DaemonsService]
data: Observable<Array<daemons>>;
constructor(private _svc: DaemonsService) {}

getData(){
  
this.data = this._svc.getData();
}




  ngOnInit() {
 
  }


}
