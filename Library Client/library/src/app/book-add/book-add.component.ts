import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Author } from '../../model/author';
import { Book } from '../../model/book';
import { AuthorService } from '../../services/author-service/author.service';
import { BookService } from '../../services/book-service/book.service';

@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrls: ['./book-add.component.css']
})
export class BookAddComponent implements OnInit {

  public book: Book;
  public authors: Array<Author>;
  public selectedAuthor: string;
  constructor(
    private bookService: BookService,
    private authorService: AuthorService,
    private router: Router
  ) {
    this.book = {
      id: null,
      title: null,
      poster: null,
      author: null,
      price: null,
      rating: null
    };
  }

  ngOnInit(): void {
    this.authorService.getAuthorsList().subscribe(
      data => {
        this.authors = data;
      }
    )
  }

  addBook() {
    this.book.author = this.selectedAuthor;
    this.bookService.setBook(this.book).subscribe(
      res => {
        this.router.navigateByUrl('/home/booklist');
      }
    );
  }

}
