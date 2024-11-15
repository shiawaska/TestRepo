import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { DiscoveryFormDto } from '../interfaces/DiscoveryFormDto_model';
import { requestResult } from '../interfaces/RequestResult_model';
import { DiscoveryTypeDto } from '../interfaces/DiscoveryTypeDto_model';
import { DiscoveryDropDownDto } from '../interfaces/DiscoveryDropDownDto_model';
import { DiscoveryResponse } from '../interfaces/DiscoveryResponseDto_model';
import { response } from 'express';

@Injectable({
  providedIn: 'root',
})
export class DiscoveryService {
  constructor(private httpclient: HttpClient) {}

  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error.message);
    return throwError(
      () => new Error('Something bad happened; Check Discovery service.')
    );
  }

  // command functions
  createDiscovery(discovery: DiscoveryFormDto): Observable<number> {
    return this.httpclient
      .post<number>('http://localhost:5125/api/Discovery', discovery)
      .pipe(catchError(this.handleError));
  }

  deleteDiscovery(id: number): Observable<number> {
    return this.httpclient
      .delete<number>(`http://localhost:5125/api/Discovery/${id}`)
      .pipe(catchError(this.handleError));
  }

  updateDiscovery(discovery: DiscoveryFormDto, id: number): Observable<number> {
    return this.httpclient
      .put<number>(`http://localhost:5125/api/Discovery/${id}`, discovery)
      .pipe(catchError(this.handleError));
  }

  // query functions
  getDiscovery(id: number): Observable<DiscoveryFormDto> {
    return this.httpclient
      .get<requestResult<DiscoveryFormDto>>(
        `http://localhost:5125/api/Discovery/${id}`
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  getDiscoveries(): Observable<DiscoveryFormDto[]> {
    return this.httpclient
      .get<requestResult<DiscoveryFormDto[]>>(
        'http://localhost:5125/api/Discovery'
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  getDiscoveriesForMission(missionId: number): Observable<DiscoveryResponse> {
    return this.httpclient
      .get<requestResult<DiscoveryFormDto[]>>(
        `http://localhost:5125/api/Mission/${missionId}/discovery`
      )
      .pipe(
        map((response) => ({
          data: response.data,
          message: response.message,
        })),
        catchError(this.handleError)
      );
  }

  getDiscoveryTypes(): Observable<DiscoveryTypeDto[]> {
    return this.httpclient
      .get<requestResult<DiscoveryTypeDto[]>>(
        'http://localhost:5125/api/Discovery/types'
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  getDiscoveriesDropDownDto(): Observable<DiscoveryDropDownDto[]> {
    return this.httpclient
      .get<requestResult<DiscoveryDropDownDto[]>>(
        'http://localhost:5125/dropdown'
      )
      .pipe(
        map((response) => {
          console.log('Discoveries drop down: ', response.data);
          return response.data;
        }),
        catchError(this.handleError)
      );
  }
}
