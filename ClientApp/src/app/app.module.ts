import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AddMovieShowingComponent } from './components/movie-showings/add-movie-showing/add-movie-showing.component';
import { MovieEntryComponent } from './components/movie-entry/movie-entry.component';
import {MatInputModule} from "@angular/material/input";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatNativeDateModule} from "@angular/material/core";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { UsersComponent } from './components/users/users.component';
import { MovieShowingsComponent } from './components/movie-showings/movie-showings.component';
import {NgxMaterialTimepickerModule} from "ngx-material-timepicker";
import { LoginComponent } from './components/login/login.component';
import { RegisterUserComponent } from './components/users/register-user/register-user.component';
import { CurrentlyShowedMoviesComponent } from './components/currently-showed-movies/currently-showed-movies.component';
import { MovieScheduleComponent } from './components/movie-schedule/movie-schedule.component';
import { ScheduleComponent } from './components/schedule/schedule.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import {AppRoutingModule} from "./modules/app-routing/app-routing.module";
import { SeatsDisplayComponent } from './components/cinema-halls/seats-display/seats-display.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AddMovieShowingComponent,
    MovieEntryComponent,
    UsersComponent,
    MovieShowingsComponent,
    LoginComponent,
    RegisterUserComponent,
    CurrentlyShowedMoviesComponent,
    MovieScheduleComponent,
    ScheduleComponent,
    PageNotFoundComponent,
    SeatsDisplayComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    BrowserAnimationsModule,
    NgxMaterialTimepickerModule
  ],
  providers: [
    MatDatepickerModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
