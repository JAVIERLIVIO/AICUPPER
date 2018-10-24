import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-judges',
  templateUrl: './judges.component.html',
  styleUrls: ['./judges.component.css']
})
export class JudgesComponent implements OnInit {
  public judges: Judge[];
  public apiOperativeStatus: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(baseUrl);
    http.get<Judge[]>(baseUrl + 'api/Judges/List').subscribe(result => {
      this.judges = result;
    }, error => this.apiOperativeStatus = "No records");
  }

  ngOnInit() {
      this.apiOperativeStatus = "Loading...";
    }
}

interface Judge {
  judgeID: number;
  aICupperAccountID: string;
  judgeName: string;
  knownAs: string;
  emailAddress: string;
  phoneNumber: string;
  createdOn: Date;
  isEnabled: boolean;
}