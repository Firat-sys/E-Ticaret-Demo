import { Component, OnInit } from '@angular/core';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from '../../../base/base.component';

import { CustomeToastrService, ToastrMessageType, ToasterPosion } from '../../../services/ui/custome-toastr.service';
import { User } from '../../../entities/User';
import { Create_User } from '../../../contracts/User/create_user';
import { UserService } from '../../../services/common/models/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent  implements OnInit {

  constructor(private formBuilder: UntypedFormBuilder,
    private userService: UserService,
    private toastrService: CustomeToastrService) {
  
  }

  frm: UntypedFormGroup;

  ngOnInit(): void {
    this.frm = this.formBuilder.group({
      nameSurname: ["", [
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(3)
      ]],
      username: ["", [
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(3)
      ]],
      email: ["", [
        Validators.required,
        Validators.maxLength(250),
        Validators.email
      ]],
      password: ["",
        [
          Validators.required
        ]],
      passwordConfirm: ["",
        [
          Validators.required
        ]]
    }, {
      validators: (group: AbstractControl): ValidationErrors | null => {
        let sifre = group.get("password").value;
        let sifreTekrar = group.get("passwordConfirm").value;
        return sifre === sifreTekrar ? null : { notSame: true };
      }
    })
  }

  get component() {
    return this.frm.controls;
  }

  submitted: boolean = false;
  async onSubmit(user:User) {
    this.submitted = true;
  /*  debugger;*/
    if (this.frm.invalid)
      return;

    const result: Create_User = await this.userService.create(user);
    if (result.succeeded)
      this.toastrService.message(result.message, "Kullanıcı Kaydı Başarılı", {
        messagetype: ToastrMessageType.Success,
        posion: ToasterPosion.TopRigth
      })
    else
      this.toastrService.message(result.message, "Hata", {
        messagetype: ToastrMessageType.Error,
        posion: ToasterPosion.TopRigth
      })

  }
}
