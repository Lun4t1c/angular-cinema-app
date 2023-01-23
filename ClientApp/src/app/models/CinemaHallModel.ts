import {SeatModel} from "./SeatModel";
import {Observable} from "rxjs";

export interface CinemaHallModel{
  id: number,
  code: string,
  seats: Observable<SeatModel[]>
}
