import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Author } from '../../model/author';
import { AuthorService } from '../../services/author-service/author.service';
import { BookService } from '../../services/book-service/book.service';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})
export class AuthorListComponent implements OnInit {

  public authors: Array<Author>;
  public displayedColumns: string[] = ['name', 'detail'];

  constructor(private authorService: AuthorService,
    private boookService: BookService,
    private router: Router) {
    this.authors = new Array<Author>();
  }

  ngOnInit(): void {
    this.authorService.getAuthorsList().subscribe(
      data => {
        this.authors = data;
      }
    );
  }

  viewAuthorDetails(id: string) {
    var author: any;
    this.authors.forEach(element => {
      if (element.id === id) {
        author = element;
        this.router.navigateByUrl('/home/authordetails', { state: { authorData: author } });
      }
    });
  }

}
