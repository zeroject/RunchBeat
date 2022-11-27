import { Component, OnInit } from '@angular/core';
import {
  StepExecutor,
  Sequencer,
  PeriodicTicker,
  backward, Track,
} from "generic-step-sequencer";



@Component({
  selector: 'app-beat-maker-page',
  templateUrl: './beat-maker-page.component.html',
  styleUrls: ['./beat-maker-page.component.css']
})

class MyStepExecutor implements StepExecutor<MyParameter> {
  execute(track: Track<MyParameter>): void {
    console.log(
      `executing step ${track.currentStep} on ${track.parameters.trackName}`
    );
  }

  startBeating() {
    const sequencer = new Sequencer<MyParameter, MyStepExecutor>(
      new MyStepExecutor()
    );

    const ticker = new PeriodicTicker(sequencer);

    sequencer.addTrack({trackName: "track1"}, 16, [1,5,10,16])
    ticker.setBpm(165);
    ticker.start();
  }
}
interface MyParameter {
  trackName: string;
}
export class BeatMakerPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

  }

}
