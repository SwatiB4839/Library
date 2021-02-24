import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthorAddComponent } from './author-add/author-add.component';
import { AuthorDeleteComponent } from './author-delete/author-delete.component';
import { AuthorDetailsComponent } from './author-details/author-details.component';
import { AuthorListComponent } from './author-list/author-list.component';
import { BookAddComponent } from './book-add/book-add.component';
import { BookDeleteComponent } from './book-delete/book-delete.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { BookListComponent } from './book-list/book-list.component';
import { GmapComponent } from './gmap/gmap.component';
import { LineChartComponent } from './charts/line-chart/line-chart.component';
import { AuthGuardService } from 'src/services/auth/auth-guard.service';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: '', component: LoginComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'home', component: HomeComponent, canActivate: [AuthGuardService], children: [
      {
        path: '', component: BookListComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'booklist', component: BookListComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'bookdetails', component: BookDetailsComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'bookadd', component: BookAddComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'bookdelete', component: BookDeleteComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'authorlist', component: AuthorListComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'authordetails', component: AuthorDetailsComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'authoradd', component: AuthorAddComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'authordelete', component: AuthorDeleteComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'gmap', component: GmapComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'charts', component: LineChartComponent, canActivate: [AuthGuardService]
      }
    ]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


}
