import { Book } from './book';

export interface Author {
    id: string;
    name: string;
    biography: string;
    photograph: string;
    email: string;
    books: Array<Book>;
}