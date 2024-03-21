import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseComponent, SpinnerType } from '../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { HttpClient } from '@angular/common/http';
import { HttpClientService } from '../../../services/common/http-client.service';
import { subscribe } from 'diagnostics_channel';
import { create_Product } from '../../../contracts/create_Product';
import { listcomponent } from './list/list.component';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent extends BaseComponent implements OnInit {
constructor(spinner:NgxSpinnerService,private httpClienService:HttpClientService){
      super(spinner);
    }
    
    ngOnInit(): void{
      this.showSpinner(SpinnerType.BallAtom);

      this.httpClienService.get<create_Product[]>({
        controller:"Products"
      }).subscribe(data=>console.log(data));

    // this.httpClienService.delete({
    //   controller:"Products"
    // },"7562423e-8ce9-41ea-81bd-02bddd34b88d").subscribe();

    // this.httpClienService.get({
    //  fullEndPoint:"https://jsonplaceholder.typicode.com/posts"
    // }).subscribe(data=>console.log(data));
  }

  @ViewChild(listcomponent) listcomponenets: listcomponent;
  createdProduct(createdProduct: create_Product) {
    this.listcomponenets.getProducts();
  }

}
