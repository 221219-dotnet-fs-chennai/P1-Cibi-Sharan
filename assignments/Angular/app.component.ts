import { Component } from '@angular/core';
import {NgForm} from '@angular/forms';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // title = 'second-demo';
  // userarr = ['Matt', 'Ratt', 'Hatt'];
  // userlist = [
  //   {name:'Matt', salary:50000, location:'Los Angeles', skills:['C', 'Java']},
  //   {name:'Ratt', salary:70000, location:'New York City', skills: ['C++', 'Python']}
  // ]
  checked = false;
  indeterminate = false;
  labelPosition: 'before' | 'after' = 'after';
  disabled = false;
}
