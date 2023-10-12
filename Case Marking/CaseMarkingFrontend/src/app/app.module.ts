import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';

import { NgxPaginationModule } from 'ngx-pagination';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import { ApiService } from './api.service';

import { FormsModule } from '@angular/forms';

import { RouterModule } from '@angular/router';

import { ReactiveFormsModule } from '@angular/forms';

import { ToastrModule } from 'ngx-toastr';

import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';


import {MatIconModule} from '@angular/material/icon';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatNativeDateModule} from '@angular/material/core';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FooterComponent } from './components/footer/footer.component';
import { AddMarkedCaseComponent } from './components/add-marked-case/add-marked-case.component';



@NgModule({

  declarations: [

    AppComponent,
    AddMarkedCaseComponent,
    FooterComponent,
    NavBarComponent

  ],

  imports: [
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,

    BrowserModule,

    BrowserAnimationsModule,

    FormsModule,

    HttpClientModule,

    NgxPaginationModule,

    RouterModule,

    AppRoutingModule,

    ReactiveFormsModule,

    ToastrModule.forRoot({}),

    NoopAnimationsModule,

    BrowserAnimationsModule,
     NgbModule,

  ],

  providers: [ApiService],

  bootstrap: [AppComponent]

})

export class AppModule { }