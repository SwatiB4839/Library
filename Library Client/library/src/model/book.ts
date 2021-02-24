import { Author } from './author';

export interface Book {
    id: string;
    title: string;
    poster: string;
    authorList?: Author;
    price: string;
    rating: string;
    author?: string
}

