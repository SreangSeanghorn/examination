import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "src/app/home/home.component";

const template : Routes = [
  {
    path: '', component: HomeComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(template, { useHash: true })],
  exports: [RouterModule],
})
export class TemplateRoute {}

