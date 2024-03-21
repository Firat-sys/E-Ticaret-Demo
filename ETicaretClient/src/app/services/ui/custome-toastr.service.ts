import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CustomeToastrService {

  constructor(private toastr:ToastrService) { }
  message(message:string,title:string,toastroption:Partial<ToastrOption>){
this.toastr[toastroption.messagetype](message,title,{positionClass:toastroption.posion})
  }
}

export enum ToastrMessageType{
  Success="success",
Info="info",
Warning="warning",
Error="error"
}

export class ToastrOption{
  messagetype:ToastrMessageType;
  posion:ToasterPosion;
}

export enum ToasterPosion{
  TopRigth="toast-top-right",
  BottomRight="toast-bottom-right",
  BottomLeft="toast-bottom-left",
  TopLeft="toast-top-left",
  TopFullWidth="toast-top-full-width",
  BottomFullWith="toast-bottom-full-width",
  TopCenter="toast-top-center",
  BottomCenter="toast-bottom-center"
}