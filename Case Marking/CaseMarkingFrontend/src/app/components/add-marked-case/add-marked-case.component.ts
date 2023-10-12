import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-add-marked-case',
  templateUrl: './add-marked-case.component.html',
  styleUrls: ['./add-marked-case.component.css']
})
export class AddMarkedCaseComponent implements OnInit {

  markedCaseFrom!: FormGroup

  courtList = [
    "DSJ",
    "ASJ-1",
    "ASJ-2",
    "ASJ-3",
    "ASJ-4",
    "ASJ-5",
    "ASJ-6",
    "ASJ-7",
    "ASJ-8",
  ]
  caseCategoryList = [
    "Civil Appeal",
    "Review Petition",
    "Land Aquasition",
    "Narcotics"
  ]

  caseMarkingHistoryData: any

  now: Date = new Date();

  dateFrom = formatDate(new Date(this.now.getFullYear(), this.now.getMonth(), 1), 'yyyy-MM-ddTHH:mm', 'en')

  dateTo = formatDate(formatDate(this.now, 'yyyy-MM-ddTHH:mm', 'en'), 'yyyy-MM-ddTHH:mm', 'en');

  constructor(private formBuilder: FormBuilder, private apiService: ApiService) { }

  ngOnInit(): void {


    this.markedCaseFrom = this.formBuilder.group({

      caseNo: ['', Validators.required],

      caseTitle: ['', Validators.required],

      caseCategory: ['', Validators.required],

      markedDate: [formatDate(this.now, 'yyyy-MM-ddTHH:mm', 'en'), Validators.required],

      courtName: ['', Validators.required]

    });

    this.getMarkedCaseHistory();

  }

  onSubmitMarkedCase() {

    let request = {
      ...this.markedCaseFrom.value
    }

    this.apiService.addMarkedCase(request).subscribe(resp => {
      alert("Successfully Added Marked Case")
      this.markedCaseFrom.reset();
      this.getMarkedCaseHistory();
    }, err => {
      alert("Error While Adding Marked Case")
    })

  }

  getMarkedCaseHistory() {

    this.apiService.getMarkedCaseHistory(this.dateFrom, this.dateTo).subscribe(resp => {
      console.log("history response ", resp)
      this.caseMarkingHistoryData = resp
    }, err => {
      console.log("history err ", err)
    })

  }

  getCourtNumberOfCases(stats: any[], courtName: string): number {
    const courtStats = stats.find(stat => stat.courtName === courtName);
    return courtStats ? courtStats.numberOfCases : 0;
  }

  // Define getTotalCasesForCourt function in your component
  getTotalCasesForCourt(courtName: string): number {
    let totalCases = 0;
    for (const item of this.caseMarkingHistoryData) {
      const courtStat = item.stats.find((stat: any) => stat.courtName === courtName);
      if (courtStat) {
        totalCases += courtStat.numberOfCases;
      }
    }
    return totalCases;
  }

  // Define getTotalCasesForCategory and getTotalCasesForAllCategories functions in your component
  getTotalCasesForCategory(category: string): number {
    let totalCases = 0;
    for (const item of this.caseMarkingHistoryData) {
      if (item.caseCategory === category) {
        for (const stat of item.stats) {
          totalCases += stat.numberOfCases;
        }
      }
    }
    return totalCases;
  }

  getTotalCasesForAllCategories(): number {
    let totalCases = 0;
    for (const item of this.caseMarkingHistoryData) {
      for (const stat of item.stats) {
        totalCases += stat.numberOfCases;
      }
    }
    return totalCases;
  }

  addNewCase(caseCat:any, courtName:any){
    this.markedCaseFrom.controls['courtName'].setValue(courtName);
    this.markedCaseFrom.controls['caseCategory'].setValue(caseCat);
    this.markedCaseFrom.controls['markedDate'].setValue(formatDate(this.now, 'yyyy-MM-ddTHH:mm', 'en'));
    this.markedCaseFrom.controls['caseNo'].setValue('');
    this.markedCaseFrom.controls['caseTitle'].setValue('');
  }


}
