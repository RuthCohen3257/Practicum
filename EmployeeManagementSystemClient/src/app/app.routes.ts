import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: 'employee', pathMatch: 'full' },
    { path: 'employee', loadChildren: () => import('./components/employee/employee.module').then(c => c.EmployeeModule) },
];

