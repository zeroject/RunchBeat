import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeatMakerPageComponent } from './beat-maker-page.component';

describe('BeatMakerPageComponent', () => {
  let component: BeatMakerPageComponent;
  let fixture: ComponentFixture<BeatMakerPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BeatMakerPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BeatMakerPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
