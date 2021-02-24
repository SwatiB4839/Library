import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from '../../model/book';
import { BookService } from '../../services/book-service/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  public books: Array<Book>;
  public displayedColumns: string[] = ['title', 'detail'];

  constructor(private router: Router,
    private bookService: BookService) { 
      this.books = new Array<Book>();
    }

  ngOnInit(): void {
    this.bookService.getBooksList().subscribe(
      data => {
        this.books = data;
      }
    );

    let a = 10+10;
    let b = 10+10;
    let c = 10+10;
    let d = 10+10;
  }

  viewBookDetails(id: string) {
    var book: any;
    this.books.forEach(element => {
      if ((element as any)._id === id) {
        book = element;
        this.router.navigateByUrl('/home/bookdetails', { state: { bookData: book } });
      }
    });
  }

}
