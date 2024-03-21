import { Component,OnInit} from '@angular/core';
import { AlertifyService, MessageType, Possion } from '../../../services/admin/alertify.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from '../../../base/base.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
 

export class DashboardComponent extends BaseComponent implements OnInit {

 

  constructor(private alertify: AlertifyService,spinner:NgxSpinnerService){
    super(spinner);
  }
  
  ngOnInit(): void{
    this.showSpinner(SpinnerType.BallAtom)
  }
  m(){
     this.alertify.message("Merhaba",{
      messagetype:MessageType.Success,
      possion:Possion.TopCenter,
      delay:14, 
      dismissOther:true})
  }
  d(){
    this.alertify.dismiss()
  }
  
  }

