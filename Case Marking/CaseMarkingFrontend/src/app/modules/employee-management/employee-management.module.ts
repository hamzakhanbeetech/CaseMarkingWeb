import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeManagementRoutingModule } from './employee-management-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfileInfoComponent } from './profile-info/profile-info.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    DashboardComponent,
    ProfileInfoComponent
  ],
  imports: [
    CommonModule,
    EmployeeManagementRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class EmployeeManagementModule { }
