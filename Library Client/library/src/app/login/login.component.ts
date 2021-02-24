import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean = false;
  constructor( private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  public login = (form: NgForm) => {
    const credentials = JSON.stringify(form.value);
    this.http.post("http://localhost:5001/api/auth/login", 
    credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })          
    }).subscribe(response => {      
      const token = (<any>response).token;
      const refreshToken = (<any>response).refreshToken;
      localStorage.setItem("jwt", token);
      localStorage.setItem("refreshToken", refreshToken);
      this.invalidLogin = false;
      this.router.navigate(["/home"]);
    }, err => {
      this.invalidLogin = true;
    });
  }

}
