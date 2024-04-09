import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Position } from '../../models/position.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PositionService {

  public baseUrl='https://localhost:7250/api/Position'
  constructor(private http:HttpClient) { }

  addPosition(position:Position):Observable<Position>{
    return this.http.post<Position>(this.baseUrl,position)
  }
  getPositions():Observable<Position[]>{
    return this.http.get<Position[]>(this.baseUrl)
}
}