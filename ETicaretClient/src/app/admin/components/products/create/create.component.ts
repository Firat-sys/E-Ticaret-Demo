import { Component, EventEmitter, Output } from '@angular/core';
import { ProductService } from '../../../../services/common/models/product.service';
import { create_Product } from '../../../../contracts/create_Product';
import { BaseComponent, SpinnerType } from '../../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { AlertifyService, MessageType, Possion } from '../../../../services/admin/alertify.service';
import { FileUploadOptions } from '../../../../services/common/file-upload/file-upload.component';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent extends BaseComponent {

constructor(spinner:NgxSpinnerService,private productService:ProductService,private alertify:AlertifyService) {
 super(spinner);
  
  }

  @Output() createdProduct: EventEmitter<create_Product> = new EventEmitter();
  //@Output() fileUploadOptions: Partial<FileUploadOptions> = {
  //  action: "upload",
  //  controller: "products",
  //  explanation: "Resimleri  sürükleyin veya seçin...",
  //  isAdminPage: true,
  //  accept:" .png, .jpeg, .json"
  //};
create(Name,Stock,Price){
  this.showSpinner(SpinnerType.BallAtom)
const create_product:create_Product=new create_Product();
create_product.name=Name.value;
create_product.stock=parseInt(Stock.value);
create_product.price=parseFloat(Price.value);

this.productService.create(create_product,()=>{
  this.hidetSpinner(SpinnerType.BallAtom);
  this.alertify.message("Ürün başariyla eklenmiştir.",{
    dismissOther:true,
    messagetype:MessageType.Success,
    possion:Possion.TopRight
  });
  this.createdProduct.emit(create_product);
},
errormessage=>{
  this.alertify.message(errormessage,{
    dismissOther:true,
    messagetype:MessageType.Error,
    possion:Possion.TopRight

  });
}
);
}
}
