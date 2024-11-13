import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { DiscoveryFormDto } from '../interfaces/DiscoveryFormDto_model';

@Injectable({
  providedIn: 'root'
})
export class DiscoveryService {

  constructor(private httpclient: HttpClient) { }


  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error.message);
    return throwError(() => new Error('Something bad happened; Check Discovery service.'));
  }


  deleteDiscovery(id: number): Observable<number> {
    return this.httpclient.delete<number>(`http://localhost:5125/api/Discovery/${id}`).pipe(
      catchError(this.handleError)
    );
  }


  updateDiscovery(discovery: DiscoveryFormDto, id: number): Observable<number> {
    return this.httpclient.put<number>(`http://localhost:5125/api/Discovery/${id}`, discovery).pipe(
      catchError(this.handleError)
    );
  }

  getDiscovery(id: number): Observable<DiscoveryFormDto> {
    return this.httpclient.get<DiscoveryFormDto>(`http://localhost:5125/api/Discovery/${id}`).pipe(
      catchError(this.handleError)
    );
  }


  createDiscovery(discovery: DiscoveryFormDto): Observable<number> {
    return this.httpclient.post<number>('http://localhost:5125/api/Discovery', discovery).pipe(
      catchError(this.handleError)
    );
  }

  getDiscoveries(): Observable<DiscoveryFormDto[]> {
    return this.httpclient.get<DiscoveryFormDto[]>('http://localhost:5125/api/Discovery').pipe(
      catchError(this.handleError)
    );
  }
}
