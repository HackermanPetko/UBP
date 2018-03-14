import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-playground',
  templateUrl: './playground.component.html',
  styleUrls: ['./playground.component.css']
})
export class PlaygroundComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

num1: number;
num2: number;
sum: number;
  Sum(num1,num2)
  {
    this.Sum= num1+num2;
  }

}
