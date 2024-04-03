import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditCvComponent } from './Views/edit-cv/edit-cv.component';
import { CommonModule } from '@angular/common';
import { CvListComponent } from './Views/cv-list/cv-list.component';
import { CreateCvComponent } from './Views/create-cv/create-cv.component';
import { ViewCvComponent } from './Views/view-cv/view-cv.component';

const routes: Routes = [
  {path: 'edit-cv', component: EditCvComponent},
  {path: '', component: CvListComponent},
  {path: 'create-cv', component: CreateCvComponent},
  {path: 'view-cv/:id', component: ViewCvComponent},
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
