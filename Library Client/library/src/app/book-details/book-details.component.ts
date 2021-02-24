import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Book } from '../../model/book';


@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {

  state$: Observable<object>;
  public book: Book;
  

  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) {
  
    this.book = {
      id: null,
      title: null,
      poster: null,
      author: null,
      price: null,
      rating: null,
    
    };
  }

  ngOnInit(): void {
    if (window.history.state.bookData) {
      this.book = window.history.state.bookData;
    }
    else {
      this.router.navigateByUrl('/booklist');
    }
  }

}
