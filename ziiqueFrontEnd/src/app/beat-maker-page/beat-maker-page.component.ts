import { Component, OnInit } from '@angular/core';
import {Instruments} from "./instruments";
import {Note} from "./note";
import {sequence} from "@angular/animations";

let names = ["A","B","C","D","E"]
let NumberOfBars = 16;

@Component({
  selector: 'app-beat-maker-page',
  templateUrl: './beat-maker-page.component.html',
  styleUrls: ['./beat-maker-page.component.css']
})

export class BeatMakerPageComponent implements OnInit {
  instrumentList: Instruments[] = [];
  sequence: Note[] = [];



  constructor() {

  }

  ngOnInit(): void {
    this.createInstruments()

  }

  startBeating() {

  }

  createInstruments()

  {
    for (let i = 0; i < names.length; i++) {
        let instrument : Instruments = {notes: [], nameN: names[i]}
        this.instrumentList.push(instrument)
    }
    for (let i = 0; i < this.instrumentList.length; i++) {
      for (let pos = 1; pos < NumberOfBars+1; pos++) {
        let node:Note = {position: pos+"" + this.instrumentList[i].nameN, sound: this.instrumentList[i].nameN, isToggled: false}
        this.instrumentList[i].notes.push(node)
      }
    }

  }

  addNote(note: Note) {
    if (note.isToggled)
    {
      note.isToggled = false;
    }
    this.sequence.push(note)
  }
}
