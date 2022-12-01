import * as Tone from 'tone'
import {now, Transport} from 'tone'
import {repeat} from "rxjs";


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

function generateNote(note, bpm)
{
  let s =note.charAt(1)
  switch (s)
  {
    case "A":
      multplayer.player('kick').start(generateTime(bpm, note)).toDestination();
      console.log('CheckA')
      break;
    case "B":
      multplayer.player('bass').start(generateTime(bpm, note)).sync();
      break;
    case "C":
      multplayer.player('hihat').start(generateTime(bpm, note)).sync();
      break;
    case "D":
      multplayer.player('ride').start(generateTime(bpm, note)).sync();
      break;
    case "E":
      multplayer.player('snare').start(generateTime(bpm, note)).sync();
      break;
  }
}

function generateTime(bpm, note)
{
  let bps;
  bps = bpm / 60

  let splitNote;
  splitNote = note.charAt(0)
  let posNum;
  posNum = Number(splitNote)

  return (1 / bps) * posNum
}

export function startBeating(Seq, bpm){
  for (let note in Seq) {
    generateNote(note, bpm)
    Tone.Transport.start(now())
  }
}
