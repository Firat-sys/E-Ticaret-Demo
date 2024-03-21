import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';


export class BaseComponent {
  
  constructor(private spinner:NgxSpinnerService) { }

  showSpinner(spinnerNametype:SpinnerType){
this.spinner.show(spinnerNametype)

setTimeout(() => {
  this.hidetSpinner(spinnerNametype)
}, 1000);
  }

  hidetSpinner(spinnerNametype:SpinnerType){
    this.spinner.hide(spinnerNametype)
      }
}

export enum SpinnerType{
  BallAtom="s1",
  BallScaleMultiple="s2",
  BallSpinClockwiseFadeRotating="s3"

}