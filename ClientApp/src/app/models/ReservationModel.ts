import {MovieShowingModel} from "./MovieShowingModel";
import {SeatModel} from "./SeatModel";
import {Observable} from "rxjs";
import {UserModel} from "./UserModel";

export interface ReservationModel{
  id: number,
  idMovieShowing: number,
  idUser: number,
  seatsIdObservable: Observable<number[]>,
  seatsIds: number[]
  //user: Observable<UserModel | null>
  //movieShowing: Observable<MovieShowingModel>,
}
