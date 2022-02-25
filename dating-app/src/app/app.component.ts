import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountsService } from './_services/accounts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'dating-app';

  constructor(public accountsService: AccountsService) {}

  ngOnInit() {
    this.accountsService.refreshToken();
  }
  
}
