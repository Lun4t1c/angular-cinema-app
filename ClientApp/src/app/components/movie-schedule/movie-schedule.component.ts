import { Component, OnInit } from '@angular/core';
import {Observable, switchMap} from "rxjs";
import {MovieModel} from "../../models/MovieModel";
import {DataAccessService} from "../../services/data-access.service";
import {ActivatedRoute, ParamMap} from "@angular/router";
import {MovieShowingModel} from "../../models/MovieShowingModel";

@Component({
  selector: 'app-movie-schedule',
  templateUrl: './movie-schedule.component.html',
  styleUrls: ['./movie-schedule.component.css']
})
export class MovieScheduleComponent implements OnInit {
  movieObservable!: Observable<MovieModel>;
  movieShowings!: Observable<MovieShowingModel[]>;

  constructor(
    private route: ActivatedRoute,
    private dataAccess: DataAccessService
  ) { }

  ngOnInit(): void {
    this.movieObservable = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => this.dataAccess.getMovie(Number(params.get('id'))))
    );

    this.movieObservable.subscribe(
      next => this.movieShowings = this.dataAccess.getMovieShowingsForMovie(next.id)
    );
  }

}
