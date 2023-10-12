import { Component, NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';

import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';
import { AddMarkedCaseComponent } from './components/add-marked-case/add-marked-case.component';




const routes: Routes = [

  {path: '', component: AddMarkedCaseComponent },
{path:'add-marked-case',component:AddMarkedCaseComponent}

]




@NgModule({

  imports: [BrowserModule,

    FormsModule,

    RouterModule.forRoot(routes)

  ],

  exports: [RouterModule]

})

export class AppRoutingModule { }