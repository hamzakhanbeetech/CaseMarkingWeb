import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CourtsRoutingModule } from './courts-routing.module';
import { CourtsComponent } from './courts/courts.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CourtsComponent
  ],
  imports: [
    CommonModule,
    CourtsRoutingModule,
    FormsModule,
    ReactiveFormsModule

  ]
})
export class CourtsModule { }
