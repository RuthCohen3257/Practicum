// employee-details.component.ts

import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee } from '../../../models/employee.model';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.scss']
})
export class EmployeeDetailsComponent {

  employee: Employee;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.employee = data.employee; // Extract employee data from injected data
  }
}
