import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-form-controls',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit {
  customStylesValidated = false;
  
  constructor() { }

  ngOnInit(): void { }

  onSubmit1() {
    this.customStylesValidated = true;
    console.log('Submit... 1');
  }
}
