import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { InvokeMethodExpr } from "@angular/compiler";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { delay, finalize } from "rxjs/operators";
import { BusyService } from "../services/busy.service";


@Injectable()
export class LoadingInterceptor implements HttpInterceptor{

    constructor(private buysService:BusyService){}
    
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(req.method==='POST'&& req.url.includes('orders')){
            return next.handle(req);
        }
        if(req.method==="DELETE"){
            return next.handle(req);
        }
        if(!req.url.includes('emailexists')){
            return next.handle(req);
        }
        
        this.buysService.busy();
        return next.handle(req).pipe(
            delay(1000),
            finalize(()=>{
                this.buysService.idle();
            })
        );
    }
}