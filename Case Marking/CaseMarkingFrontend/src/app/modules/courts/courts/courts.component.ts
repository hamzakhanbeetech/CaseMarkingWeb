import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-courts',
  templateUrl: './courts.component.html',
  styleUrls: ['./courts.component.css']
})
export class CourtsComponent implements OnInit {

  CourtForm! : FormGroup

  courts: any[] = [];

  editingCourt! : any
  currentUser: any
  
  constructor( private fb: FormBuilder, private apiService: ApiService) {

    this.CourtForm = this.fb.group({
      courtName: ['', [Validators.required]],
      Status: ['Active', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.currentUser = JSON.parse(localStorage.getItem("userData") ?? "").userData

    this.loadCourts(this.currentUser.identityId);
  }

  loadCourts(userId:any) {
    this.apiService.getCourts(userId).subscribe((data:any) => {
      this.courts = data;
    });
  }

  saveCourt() {
    if (this.CourtForm.valid) {
      const newCourt: any = {...this.CourtForm.value, userId: this.currentUser.identityId} as any;

      this.apiService.createCourt(newCourt).subscribe(() => {
        alert("Successfully Added New Court")
        this.CourtForm.reset();
        this.loadCourts(this.currentUser.identityId);
      }, (err:any) => {        
        alert("Error Whil Added New Court")
      });
    }
  }
  editCourt(Court: any) {
    // Implement the logic to open an edit form or dialog.
    // For this example, let's assume you have a variable to track the edited Court.
    this.editingCourt = { ...Court };
  }
  
  saveEditedCourt() {
    // Make an HTTP request to update the Court.
    if(this.editingCourt == null){
      return
    }
    this.apiService.updateCourt(this.editingCourt.CourtID, this.editingCourt).subscribe(() => {
      // Court updated successfully; reload the Court list.
      this.loadCourts(this.currentUser.identityId);
      // Reset the editingCourt variable or close the edit form/dialog.
      this.editingCourt = null;
    });
  }

  deleteCourt(court: any) {
    
    this.apiService.deleteCourt(court.courtId).subscribe(() => {
      // Court deleted successfully; reload the Court list
      this.loadCourts(this.currentUser.identityId);
    });
  }

}
