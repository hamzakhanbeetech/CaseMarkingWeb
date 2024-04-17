import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  displayOtpModal = "none";

  firstName = ""

  employeeForm!: FormGroup;
  selectedImage!: string;
  employeeList: any[] = [];

  constructor(private fb: FormBuilder,
    private apiService: ApiService
    ) {}

  ngOnInit(): void {
    this.getEmployeeList()
    
      this.employeeForm = this.fb.group({
        profileImage: [''],
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        fatherName: ['', Validators.required],
        cnic: ['', Validators.required],
        phoneNumber: ['', Validators.required],
        desgination: ['', Validators.required],
        dateOfJoining: [''],
        workAs: [''],
        payScale: ['']
      });
  }

  getEmployeeList(){
    this.apiService.getEmployeeList().subscribe(resp => {
      this.employeeList = resp
    })
  }

  addEmployee(){
    // Logic to handle form submission
    console.log(this.employeeForm.value);

    let request = {
      ...this.employeeForm.value
    }
    this.apiService.addEmployee(request).subscribe(resp => {
      this.closeModalOtpVerify()
      alert("Added Employee")
    }, err => {
      alert("Error While Adding Employee")
    })

  }

  onFileSelected(event:any) {

    if (event.target.files && event.target.files.length) {
      const files = event.target.files;
      for (let i = 0; i < files.length; i++) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.selectedImage = e.target.result;
          this.employeeForm.patchValue({
            profileImage: this.selectedImage
          })
        };
        reader.readAsDataURL(files[i]);
      }
    }
  }

  removeImage() {
      // Logic to remove selected image
      this.selectedImage = ''
      this.employeeForm.patchValue({
        profileImage: this.selectedImage
      })
  }
  
  
  openModalOtpVerify() {
    this.displayOtpModal = "block";
  }
  closeModalOtpVerify() {
    this.displayOtpModal = "none";
  }
  

}
