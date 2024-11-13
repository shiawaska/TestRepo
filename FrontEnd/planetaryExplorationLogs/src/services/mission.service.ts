import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { MissionDropDownDto } from '../interfaces/MissionDropDownDto_model';
import { DiscoveryFormDto } from '../interfaces/DiscoveryFormDto_model';
import { MissionFormDto } from '../interfaces/MissionDto_model';


@Injectable({
  providedIn: 'root'
})
export class MissionService {

  constructor(private httpclient: HttpClient) { }


  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error.message);
    return throwError(() => new Error('Something bad happened; Check Mission service.'));
  }
  
  getMissionDropDownDto() :Observable<MissionDropDownDto>{
    return this.httpclient.get<MissionDropDownDto>('http://localhost:5125/api/Mission/dropdown').pipe(
      catchError(this.handleError)
    );
  }
  getDiscoveriesForMission(missionId: number): Observable<DiscoveryFormDto[]> {
    return this.httpclient.get<DiscoveryFormDto[]>(`http://localhost:5125/api/Mission/${missionId}/discovery`).pipe(
      catchError(this.handleError)
    );
  }
  deleteMission(id: number): Observable<number> {
    return this.httpclient.delete<number>(`http://localhost:5125/api/Mission/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  updateMission(mission: MissionFormDto, id: number): Observable<number> {
    return this.httpclient.put<number>(`http://localhost:5125/api/Mission/${id}`, mission).pipe(
      catchError(this.handleError)
    );
  }
  createMission(mission: MissionFormDto): Observable<number> {
    return this.httpclient.post<number>('http://localhost:5125/api/Mission', mission).pipe(
      catchError(this.handleError)
    );
  }
  // getmissions uses a dbcontext model not a dto model

}
