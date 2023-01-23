import {Component, Input, OnInit} from '@angular/core';
import {MovieModel} from "../../models/MovieModel";

@Component({
  selector: 'app-movie-entry',
  templateUrl: './movie-entry.component.html',
  styleUrls: ['./movie-entry.component.css']
})
export class MovieEntryComponent implements OnInit {
  // TODO add plot property to MovieModel and display it

  @Input() movie!: MovieModel;

  constructor() { }

  ngOnInit(): void {
  }

}
