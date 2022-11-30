import { Component, OnInit } from '@angular/core';
import {Instruments} from "./instruments";
import {Note} from "./note";
import * as sound from "../../soundEngine";

let names = ["A","B","C","D","E"]
let NumberOfBars = 16;

@Component({
  selector: 'app-beat-maker-page',
  templateUrl: './beat-maker-page.component.html',
  styleUrls: ['./beat-maker-page.component.css']
})

export class BeatMakerPageComponent implements OnInit {
  instrumentList: Instruments[] = [];
  demoNode: Note[] = [];
  sequenceA: Note[] = [];
  sequenceB: Note[] = [];
  sequenceC: Note[] = [];
  sequenceD: Note[] = [];
  sequenceE: Note[] = [];


  constructor() {

  }

  ngOnInit(): void {
    this.createInstruments()
    this.createDemoIns()

  }

  startBeating() {

  }

  createInstruments() {
    for (let i = 0; i < names.length; i++) {
      let instrument: Instruments = {notes: [], nameN: names[i]}
      this.instrumentList.push(instrument)
    }
    for (let i = 0; i < this.instrumentList.length; i++) {
      for (let pos = 1; pos < NumberOfBars + 1; pos++) {
        let node: Note = {
          position: pos + "" + this.instrumentList[i].nameN,
          sound: this.instrumentList[i].nameN,
          isToggled: false
        }
        this.instrumentList[i].notes.push(node)
      }
    }
  }

  createDemoIns() {
    for (let i = 0; i < names.length; i++) {
      let node: Note = {position: 0 + names[i], sound: names[i], isToggled: false}
      this.demoNode.push(node)
      console.log(this.demoNode[i].position.includes("A", 1))
    }
  }

  addNote(note: Note) {
    console.log(this.sequenceA[0])
    if (!note.isToggled) {
      switch (note.sound) {
        case "A":
          this.sequenceA.push(note);
          break;
        case "B":
          this.sequenceB.push(note);
          break;
        case "C":
          this.sequenceC.push(note);
          break;
        case "D":
          this.sequenceD.push(note);
          break;
        case "E":
          this.sequenceE.push(note);
          break;
      }
      note.isToggled = true;
    } else {
      note.isToggled = false;
      switch (note.sound) {
        case "A":
          this.sequenceA = this.sequenceA.filter(b => b.position !== note.position);
          break;
        case "B":
          this.sequenceB = this.sequenceB.filter(b => b.position !== note.position);
          break;
        case "C":
          this.sequenceC = this.sequenceC.filter(b => b.position !== note.position);
          break;
        case "D":
          this.sequenceD = this.sequenceD.filter(b => b.position !== note.position);
          break;
        case "E":
          this.sequenceE = this.sequenceE.filter(b => b.position !== note.position);
          break;
      }
    }
  }

  playDemo(note: Note) {
    sound.demoNode(note.sound)
  }

  play() {
    let allSeq = [this.sequenceA, this.sequenceB, this.sequenceC, this.sequenceD, this.sequenceE];

    for (let i = 0; i < allSeq.length; i++) {
      let sorted = [];
      sorted = allSeq[i].sort((a, b) => (a.position > b.position ? -1 : 1))

      allSeq[i] =  sorted
      console.log(sorted);
    }
    for (let i = 0; i < this.sequenceA.length; i++) {
      console.log("unsorted "+ this.sequenceA[i].position)
    }
  }
}
