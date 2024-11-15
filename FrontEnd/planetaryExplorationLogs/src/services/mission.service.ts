import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { MissionDropDownDto } from '../interfaces/MissionDropDownDto_model';
import { DiscoveryFormDto } from '../interfaces/DiscoveryFormDto_model';
import { MissionFormDto } from '../interfaces/MissionFormDto_model';
import { requestResult } from '../interfaces/RequestResult_model';

@Injectable({
  providedIn: 'root',
})
export class MissionService {
  constructor(private httpclient: HttpClient) {}

  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error.message);
    return throwError(
      () => new Error('Something bad happened; Check Mission service.')
    );
  }
  // query functions
  getMission(id: number): Observable<MissionFormDto> {
    return this.httpclient
      .get<requestResult<MissionFormDto>>(
        `http://localhost:5125/api/Mission/${id}`
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  getMissionDropDownDto(): Observable<MissionDropDownDto[]> {
    return this.httpclient
      .get<requestResult<MissionDropDownDto[]>>(
        'http://localhost:5125/api/Mission/dropdown'
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  getDiscoveriesForMission(missionId: number): Observable<DiscoveryFormDto[]> {
    return this.httpclient
      .get<requestResult<DiscoveryFormDto[]>>(
        `http://localhost:5125/api/Mission/${missionId}/discovery`
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  //command functions
  deleteMission(id: number): Observable<number> {
    return this.httpclient
      .delete<requestResult<number>>(`http://localhost:5125/api/Mission/${id}`)
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  updateMission(mission: MissionFormDto, id: number): Observable<number> {
    return this.httpclient
      .put<requestResult<number>>(
        `http://localhost:5125/api/Mission/${id}`,
        mission
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  createMission(mission: MissionFormDto): Observable<number> {
    return this.httpclient
      .post<requestResult<number>>('http://localhost:5125/api/Mission', mission)
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }
}
