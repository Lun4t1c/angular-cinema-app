import { Component, OnInit } from '@angular/core';
import {BehaviorSubject, Observable, switchMap} from "rxjs";
import {CinemaHallModel} from "../../../models/CinemaHallModel";
import {DataAccessService} from "../../../services/data-access.service";
import {SeatModel} from "../../../models/SeatModel";
import {MovieShowingModel} from "../../../models/MovieShowingModel";
import {ActivatedRoute, ParamMap} from "@angular/router";
import {ReservationModel} from "../../../models/ReservationModel";
import {AuthService} from "../../../services/auth.service";
import {UserModel} from "../../../models/UserModel";

@Component({
  selector: 'app-seats-display',
  templateUrl: './seats-display.component.html',
  styleUrls: ['./seats-display.component.css']
})
export class SeatsDisplayComponent implements OnInit {
  // TODO :hover classes in CSS not working
  // TODO change grid in CSS to have dynamic rows and columns
  // TODO make seats placement more deterministic (seat.coordX and seat.coordY dependent)

  selectedSeatsIdsSubject: BehaviorSubject<number[]> = new BehaviorSubject<number[]>([]);

  cinemaHallObservable!: Observable<CinemaHallModel>;
  seatsObservable!: Observable<SeatModel[]>;
  movieShowingObservable!: Observable<MovieShowingModel>;
  selectedSeatsIdsObservable!: Observable<Set<number>>;

  reservation: Partial<ReservationModel> = {};
  selectedSeatsIds: Set<number> = new Set<number>();

  constructor(
    private route: ActivatedRoute,
    private dataAccess: DataAccessService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    // Hardcoded cinema hall
    this.cinemaHallObservable = this.dataAccess.getCinemaHall(1);
    this.seatsObservable = this.dataAccess.getSeatsInCinemaHall(1);

    // Setting partial reservation model observable fields
    let loggedUserSubject: BehaviorSubject<UserModel | null> = new BehaviorSubject<UserModel | null>(null);
    this.reservation.seatsIdObservable = this.selectedSeatsIdsSubject.asObservable();

    // User
    let userObservable: Observable<UserModel | null> = loggedUserSubject.asObservable();
    //this.reservation.user = userObservable;

    userObservable.subscribe(next => {
      if (next !== null)
        this.reservation.idUser = next.id;
    })

    // Getting movie showing by id from URL
    this.movieShowingObservable = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => this.dataAccess.getMovieShowing(Number(params.get('id'))))
    );

    // Getting currently logged user
    this.authService.getLoggedUserObservable().subscribe(next => {
      if (next !== null)
        loggedUserSubject.next(next)
      else throw  Error();
    });

    // Setting reservation.idMovieShowing
    this.movieShowingObservable.subscribe(next => this.reservation.idMovieShowing = next.id);
  }

  seatClicked(seat: SeatModel){
    if (this.selectedSeatsIds.has(seat.id))
      this.selectedSeatsIds.delete(seat.id)
    else
      this.selectedSeatsIds.add(seat.id);

    this.selectedSeatsIdsSubject.next(Array.from(this.selectedSeatsIds));

    console.log(this.selectedSeatsIds);
  }

  confirmReservation(): void{
    console.log("New reservation: ", this.reservation as ReservationModel);
    this.dataAccess.insertReservation(this.reservation as ReservationModel);
  }
}
