import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {HomeComponent} from "../../home/home.component";
import {LoginComponent} from "../../components/login/login.component";
import {CounterComponent} from "../../counter/counter.component";
import {FetchDataComponent} from "../../fetch-data/fetch-data.component";
import {MovieShowingsComponent} from "../../components/movie-showings/movie-showings.component";
import {AddMovieShowingComponent} from "../../components/movie-showings/add-movie-showing/add-movie-showing.component";
import {UsersComponent} from "../../components/users/users.component";
import {RegisterUserComponent} from "../../components/users/register-user/register-user.component";
import {
  CurrentlyShowedMoviesComponent
} from "../../components/currently-showed-movies/currently-showed-movies.component";
import {MovieScheduleComponent} from "../../components/movie-schedule/movie-schedule.component";
import {SeatsDisplayComponent} from "../../components/cinema-halls/seats-display/seats-display.component";


const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'counter', component: CounterComponent},
  {path: 'fetch-data', component: FetchDataComponent},
  {path: 'movie-showings', component: MovieShowingsComponent},
  {path: 'add-movie-showing', component: AddMovieShowingComponent},
  {path: 'users', component: UsersComponent},
  {path: 'register', component: RegisterUserComponent},
  {path: 'currently-showed-movies', component: CurrentlyShowedMoviesComponent},
  {path: 'movie-schedule/:id', component: MovieScheduleComponent},
  {path: 'seats/:id', component: SeatsDisplayComponent},
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
