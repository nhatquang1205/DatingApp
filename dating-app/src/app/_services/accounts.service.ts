import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { __values } from 'tslib';
import { UserRegister, UserToken } from '../_models/user';
import { UserLogin } from '../_models/userLogin';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type':'application/json'}),
  };
  baseUrl = 'https://localhost:5001/api/accounts';
  private currentUser = new BehaviorSubject<UserToken | null>(null);
  currentUser$ = this.currentUser.asObservable();
  constructor(private httpClient: HttpClient) { }
  login(userLogin: UserLogin): Observable<any>{
    return this.httpClient.post<any>(`${this.baseUrl}/login`,userLogin,this.httpOptions)
    .pipe(
      map((response: UserToken) => {
        const user = response;
        if (user)
        {
          localStorage.setItem('userToken', JSON.stringify(user))
          this.currentUser.next(user);
        }
      })
    );
  }
  register(userRegister: UserRegister): Observable<any>{
    return this.httpClient.post<any>(`${this.baseUrl}/register`,userRegister,this.httpOptions)
                          .pipe(
                            map((response:UserToken) => {
                              const user = response;
                              if(user)
                              {
                                localStorage.setItem('userToken',JSON.stringify(user));
                                this.currentUser.next(user);
                              }
                            })
                          )
  }
  logout(){
    localStorage.removeItem('userToken');
    this.currentUser.next(null);
  }
  refreshToken() {
    const localObj= localStorage.getItem('userToken');
    if(localObj)
    {
      let user= JSON.parse(localObj);
      if (user) {
        this.currentUser.next(user);
        return;
      }
    }
    this.logout();
  }
}
