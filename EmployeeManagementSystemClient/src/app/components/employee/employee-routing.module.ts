import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';


const EMPLOYEE_ROUTES: Route[] = [
  { path: '', redirectTo: 'all', pathMatch: 'full' },
  { path: 'all', component: EmployeesComponent },
  
]
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(EMPLOYEE_ROUTES)
  ],
  exports: [
    RouterModule
  ]
})
export class EmployeeRoutingModule { }
