import {PeriodicTicker, Sequencer, StepExecutor, Track} from "generic-step-sequencer";

interface MyParameter{
  trackName: string;
}

export class MyStepExecutor implements StepExecutor<MyParameter> {
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
