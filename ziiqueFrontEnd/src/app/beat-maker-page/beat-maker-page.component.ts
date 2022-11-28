import { Component, OnInit } from '@angular/core';
import {Instruments} from "./instruments";
import {Note} from "./note";



@Component({
  selector: 'app-beat-maker-page',
  templateUrl: './beat-maker-page.component.html',
  styleUrls: ['./beat-maker-page.component.css']
})

let names = ["A","B","C","D","E"]
let instrumentList: Instruments[]
let NumberOfBars = 16;

export class BeatMakerPageComponent implements OnInit {



  constructor() {

  }

  ngOnInit(): void {

  }

  startBeating() {

  }

  createInstruments()

  {
    for (const name in names) {
      let instrument : Instruments = {notes: [], name: name}
      instrumentList.push(instrument)
    }
    for (let i = 0; i < instrumentList.length; i++) {
      for (let pos = 1; pos < NumberOfBars; pos++) {
        let node:Note = {position: pos.toString() + instrumentList[i], sound: instrumentList[i].name}
        instrumentList[i].notes.push(node)
      }
    }

  }

  addNote(note: Note) {
  }
}
