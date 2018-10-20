declare var require: any;
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public aicupperlogo = require('../content/images/ai.cupper.logo.png');
}
