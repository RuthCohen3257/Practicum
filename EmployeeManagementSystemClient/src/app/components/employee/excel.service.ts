import { Injectable } from '@angular/core';
import * as XLSX from 'xlsx';
import { Employee } from '../../models/employee.model';
import { Position } from '../../models/position.model';

@Injectable({
  providedIn: 'root'
})
export class ExcelService {

  constructor() { }

  // exportToExcel(employees: Employee[], fileName: string) {
  //   const flattenedData = employees.flatMap(employee => {
  //     return employee.positions.map(positionData => ({
  //       ID: employee.id,
  //       IDNumber: employee.idNumber,
  //       FirstName: employee.firstName,
  //       LastName: employee.lastName,
  //       Gender: employee.gender,
  //       DateOfBirth: employee.dateOfBirth,
  //       StartOfWorkDate: employee.startDate,
  //       PositionName: positionData.position.name,
  //       EntryDate: positionData.dateOfEntryIntoOffice,
  //       IsAdministrative: positionData.isManagerialPosition
  //     }));
  //   });

  //   const updatedFlattenedData = flattenedData.map(item => {
  //     const positions = item.PositionName.split(',');
  //     if (positions.length > 1) {
  //       return positions.map(position => ({
  //         ...item,
  //         PositionName: position.trim()
  //       }));
  //     } else {
  //       return item;
  //     }
  //   }).flat();

  //   const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(updatedFlattenedData);
  //   const workbook: XLSX.WorkBook = XLSX.utils.book_new();
  //   XLSX.utils.book_append_sheet(workbook, worksheet, 'data');

  //   XLSX.writeFile(workbook, fileName + '.xlsx');
  // }

  exportToExcel(employees: Employee[], positions: Position[], fileName: string) {
    const flattenedData = employees.flatMap(employee => {
      return employee.positions.map(positionData => {
        // Find the position object by its ID
        const position = positions.find(pos => pos.id === positionData.positionId);
        const positionName = position ? position.name : 'Unknown Position';
  
        return {
          ID: employee.id,
          IDNumber: employee.idNumber,
          FirstName: employee.firstName,
          LastName: employee.lastName,
          Gender: employee.gender,
          DateOfBirth: employee.dateOfBirth,
          StartDate: employee.startDate,
          PositionName: positionName,
          DateOfEntryIntoOffice: positionData.dateOfEntryIntoOffice,
          isManagerialPosition: positionData.isManagerialPosition
        };
      });
    });
  
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(flattenedData);
    const workbook: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, 'data');
  
    XLSX.writeFile(workbook, fileName + '.xlsx');
  }
  
}


