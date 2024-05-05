
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Employee } from '../../../models/employee.model';
import { EmployeeService } from '../employee.service';
import { Position } from '../../../models/position.model';
import { PositionService } from '../position.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.scss']
})
export class AddEmployeeComponent implements OnInit {

  employeeForm!: FormGroup;
  positions1!: Position[];
  isModalOpen: boolean = true;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private dialog:MatDialog,
    private positionService: PositionService,
    public dialogRef: MatDialogRef<AddEmployeeComponent>
  ) {
    this.positions1 = {} as Position[];
  }

  ngOnInit(): void {
    this.initForm();
    this.loadPositions();
  }

  initForm(): void {
    // Define form controls and validators
    this.employeeForm = this.fb.group({
      idNumber: ['', [Validators.required, Validators.pattern(/^\d{9}$/)]],
      firstName: ['', [Validators.required, Validators.pattern(/^[a-zA-Z]+$/)]],
      lastName: ['', [Validators.required, Validators.pattern(/^[a-zA-Z]+$/)]],
      dateOfBirth: ['', Validators.required],
      startDate: ['', Validators.required],
      gender: ['', Validators.required],
      isActive: [true],
      positions: this.fb.array([], Validators.required),
    },{ validators: this.customValidator })
  }

  customValidator(formGroup: FormGroup) {
    const startDate = formGroup.get('startDate')?.value;
    const dateOfBirth = formGroup.get('dateOfBirth')?.value;
       if (startDate && dateOfBirth && startDate <= dateOfBirth) {
      formGroup.get('startDate').setErrors({ startDateMustBeLater: true });
    }
  }
  entryDateValidator() {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const entryDate = new Date(control.value);
      const startOfWorkDate = new Date(this.employeeForm.get('startDate').value);
      return entryDate >= startOfWorkDate ? null : { 'entryDateInvalid': true };
    };
  }

  get positionsFormArray(): FormArray {
    return this.employeeForm.get('positions') as FormArray;
  }

  loadPositions(): void {
    this.positionService.getPositions().subscribe(
      (positionList: Position[]) => {
        //console.log(positionList)
        this.positions1 = positionList;
        this.addPositionControl();
      },
      error => {
        console.error('Error loading positions:', error);
      }
    );
  }

  addPositionControl(): void {
    this.positionsFormArray.push(this.fb.group({
      positionId: ['', Validators.required],
      isManagerialPosition: [false, Validators.required],
      dateOfEntryIntoOffice: [null, [Validators.required,this.entryDateValidator()]]
    }));
  }

  removePositionControl(index: number): void {
    this.positionsFormArray.removeAt(index);
  }

  onSubmit(): void {
    if (this.employeeForm.valid) {
      const employee: Employee = this.employeeForm.value;
      this.employeeService.addEmployee(employee).subscribe({
        next: (res) => {
          this.closeModal();
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

  closeModal(): void {
    this.dialogRef.close();
  }

  isPositionAllowed(positionId: number, currentIndex: number): boolean {
    const positionsFormArray = this.employeeForm.get('positions') as FormArray;
    const currentPositions = positionsFormArray.value;
  
    // Check if the position is already assigned to the employee
    const isAlreadyAssigned = currentPositions.some((position: { positionId: number; }, index: number) => {
      // Ignore the current position being edited
      if (index === currentIndex) {
        return false;
      }
  
      return position.positionId === positionId;
    });
  
    // If the position is already assigned, return false to disable it in the select
    return isAlreadyAssigned;
  }
  closeForm() {
    this.dialog.closeAll();
  }
}
