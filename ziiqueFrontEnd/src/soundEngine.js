import * as Tone from 'tone'
import {now} from "tone";

const synth = new Tone.Synth().toDestination();
const FMS = new Tone.FMSynth(Tone.Synth).toDestination();
const multplayer = new Tone.Players({
  urls: {
    kick: './assets/samples/Hard_Kick.mp3',
  }
}).toDestination();



export function demoNode(x)
{
  switch (x)
  {
    case x="A":
      multplayer.player('kick').start(now());
     break;
    case x="B":
      FMS.triggerAttackRelease("C4", "16n");
      break;
    case x="C":
      FMS.triggerAttackRelease("E#4","16n");
      break;
    case x="D":
      FMS.triggerAttackRelease("F#2","16n");
      break;
    case x="E":
      FMS.triggerAttackRelease("D8", "16n");
      break;

      console.log("is ready: " + kick.loaded)
  }

}
