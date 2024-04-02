import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfileInfoComponent } from './profile-info/profile-info.component';

const routes: Routes = [
  
  {path:'', component: DashboardComponent},

  {path:':id', component: ProfileInfoComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeManagementRoutingModule { }
