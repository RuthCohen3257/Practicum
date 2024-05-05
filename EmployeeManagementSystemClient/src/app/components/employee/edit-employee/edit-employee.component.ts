import { Component, OnInit, Inject } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { Employee } from '../../../models/employee.model';
import { EmployeeService } from '../employee.service';
import { Position } from '../../../models/position.model';
import { PositionService } from '../position.service';



@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.scss']
})
export class EditEmployeeComponent  {
  employeeForm: FormGroup;
  positions1: Position[];
  submitted = false;  
  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private dialog:MatDialog,
    private positionService: PositionService,
    public dialogRef: MatDialogRef<EditEmployeeComponent>,
    @Inject(MAT_DIALOG_DATA) public  employee: Employee ,

  ) { }

  ngOnInit(): void {
    this.initForm();
    this.loadPositions();
  }


  initForm(): void {

    // Define form controls and validators
    this.employeeForm = this.fb.group({
      
      idNumber: [this.employee.idNumber, [Validators.required, Validators.pattern(/^\d{9}$/)]],
      firstName: [this.employee.firstName, [Validators.required, Validators.pattern(/^[a-zA-Z]+$/)]],
      lastName: [this.employee.lastName, [Validators.required, Validators.pattern(/^[a-zA-Z]+$/)]],
      dateOfBirth: [new Date(this.employee.dateOfBirth), Validators.required],
      startDate: [new Date(this.employee.startDate), Validators.required],
      gender: [this.employee.gender=='0'?'Male':'Female', Validators.required],
      positions: this.fb.array([], Validators.required),
    }, { validators: this.customValidator });
    this.patchEmployeeData(this.employee);
  }

  customValidator(formGroup: FormGroup) {
    const startDate = formGroup.get('startDate').value;
    const dateOfBirth = formGroup.get('dateOfBirth').value;
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
      (result) => {
        this.positions1 = result;
        
      },
      error => {
        console.error('Error loading positions:', error);
      }
    );
  }

 
  patchEmployeeData(employee: Employee) {
    const positions = this.employeeForm.get('positions') as FormArray;
   
    employee.positions.forEach(position => {
      const positionGroup = this.fb.group({
        positionId: [position.positionId, Validators.required],
        isManagerialPosition: [position.isManagerialPosition, Validators.required],
        dateOfEntryIntoOffice: [new Date(position.dateOfEntryIntoOffice),[Validators.required,this.entryDateValidator()] ]
      });
     
      positions.push(positionGroup);
    });
}

  addPositionControl(): void {
    this.positionsFormArray.push(this.fb.group({
      positionId: ['', Validators.required],
      isManagerialPosition: [false, Validators.required],
      dateOfEntryIntoOffice: ['', [Validators.required,this.customValidator]]
    }));
  }

  removePositionControl(index: number): void {
    this.positionsFormArray.removeAt(index);
  }

  onSubmit(): void {
    this.submitted = true;
    if (this.employeeForm.valid) {
      const updatedEmployee: Employee = this.employeeForm.value;
      updatedEmployee.id=this.employee.id;
      console.log("updatedEmployee",this.employee.id)
      this.employeeService.updateEmployee(updatedEmployee).subscribe({
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

  getFormControl(index: number, controlName: string): FormControl<any> | null {
    const positionsFormGroup = this.employeeForm.get('positions') as FormArray;
    if (positionsFormGroup && positionsFormGroup.controls.length > index) {
      const positionFormGroup = positionsFormGroup.controls[index] as FormGroup;
      return positionFormGroup.get(controlName) as FormControl<any>;
    }
    return null; // Or return a default FormControl with an empty value
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
