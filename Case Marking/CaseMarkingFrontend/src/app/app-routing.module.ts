import { Component, NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';

import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';
import { AddMarkedCaseComponent } from './components/add-marked-case/add-marked-case.component';




const routes: Routes = [

  {path: '', component: AddMarkedCaseComponent },

  {path:'add-marked-case',component:AddMarkedCaseComponent},
  
  {path:'courts', loadChildren: () => import('./modules/courts/courts.module').then(m => m.CourtsModule)},
  
  {path:'categories', loadChildren: () => import('./modules/categories/categories.module').then(m => m.CategoriesModule)}

]




@NgModule({

  imports: [BrowserModule,

    FormsModule,

    RouterModule.forRoot(routes)

  ],

  exports: [RouterModule]

})

export class AppRoutingModule { }