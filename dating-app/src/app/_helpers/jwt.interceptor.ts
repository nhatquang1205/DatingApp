import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AccountsService } from "../_services/accounts.service";

@Injectable()
export class JwtInterceptor implements HttpInterceptor{
    constructor(private accountService: AccountsService){ }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const account = this.accountService.currentUser$;
        let token : string | any = '';
        const isLoggedIn = account.subscribe(
            account => token = account?.token
        );
        if (token) {
            req = req.clone({
                setHeaders: {Authorization: `Bearer ${token}`},
            });
        }

        return next.handle(req);
    }
}