import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FileSystemDirectoryEntry, FileSystemFileEntry, NgxFileDropEntry } from 'ngx-file-drop';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../../base/base.component';
import { AlertifyService, MessageType, Possion } from '../../admin/alertify.service';
import { HttpClientService } from '../http-client.service';
import { CustomeToastrService, ToasterPosion, ToastrMessageType } from '../../ui/custome-toastr.service';
import { DeleteState } from '../../../dialogs/delete-dialog/delete-dialog.component';
import { DialogService } from '../dialog.service';
import { FileUploadDialogComponent, FileUploadDialogState } from '../../../dialogs/file-upload-dialog/file-upload-dialog.component';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent {
  constructor(
    private httpClientService: HttpClientService,
    private alertifyService: AlertifyService,
    private customToastrService: CustomeToastrService,
    private dialog: MatDialog,
    private dialogService: DialogService,
    private spinner: NgxSpinnerService
  ) { }

  public files: NgxFileDropEntry[];

  @Input() options: Partial<FileUploadOptions>;

  public selectedFiles(files: NgxFileDropEntry[]) {
    this.files = files;
    const fileData: FormData = new FormData();
    for (const file of files) {
      (file.fileEntry as FileSystemFileEntry).file((_file: File) => {
        fileData.append(_file.name, _file, file.relativePath);
      });
    }

    this.dialogService.openDialog({

      componentType: FileUploadDialogComponent,
      data: FileUploadDialogState.Yes,
      afterClosed: () => {
        this.spinner.show(SpinnerType.BallSpinClockwiseFadeRotating)
        this.httpClientService.post({
          controller: this.options.controller,
          action: this.options.action,
          queryString: this.options.queryString,
          headers: new HttpHeaders({ "responseType": "blob" })
        }, fileData).subscribe(data => {

          const message: string = "Dosyalar başarıyla yüklenmiştir.";

          this.spinner.hide(SpinnerType.BallSpinClockwiseFadeRotating)
          if (this.options.isAdminPage) {
            this.alertifyService.message(message,
              {
                dismissOther: true,
                messagetype: MessageType.Success,
                possion: Possion.TopRight
              })
          } else {
            this.customToastrService.message(message, "Başarılı.", {
              messagetype: ToastrMessageType.Success,
              posion: ToasterPosion.TopRigth
            })
          }
         

        }, (errorResponse: HttpErrorResponse) => {

          const message: string = "Dosyalar yüklenirken beklenmeyen bir hatayla karşılaşılmıştır.";
          this.spinner.hide(SpinnerType.BallSpinClockwiseFadeRotating)

          if (this.options.isAdminPage) {
            this.alertifyService.message(message,
              {
                dismissOther: true,
                messagetype: MessageType.Error,
                possion: Possion.TopRight
              })
          } else {
            this.customToastrService.message(message, "Başarsız.", {
              messagetype: ToastrMessageType.Error,
              posion: ToasterPosion.TopRigth
            })
          }
         
        });
      }
    });
  }


  //openDialog(afterClosed: any): void {
  //  const dialogRef = this.dialog.open(FileUploadDialogComponent, {
  //    width: '250px',
  //    data: FileUploadDialogState.Yes,
  //  });

  //  dialogRef.afterClosed().subscribe(result => {
  //    if (result == FileUploadDialogState.Yes) {
  //      afterClosed();
  //    }
  //  });
  //}

}

export class FileUploadOptions {
  controller?: string;
  action?: string;
  queryString?: string;
  explanation?: string;
  accept?: string;
  isAdminPage?: boolean = false;
}
