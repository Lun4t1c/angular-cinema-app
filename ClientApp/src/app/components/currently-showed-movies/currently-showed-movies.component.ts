import {Component, OnInit} from '@angular/core';
import {DataAccessService} from "../../services/data-access.service";
import {MovieShowingModel} from "../../models/MovieShowingModel";
import {Observable} from "rxjs";
import {MovieModel} from "../../models/MovieModel";

@Component({
  selector: 'app-currently-showed-movies',
  templateUrl: './currently-showed-movies.component.html',
  styleUrls: ['./currently-showed-movies.component.css']
})
export class CurrentlyShowedMoviesComponent implements OnInit {
  allMovieShowings!: Observable<MovieShowingModel[]>;
  showedMovies: MovieModel[] = [];

  constructor(
    private dataAccess: DataAccessService
  ) { }

  ngOnInit(): void {
    this.allMovieShowings = this.dataAccess.getAllMovieShowings();
    this.allMovieShowings.subscribe(
      next => this.showedMovies = this.filterMovies(next),
      error => console.log("ERROR", error)
    );
  }

  filterMovies(movieShowings: MovieShowingModel[]): MovieModel[]{
    console.log('Filtering movies')
    let result: MovieModel[] = [];
    let movieIdsSet: Set<number> = new Set<number>();

    movieShowings.forEach(showing => movieIdsSet.add(showing.idMovie));
    movieIdsSet.forEach(
      movieId => this.dataAccess.getMovie(movieId)
        .subscribe(
          next => this.showedMovies.push(next)
        )
    );

    console.log('result: ', result);
    return result
  }
}
