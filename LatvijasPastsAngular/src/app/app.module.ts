import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CvListComponent } from './Views/cv-list/cv-list.component';
import { HttpClientModule } from '@angular/common/http';
import { EditCvComponent } from './Views/edit-cv/edit-cv.component';
import { RouterModule, Routes, provideRouter } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CreateCvComponent } from './Views/create-cv/create-cv.component';
import { ViewCvComponent } from './Views/view-cv/view-cv.component';
import { ToastrModule } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

const routes: Routes = [
  { path: 'edit-cv/:id', component: EditCvComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    CvListComponent,
    EditCvComponent,
    CreateCvComponent,
    ViewCvComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),
    ToastrModule.forRoot(),
    CommonModule,
    BrowserAnimationsModule,
  ],
  providers: [provideRouter(routes)],
  bootstrap: [AppComponent]
})
export class AppModule { }

