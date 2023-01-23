import {Time} from "@angular/common";
import {MovieModel} from "./MovieModel";
import {CinemaHallModel} from "./CinemaHallModel";
import {Observable} from "rxjs";

export interface MovieShowingModel{
  id: number,
  idMovie: number;
  idCinemaHall: number,
  cinemaHall: Observable<CinemaHallModel>,
  beginDate: Date,
  movie: Observable<MovieModel>
}
