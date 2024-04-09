import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import {  MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from '../employee.service';
import { AddEmployeeComponent } from '../add-employee/add-employee.component';
import { MatDialog } from '@angular/material/dialog';
import { Employee } from '../../../models/employee.model';
import { EditEmployeeComponent } from '../edit-employee/edit-employee.component';
import { EmployeeDetailsComponent } from '../employee-details/employee-details.component';
import { ExcelService } from '../excel.service';
import { Position } from '../../../models/position.model';
import { PositionService } from '../position.service';
import {MatPaginator} from '@angular/material/paginator';



@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss'],
})
export class EmployeesComponent implements AfterViewInit,OnInit{

  displayedColumns: string[] = ['id', 'idNumber', 'firstName', 'lastName', 'startDate','deleteEmployee','editEmployee'];
  employeesArray: Employee[] = [];
  dataSource: MatTableDataSource<Employee>;
  @ViewChild(MatPaginator) paginator: MatPaginator;


  constructor(private _positionService: PositionService,private _employeeService: EmployeeService,private _excelService:ExcelService , public dialog: MatDialog) 
  { }

  
  ngOnInit(): void {
    this._employeeService.getEmployees().subscribe({
      next: (res: Employee[]) => {
        this.employeesArray = res;
        this.dataSource = new MatTableDataSource<Employee>(this.employeesArray);
         // Define paginator here
         if (this.paginator) {
          this.dataSource.paginator = this.paginator;
        }
      },
      error: (err) => {
        console.log(err);
      }
    });
         
  }
  ngAfterViewInit() { 
    if (this.paginator) {
      this.dataSource.paginator = this.paginator;
    }
  }
  

  addEmployee(): void {
    const dialogRef = this.dialog.open(AddEmployeeComponent, {
      width: '500px',
    });

    dialogRef.afterClosed().subscribe(result => {
      // Handle dialog close event here if needed
      this._employeeService.getEmployees().subscribe({
        next: (res: Employee[]) => {
          this.employeesArray = res
          this.dataSource = new MatTableDataSource<Employee>(this.employeesArray);
          this.dataSource.paginator = this.paginator;
        },
        error: (err) => {
          console.log(err);
        }
      });
    });
  }

  removeData(employee: Employee): void {
    // Implement logic to remove the employee from the data source
    const employeeIndex = this.dataSource.data.findIndex(e => e.id === employee.id);
    if (employeeIndex !== -1) {
      this.dataSource.data.splice(employeeIndex, 1);
      this.dataSource = new MatTableDataSource<Employee>(this.dataSource.data); // Refresh data source
      // Call  service to delete employee from the server 
      this._employeeService.deleteEmployee(employee.id).subscribe({
        next: (res) => {
          console.log(res)
          console.log("deleted succssesfully")
        },
        error: (err) => {
          console.log(err);
        }
      })
    }
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  editData(emp: Employee): void {
    console.log("before",emp)
    const dialogRef = this.dialog.open(EditEmployeeComponent, {
      data:emp,
      width: '500px',
      // Pass employee data to the dialog
    });
    console.log("after open",emp)
    dialogRef.afterClosed().subscribe(result => {
      // Handle dialog close event here if needed
      this._employeeService.getEmployees().subscribe({
        next: (res: Employee[]) => {
          console.log("after close edit")
          this.employeesArray = res;
          this.dataSource = new MatTableDataSource<Employee>(this.employeesArray);
          this.dataSource.paginator = this.paginator;
        },
        error: (err) => {
          console.log(err);
        }
      });
    });
  }
  
  openEmployeeDetails(employee: Employee): void {
    const dialogRef = this.dialog.open(EmployeeDetailsComponent, {
      width: '500px',
      data: { employee } // Pass employee data to the dialog
    });

    dialogRef.afterClosed().subscribe(result => {
      // Handle dialog close event here if needed
    });
  }

  exportToExcel() {
    this._employeeService.getEmployees().subscribe((employees: Employee[]) => {
      const currentDateTime = new Date().toISOString()
        .slice(0, 16)
        .replace(/[-T:]/g, '')
        .replace(/(\d{4})(\d{2})(\d{2})(\d{2})(\d{2})/, '$3-$2-$1_$4$5');
      const fileName = `employee_data`;
      
      // Assuming getPositions returns an Observable of Position[]
      this._positionService.getPositions().subscribe((positions: Position[]) => {
        this._excelService.exportToExcel(employees, positions, fileName);
      });
    });
  }
  



}
