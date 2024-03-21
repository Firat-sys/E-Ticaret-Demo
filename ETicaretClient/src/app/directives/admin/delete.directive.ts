import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2, input } from '@angular/core';
import { HttpClientService } from '../../services/common/http-client.service';
import { ProductService } from '../../services/common/models/product.service';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent, DeleteState } from '../../dialogs/delete-dialog/delete-dialog.component';
import { async } from 'rxjs';
import { AlertifyService, MessageType, Possion } from '../../services/admin/alertify.service';
import { HttpErrorResponse } from '@angular/common/http';
import { NgxSpinnerService } from 'ngx-spinner';
import { DialogService } from '../../services/common/dialog.service';

declare var $: any;

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(
    private element: ElementRef,
    private _renderer: Renderer2,
    private httpclientService: HttpClientService,
    public dialog: MatDialog,
    private alertifyService: AlertifyService,
    spinner: NgxSpinnerService,
    private dialogService: DialogService
  ) {
    const img = _renderer.createElement("img");
    img.setAttribute("src", "../../../../../assets/delete.png");
    img.setAttribute("style", "cursor: pointer;");
    img.width = 25;
    img.height = 25;
    _renderer.appendChild(element.nativeElement, img);
  }

  @Input() id: string;
  @Input() controller: string
  @Output() callBack: EventEmitter<any> = new EventEmitter();

  @HostListener("click")
  async onClick() {

    this.dialogService.openDialog({
      componentType: DeleteDialogComponent,
      data: DeleteState.Yes,
      afterClosed: async () => {

        const td: HTMLTableCellElement = this.element.nativeElement;
        this.httpclientService.delete({
          controller: this.controller
        }, this.id).subscribe(data => {
          $(td.parentElement).animate({
            opacity: 0,
            left: "+=50",
            height: "toogle"
          }, 500, () => {
            this.callBack.emit();
            this.alertifyService.message("Ürün silindi.", {
              dismissOther: true,
              messagetype: MessageType.Success,
              possion: Possion.TopRight
            })
          });
        }, (errorResponse: HttpErrorResponse) => {

          this.alertifyService.message("Ürün silinirken beklenmeyen bir hata oluştu", {
            dismissOther: true,
            messagetype: MessageType.Error,
            possion: Possion.TopRight
          })
        });



      }
    });


  }

  //openDialog(afterClosed: any): void {
  //  const dialogRef = this.dialog.open(DeleteDialogComponent, {
  //    width:'250px',
  //    data: DeleteState.Yes,
  //  });

  //  dialogRef.afterClosed().subscribe(result => {
  //    if (result == DeleteState.Yes) {
  //      afterClosed();
  //    }
  //  });
  //}

}
