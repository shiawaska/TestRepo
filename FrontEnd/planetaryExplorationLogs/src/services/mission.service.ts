import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { MissionDropDownDto } from '../interfaces/MissionDropDownDto_model';


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
  
}
