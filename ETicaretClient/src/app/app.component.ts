import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CustomeToastrService, ToasterPosion, ToastrMessageType } from './services/ui/custome-toastr.service';
import { MessageType } from './services/admin/alertify.service';
import { AuthService } from './services/common/auth.service';
import { Router } from '@angular/router';

declare var $: any;


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'ETicaretClient06';

  constructor(public authService: AuthService, private toastrService: CustomeToastrService, private router: Router) {
    authService.identityCheck();
  }

  signOut() {
    localStorage.removeItem("accessToken");
    this.authService.identityCheck();
    this.router.navigate([""]);
    this.toastrService.message("Oturum kapatılmıştır!", "Oturum Kapatıldı", {
      messagetype: ToastrMessageType.Warning,
      posion: ToasterPosion.TopRigth
    });
  }
}
// $.get("http://localhost:5244/api/Products",data=>{console.log(data)})
