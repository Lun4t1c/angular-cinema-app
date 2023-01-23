import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {BehaviorSubject, map, Observable} from "rxjs";
import {MovieShowingModel} from "../../models/MovieShowingModel";
import {DataAccessService} from "../../services/data-access.service";
import {CinemaHallModel} from "../../models/CinemaHallModel";
import {MovieModel} from "../../models/MovieModel";

@Component({
  selector: 'app-movie-showings',
  templateUrl: './movie-showings.component.html',
  styleUrls: ['./movie-showings.component.css']
})
export class MovieShowingsComponent implements OnInit {
  private _movieShowings: BehaviorSubject<MovieShowingModel[]> = new BehaviorSubject<MovieShowingModel[]>([]);
  movieShowings: Observable<MovieShowingModel[]> = this._movieShowings.asObservable();

  constructor(
    public dataAccess: DataAccessService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.dataAccess.getAllMovieShowings()
      .subscribe(next => this._movieShowings.next(next));
  }

  addMovieShowing(){
    this.router.navigate(['/add-movie-showing']);
  }
}
