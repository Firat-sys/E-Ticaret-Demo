import { Injectable } from '@angular/core';
declare var alertify:any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

  //message(message:string , messagetype:MessageType,possion:Possion,delay:number=3,dismissOther:boolean=false){
    message(message:string ,options:Partial< AlertifyOptions>){
    alertify.set('notifier','delay',options.delay)
   alertify.set('notifier','position',options.possion)
   const msj= alertify[options.messagetype](message)
   if(options.dismissOther)
   msj.dismissOthers();
  }

  dismiss(){
    alertify.dismissAll()
  }
 
}

export class AlertifyOptions{
  messagetype:MessageType=MessageType.Message;
  possion:Possion=Possion.BottomLeft;
  delay:number=3;
  dismissOther:boolean=false;
}

export enum MessageType{
Error="error",
Message="message",
Warning="warning",
Success="success",
Notify="notify"
}

export enum Possion{
  TopCenter="top-center",
  TopRight="top-right",
  TopLeft="top-left",
  BottomCenter="bottom-center",
  BottomRight="bottom-right",
  BottomLeft="bottom-left"
}