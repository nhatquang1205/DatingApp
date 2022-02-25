import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {

  baseUrl = 'https://localhost:5001/api/users';
  constructor(private httpClient: HttpClient) { }
  /**
   * getMembers
   */
  public getMembers() : Observable<Member[]>{
    return this.httpClient.get<Member[]>(this.baseUrl);
  }
  public getMembersByUsername(username: string) : Observable<Member> {
    return this.httpClient.get<Member>(`${this.baseUrl}/${username}`);
  }
}
