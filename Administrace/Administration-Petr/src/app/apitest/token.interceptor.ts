// src/app/auth/token.interceptor.ts
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor() {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkRlbW8iLCJuYmYiOjE1MjEzNzM5MjYsImV4cCI6MTUyMTk3ODcyNiwiaWF0IjoxNTIxMzczOTI2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo2MzY5OSJ9.Bg2kNnllrEhJNQc2EVvhWcno9c2fTb-9801Dgeahz8s`
      }
    });
    return next.handle(request);
  }
}