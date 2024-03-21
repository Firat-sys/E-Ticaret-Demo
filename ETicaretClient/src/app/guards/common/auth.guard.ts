import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt'
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../base/base.component';
import { CustomeToastrService, ToasterPosion, ToastrMessageType } from '../../services/ui/custome-toastr.service';
import { MessageType } from '../../services/admin/alertify.service';
import { _isAuthenticated } from '../../services/common/auth.service';
/*import { AuthService, _isAuthenticated } from '../../services/common/auth.service';*/

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private jwtHelper: JwtHelperService, private router: Router, private toastrService: CustomeToastrService, private spinner: NgxSpinnerService) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    this.spinner.show(SpinnerType.BallAtom);
    const token: string = localStorage.getItem("accessToken");

    ////const decodeToken = this.jwtHelper.decodeToken(token);
    ////const expirationDate: Date = this.jwtHelper.getTokenExpirationDate(token);
    let expired: boolean;
    try {
      expired = this.jwtHelper.isTokenExpired(token);
    } catch {
      expired = true;
    }

    if (!_isAuthenticated) {
      this.router.navigate(["login"], { queryParams: { returnUrl: state.url } });
      this.toastrService.message("Oturum açmanız gerekiyor!", "Yetkisiz Erişim!", {
        messagetype: ToastrMessageType.Warning,
        posion: ToasterPosion.TopRigth
      })
    }


    this.spinner.hide(SpinnerType.BallAtom);

    return true;
  }

}
