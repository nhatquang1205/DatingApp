import { Component, OnInit } from '@angular/core';
import { UserLogin } from '../_models/userLogin';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  user: UserLogin = {username: 'froglieri0', password: 'Pa$$w0rd'};
  constructor(public accountsService: AccountsService) { }

  ngOnInit(): void {
  }
  login(){
    this.accountsService.login(this.user).subscribe(
      (response) => console.log(response),
      (error) => console.log(error),
    );
  }
  register(){
  }
}
