import { Component, OnInit } from '@angular/core';
import {MovieShowingModel} from "../../../models/MovieShowingModel";
import {DataAccessService} from "../../../services/data-access.service";
import {Observable} from "rxjs";
import {MovieModel} from "../../../models/MovieModel";
import {Time} from "@angular/common";
import {CinemaHallModel} from "../../../models/CinemaHallModel";
import {Router} from "@angular/router";

@Component({
  selector: 'app-add-movie-showing',
  templateUrl: './add-movie-showing.component.html',
  styleUrls: ['./add-movie-showing.component.css']
})
export class AddMovieShowingComponent implements OnInit {
  // TODO date time is one hour off, when send to backend (frontend problem)

  allMovies!: Observable<MovieModel[]>;
  allCinemaHalls!: Observable<CinemaHallModel[]>;

  movieShowing: Partial<MovieShowingModel> = {};
  date: Date = new Date;
  time!: Time;

  constructor(
    private dataAccess: DataAccessService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.allMovies = this.dataAccess.getAllMovies();
    this.allCinemaHalls = this.dataAccess.getAllCinemaHalls();
  }

  submit(){
    // TODO get rid of ignoring that somehow
    // @ts-ignore
    this.movieShowing.idMovie = this.movieShowing.movie.id;
    // @ts-ignore
    this.movieShowing.idCinemaHall = this.movieShowing.cinemaHall.id;

    this.movieShowing.beginDate = this.date;
    this.movieShowing.beginDate.setHours(
      this.time.toString().split(':', 2)[0] as unknown as number,
      this.time.toString().split(':', 2)[1] as unknown as number,
      0
    );

    console.log(this.movieShowing)
    console.log("New movie showing: ", this.movieShowing as MovieShowingModel)
    this.dataAccess.insertMovieShowing(this.movieShowing as MovieShowingModel);

    this.router.navigate(['/movie-showings']);
  }
}
