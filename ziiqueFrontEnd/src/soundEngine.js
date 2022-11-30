import * as Tone from 'tone'
import {now} from "tone";

const multplayer = new Tone.Players({
  urls: {
    kick: './assets/samples/Hard_Kick.mp3',
    bass: './assets/samples/808.mp3',
    hihat: './assets/samples/Hihat.mp3',
    ride: './assets/samples/Ride.mp3',
    snare: './assets/samples/Snare__Claps.mp3',
  }
}).toDestination();



export function demoNode(x)
{
  console.log(multplayer.loaded);
  switch (x)
  {
    case x="A":
      multplayer.player('kick').start(now());
     break;
    case x="B":
      multplayer.player('bass').start(now());
      break;
    case x="C":
      multplayer.player('hihat').start(now());
      break;
    case x="D":
      multplayer.player('ride').start(now());
      break;
    case x="E":
      multplayer.player('snare').start(now());
      break;
  }



}
