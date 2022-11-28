import { Component, OnInit } from '@angular/core';
import {Instruments} from "./instruments";
import {Note} from "./note";



@Component({
  selector: 'app-beat-maker-page',
  templateUrl: './beat-maker-page.component.html',
  styleUrls: ['./beat-maker-page.component.css']
})


export class BeatMakerPageComponent implements OnInit {
  instruments: any;
  notes: any;

  constructor() {

  }

  ngOnInit(): void {

  }

  startBeating() {

  }

  addNote(note: Note) {
  }
}
