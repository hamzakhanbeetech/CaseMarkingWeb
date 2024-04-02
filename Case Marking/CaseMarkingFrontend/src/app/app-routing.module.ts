import { Component, NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';

import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';
import { AddMarkedCaseComponent } from './components/add-marked-case/add-marked-case.component';
import { AuthGuard } from './services/auth-gaurd/auth-guard.service';




const routes: Routes = [

  {path: '', component: AddMarkedCaseComponent, canActivate:[AuthGuard] },

  {path:'add-marked-case',component:AddMarkedCaseComponent, canActivate:[AuthGuard]},
  
  {path:'courts', loadChildren: () => import('./modules/courts/courts.module').then(m => m.CourtsModule), canActivate:[AuthGuard]},
  
  {path:'categories', loadChildren: () => import('./modules/categories/categories.module').then(m => m.CategoriesModule), canActivate:[AuthGuard]},
  
  {path:'employee-management', loadChildren: () => import('./modules/employee-management/employee-management.module').then(m => m.EmployeeManagementModule), canActivate:[AuthGuard]},
  
  {path:'authentication', loadChildren: () => import('./modules/authentication/authentication.module').then(m => m.AuthenticationModule)},

]




@NgModule({

  imports: [BrowserModule,

    FormsModule,

    RouterModule.forRoot(routes)

  ],

  exports: [RouterModule]

})

export class AppRoutingModule { }