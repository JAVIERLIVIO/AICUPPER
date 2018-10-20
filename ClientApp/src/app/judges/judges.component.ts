import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-judges',
  templateUrl: './judges.component.html',
  styleUrls: ['./judges.component.css']
})
export class JudgesComponent {
  public judges: Judge[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Judge[]>(baseUrl + 'api/Judges/List').subscribe(result => {
      this.judges = result;
    }, error => console.error(error));
  }
}

interface Judge {
  id: number;
  aICupperAccountID: string;
  judgeName: string;
  knownAs: string;
  emailAddress: string;
  phoneNumber: string;
  createdOn: Date;
  isEnabled: boolean;
}