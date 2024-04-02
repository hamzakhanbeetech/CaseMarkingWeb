import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-marked-case',
  templateUrl: './add-marked-case.component.html',
  styleUrls: ['./add-marked-case.component.css']
})
export class AddMarkedCaseComponent implements OnInit {

  markedCaseFrom!: FormGroup

  courtList: any[] = []
  caseCategoryList: any[] = []

  caseMarkingHistoryData: any[] = []

  now: Date = new Date();

  dateFrom = formatDate(new Date(this.now.getFullYear(), this.now.getMonth(), 1), 'yyyy-MM-ddTHH:mm', 'en')

  dateTo = formatDate(formatDate(this.now, 'yyyy-MM-ddTHH:mm', 'en'), 'yyyy-MM-ddTHH:mm', 'en');
  currentUser: any

  constructor(private formBuilder: FormBuilder, private apiService: ApiService) { }

  ngOnInit(): void {
    this.currentUser = JSON.parse(localStorage.getItem("userData") ?? "").userData


    this.markedCaseFrom = this.formBuilder.group({

      caseNo: ['', Validators.required],

      caseTitle: ['', Validators.required],

      caseCategoryId: ['', Validators.required],

      markedDate: [formatDate(this.now, 'yyyy-MM-ddTHH:mm', 'en'), Validators.required],

      courtId: ['', Validators.required]

    });
    this.getCaseCategoryList();
    this.getCourtList();
    this.getMarkedCaseHistory();

  }

  getCourtList() {
    this.apiService.getCourts(this.currentUser.identityId).subscribe(resp => {
      this.courtList = resp
    })
  }

  getCaseCategoryList() {
    this.apiService.getCategories(this.currentUser.identityId).subscribe(resp => {
      this.caseCategoryList = resp
    })

  }

  // Calculate totals
  totalLastRow: any[] = [];
  totalLastColumn: any[] = [];
  calculateTotals() {
    // Calculate total for the last column (court totals)
    this.totalLastColumn = this.caseMarkingHistoryData[0].stats.map((stat: any) => {
      return this.caseMarkingHistoryData.reduce((acc, category) => {
        const courtStat = category.stats.find((courtStat: any) => courtStat.courtName === stat.courtName);
        return acc + (courtStat ? courtStat.totalCasesMarked : 0);
      }, 0);
    });

    // Calculate total for the last row (category totals)
    this.totalLastRow = this.caseMarkingHistoryData.map(category =>
      category.stats.reduce((acc: any, stat: any) => acc + stat.totalCasesMarked, 0)
    );
  }

  sumOfArray(listArray: any[]) {
    return listArray.reduce((accumulator, currentValue) => accumulator + currentValue, 0);
  }

  // Method to print the table
  printTable() {
    var divToPrint = document.getElementById("history-data");
    var newWin = window.open("");
    if (divToPrint) {
      newWin?.document.write(divToPrint.outerHTML);
      newWin?.print();
      newWin?.close();

    }
  }

  onSubmitMarkedCase() {


    let request = {
      ...this.markedCaseFrom.value,
      addedByUserId: this.currentUser.identityId
    }

    console.log("request ", request)

    this.apiService.addMarkedCase(request).subscribe(resp => {
      alert("Successfully Added Marked Case")
      this.markedCaseFrom.reset();
      this.getMarkedCaseHistory();
    }, err => {
      alert("Error While Adding Marked Case")
    })

  }

  getMarkedCaseHistory() {

    this.apiService.getMarkedCaseHistory(this.currentUser.identityId, this.dateFrom, this.dateTo).subscribe(resp => {
      console.log("history response ", resp)
      this.caseMarkingHistoryData = resp
      this.calculateTotals()
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

  addNewCase(caseCatId: any, court: any) {
    console.log("hiii ", caseCatId, court)
    this.markedCaseFrom.controls['courtId'].setValue(court.courtID);
    this.markedCaseFrom.controls['caseCategoryId'].setValue(caseCatId);
    this.markedCaseFrom.controls['markedDate'].setValue(formatDate(this.now, 'yyyy-MM-ddTHH:mm', 'en'));
    this.markedCaseFrom.controls['caseNo'].setValue('');
    this.markedCaseFrom.controls['caseTitle'].setValue('');
  }


}
