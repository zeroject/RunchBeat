import { Component, OnInit } from '@angular/core';
import {MyStepExecutor} from "../../MyStepExecutor"



@Component({
  selector: 'app-beat-maker-page',
  templateUrl: './beat-maker-page.component.html',
  styleUrls: ['./beat-maker-page.component.css']
})


export class BeatMakerPageComponent implements OnInit {

  constructor(private sequence: MyStepExecutor) {

  }

  ngOnInit(): void {

  }

  startBeating() {
    this.sequence.startBeating()
  }
}
