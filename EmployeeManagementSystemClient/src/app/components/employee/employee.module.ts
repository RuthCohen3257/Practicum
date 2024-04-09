import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeRoutingModule } from './employee-routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button'; // יבוא עבור mat-button
import { MatSelectModule } from '@angular/material/select'; // יבוא עבור mat-select
import { MatDatepickerModule } from '@angular/material/datepicker'; // יבוא עבור mat-datepicker
import { MatNativeDateModule } from '@angular/material/core'; // יבוא עבור mat-datepicker
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // יבוא עבור הפונקציות הקשורות להנאה
import { BrowserModule } from '@angular/platform-browser';
import { EmployeesComponent } from './employees/employees.component';
import { MatDialogModule } from '@angular/material/dialog';
import { PositionService } from './position.service';
import { EmployeeService } from './employee.service';
import { MatExpansionModule } from '@angular/material/expansion';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { HeaderComponent } from "../header/header.component";
@NgModule({
    declarations: [EmployeesComponent, AddEmployeeComponent, EditEmployeeComponent],
    exports: [CommonModule],
    providers: [PositionService, EmployeeService],
    imports: [
        CommonModule,
        EmployeeRoutingModule,
        MatTableModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatIconModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatDialogModule,
        MatExpansionModule,
        MatSlideToggleModule, MatPaginatorModule,
        HeaderComponent
    ]
})
export class EmployeeModule { }
