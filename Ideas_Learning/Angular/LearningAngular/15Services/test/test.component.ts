import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-test',
  template: 
            `
            
            `,
  styles: [`
   
  `]
})
export class TestComponent implements OnInit {

  public name = "LearningAngular"
  public message = "Welcome to learning with petko"
  public text = "Petricek"
  public person = {
    "firstName": "John",
    "lastName" : "Doe"
  }
  public date = new Date();
 
 constructor() { }

  ngOnInit() {
  }



}
