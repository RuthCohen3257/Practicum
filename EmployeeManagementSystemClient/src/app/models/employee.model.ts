import { PositionForEmployee } from "./positionForEmployee.model"

export enum Gender
{
    Male,
    Female
}
export class Employee{
    id !:number
    idNumber!:string
    firstName !:string
    lastName !:string
    dateOfBirth !:Date
    startDate !:Date
    gender!: string 
    isActive !: boolean 
    positions !:PositionForEmployee[]
}