import { PositionForEmployee } from "./positionForEmployee.model"

enum Gender
{
    Male,
    Female
}
export class Employee{
    id !:number
    idNumber!:number
    firstName !:string
    lastName !:string
    dateOfBirth !:Date
    startDate !:Date
    gender !:Gender 
    isActive !: boolean 
    positions !:PositionForEmployee[]
}