import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-profile-info',
  templateUrl: './profile-info.component.html',
  styleUrls: ['./profile-info.component.css']
})
export class ProfileInfoComponent {
  today = new Date()
  employeeObj: any
  userForm!: FormGroup;
  displayOtpModal = "none";

  employeeForm!: FormGroup;

  employementHistory: any
  empId: any

  constructor(private fb: FormBuilder,
    private apiService: ApiService,
    private activatedRoute: ActivatedRoute
    ) {}


  ngOnInit(): void {

    this.empId = this.activatedRoute.snapshot.paramMap.get('id')
    this.getEmployeeDetails(this.empId);
    this.getEmploymentHistory(this.empId);

    this.userForm = this.fb.group({
        username: ['username', Validators.required],
        firstname: ['Valerie', Validators.required],
        lastname: ['Luna', Validators.required],
        orgName: ['D&SC', Validators.required],
        location: ['Mandian, Abbottabad'],
        emailAddress: ['name@example.com', Validators.email],
        phoneNumber: ['03135084696'],
        birthday: ['06/10/1999'],
        fathername: ['', Validators.required],
        cnic: ['', Validators.required],
        phone: ['', Validators.required],
        dob: [''],
        dateOfJoining: [''],
        desgination: [''],
        workAs: [''],
        payScale: ['']
        // Add more form controls as needed
    });
    
    this.employeeForm = this.fb.group({
      employeeId: ['', Validators.required],
      previousPosition: ['', Validators.required],
      newPosition: ['', Validators.required],
      transferDate: ['', Validators.required],
      officeName: ['', Validators.required],
      workAs: ['', Validators.required],
      payScale: ['', Validators.required],
    });
  }

  getEmployeeDetails(id:any){
    this.apiService.getEmployeeDetail(id).subscribe(resp => {
      this.employeeObj = resp
      this.userForm.patchValue(resp)
    })
  }

  getEmploymentHistory(id:any){
    this.apiService.getEmployeeTransferHistory(id).subscribe(resp => {
      this.employementHistory = resp
    })
  }

  calculateDiff(dateSent:any){
    if(!dateSent){
      return " "
    }
    let currentDate = new Date();
    dateSent = new Date(dateSent);

    return Math.floor((Date.UTC(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate()) - Date.UTC(dateSent.getFullYear(), dateSent.getMonth(), dateSent.getDate()) ) /(1000 * 60 * 60 * 24));
}
  onSubmit(){
    console.log(this.userForm.value);
  }

  transferEmployee(){
    console.log("transfer form: ", this.employeeForm.value)

    if(this.employeeForm.invalid){
      alert("Fill All Fields")
      return
    }

    let request = this.employeeForm.value

    this.apiService.transferEmployee(request).subscribe(resp => {
      alert("Successfully Created Record")
    }, err => {
      alert("Failed to add record")
    })

  }
  
  
  openModalOtpVerify() {
    this.displayOtpModal = "block";
    this.employeeForm.patchValue({
      employeeId: this.empId
    })
  }
  closeModalOtpVerify() {
    this.displayOtpModal = "none";
  }

}
