import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  title = 'Library';

  navLinks: any[];
  activeLinkIndex = -1;

  constructor(private jwtHelper: JwtHelperService, private router: Router) {
    this.navLinks = [
      {
        label: 'Book List',
        link: './booklist',
        index: 0
      }, {
        label: 'Book Add',
        link: './bookadd',
        index: 1
      }, {
        label: 'Book Delete',
        link: './bookdelete',
        index: 2
      }, {
        label: 'Author List',
        link: './authorlist',
        index: 3
      }, {
        label: 'Author Add',
        link: './authoradd',
        index: 4
      }, {
        label: 'Author Delete',
        link: './authordelete',
        index: 5
      }, {
        label: 'G Map',
        link: './gmap',
        index: 6
      },
      {
        label: 'Charts',
        link: './charts',
        index: 7
      }
    ];
  }

  ngOnInit(): void {
    this.activeLinkIndex = 0;
  }

  logout() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("refreshToken");
    this.router.navigate(["/login"]);
  }

}
