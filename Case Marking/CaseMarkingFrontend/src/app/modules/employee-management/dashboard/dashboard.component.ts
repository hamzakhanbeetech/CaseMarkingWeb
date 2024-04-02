import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  displayOtpModal = "none";

  firstName = ""
  
  selectedImages: string[] = [];

  
  
  openModalOtpVerify() {
    this.displayOtpModal = "block";
  }
  closeModalOtpVerify() {
    this.displayOtpModal = "none";
  }

  addEmployee(){

  }
  
  onFileSelected(event: any): void {
    if(this.selectedImages.length >= 4){
      alert("Max 4 images can be selected")
      return
    }
    if (event.target.files && event.target.files.length) {
      const files = event.target.files;
      for (let i = 0; i < files.length; i++) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.selectedImages.push(e.target.result);
        };
        reader.readAsDataURL(files[i]);
      }
      // Limit the number of selected images to 4
      if (this.selectedImages.length > 4) {
        this.selectedImages.splice(4);
      }
    }
  }
  removeImage(index: number): void {
    this.selectedImages.splice(index, 1);
  }

}
