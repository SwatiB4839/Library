import { Component, OnInit } from '@angular/core';
import { Author } from '../../model/author';
import { AuthorService } from '../../services/author-service/author.service';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-author-add',
  templateUrl: './author-add.component.html',
  styleUrls: ['./author-add.component.css']
})
export class AuthorAddComponent implements OnInit {

  public author: Author;
  public email = new FormControl('', [Validators.required, Validators.email]);
  constructor(
    private authorService: AuthorService,
    private router: Router
  ) {
    this.author = {
      id: null,
      name: '',
      biography: null,
      email: null,
      photograph: null,
      books: []
    };
  }

  ngOnInit(): void {
  }

  addAuthor() {
    if (this.email.status.toLowerCase() === 'valid') {
      this.author.email = this.email.value;
    }
    if (this.author.name && this.author.biography && this.author.email && this.author.photograph) {
      this.authorService.setAuthor(this.author).subscribe(
        res => {
          this.router.navigateByUrl('/home/authorlist');
        }
      );
    }
  }

  getEmailErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }
}
