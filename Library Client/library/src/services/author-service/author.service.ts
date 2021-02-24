import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import { Observable } from 'rxjs';
import { Author } from 'src/model/author';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthorService{

  constructor(private http: HttpClient) { }
  

  getAuthorsList(): Observable<Author[]>{
    return this.http.get<Author[]>('http://localhost:5001/api/author');
  }

  setAuthor(author: Author) {
    return this.http.post('http://localhost:5001/api/author', author);
  }

  deleteAuthor(id: string) {
    let params = new HttpParams();
    params = params.set('id', id);
    return this.http.delete('http://localhost:5001/api/author', {params: params});
  }
}
