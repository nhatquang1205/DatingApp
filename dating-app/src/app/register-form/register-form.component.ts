import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UserRegister } from '../_models/user';
import { AccountsService } from '../_services/accounts.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  user: UserRegister = new UserRegister();
  @Output() cancelRegister = new EventEmitter();
  constructor(private accountsService: AccountsService  ) { }

  ngOnInit(): void {
  }
  register()
  {
    this.accountsService.register(this.user).subscribe(
      (response) => this.cancel()
    );
  }
  cancel()
  {
    this.cancelRegister.emit('false');
  }
}
