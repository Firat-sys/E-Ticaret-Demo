import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { CustomeToastrService, ToasterPosion, ToastrMessageType } from '../../ui/custome-toastr.service';
import { User } from '../../../entities/User';
import { Create_User } from '../../../contracts/User/create_user';
import { Observable, firstValueFrom } from 'rxjs';
import { TokenResponse } from '../../../contracts/Token/TokenResponse';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private httpClientService: HttpClientService, private toastrService: CustomeToastrService) { }

  async create(user: User): Promise<Create_User> {
    const observable: Observable<Create_User | User> = this.httpClientService.post<Create_User | User>({
      controller: "Users",
    }, user);

    return await firstValueFrom(observable) as Create_User;
  }

  // UserService sınıfında login fonksiyonu
  async login(userNameOrEmail: string, password: string, callback: () => void): Promise<void> {
    const obsorvable: Observable<any | TokenResponse> = this.httpClientService.post<any | TokenResponse>({
      controller: "users",
      action: "login"
    }, { userNameOrEmail, password });

    const tokenResponse = await firstValueFrom(obsorvable) as TokenResponse;

    if (tokenResponse) {
      localStorage.setItem("accessToken", tokenResponse.token.accessToken);
      callback(); // Geri çağrı fonksiyonunu çağır
    }
  }

   /* callbackfunction();*/
  
}
