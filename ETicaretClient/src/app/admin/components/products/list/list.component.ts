import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { List_Product } from '../../../../contracts/list_product';
import { MatTableDataSource } from '@angular/material/table';
import { BaseComponent, SpinnerType } from '../../../../base/base.component';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { ProductService } from '../../../../services/common/models/product.service';
import { AlertifyService, MessageType, Possion } from '../../../../services/admin/alertify.service';
import { MatPaginator } from '@angular/material/paginator';
import { DialogService } from '../../../../services/common/dialog.service';
import { SelectProductImageDialogComponent } from '../../../../dialogs/select-product-image-dialog/select-product-image-dialog.component' ;

declare var $: any

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class listcomponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService, private productService: ProductService, private alertfyService: AlertifyService, private dialogService: DialogService) {
    super(spinner);
  }
  
  displayedColumns: string[] = ['name', 'price', 'stock', 'createDate', 'updateDate','edit','delete','photo'];
  dataSource: MatTableDataSource<List_Product> = null;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  async getProducts() {

    this.showSpinner(SpinnerType.BallAtom);
    const allProducts: { totalCount: number; products: List_Product[] } = await this.productService.read(this.paginator ? this.paginator.pageIndex : 0, this.paginator ? this.paginator.pageSize : 5, () => this.hidetSpinner(SpinnerType.BallAtom), errorMessage =>
      this.alertfyService.message(errorMessage, {

        dismissOther: true,
        messagetype: MessageType.Error,
        possion: Possion.TopRight

      }))

    this.dataSource = new MatTableDataSource<List_Product>(allProducts.products);
    this.paginator.length = allProducts.totalCount
  }

  //delete(id,event) {
  //  alert(id)
  //  const img: HTMLImageElement = event.srcElement;
  //  $(img.parentElement.parentElement).fadeOut(2000)
  //}

  async pageChanced() {
    await this.getProducts();
  }

  async ngOnInit() {
    await this.getProducts()
  }
  addProductImages(id: string) {
    this.dialogService.openDialog({
      componentType: SelectProductImageDialogComponent,
      data: id,
      options: {
        width: "1400px"
      }
    });
  }

}
