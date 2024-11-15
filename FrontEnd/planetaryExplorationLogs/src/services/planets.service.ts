import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { PlanetDropDownDto } from '../interfaces/PlanetDropDownDto_model';
import { requestResult } from '../interfaces/RequestResult_model';
import { PlanetFormDto } from '../interfaces/PlanetFormDto_model';

@Injectable({
  providedIn: 'root',
})
export class PlanetsService {
  constructor(private httpclient: HttpClient) {}

  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error.message);
    return throwError(
      () => new Error('Something bad happened; Check planets service.')
    );
  }

  // query functions
  getPlanets(): Observable<PlanetFormDto[]> {
    return this.httpclient
      .get<requestResult<PlanetFormDto[]>>('http://localhost:5125/Planets')
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  getPlanet(id: number): Observable<PlanetFormDto> {
    return this.httpclient
      .get<requestResult<PlanetFormDto>>(
        `http://localhost:5125/api/Planet/${id}`
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  getPlanetsDropdown(): Observable<PlanetDropDownDto[]> {
    return this.httpclient
      .get<requestResult<PlanetDropDownDto[]>>(
        'http://localhost:5125/api/Planet/dropdown'
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  // command functions
  addPlanet(planet: PlanetFormDto): Observable<number> {
    return this.httpclient
      .post<requestResult<number>>('http://localhost:5125/api/Planet', planet)
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  updatePlanet(planet: PlanetFormDto, id: number): Observable<number> {
    return this.httpclient
      .put<requestResult<number>>(
        `http://localhost:5125/api/Planet/${id}`,
        planet
      )
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }

  deletePlanet(id: number): Observable<number> {
    return this.httpclient
      .delete<requestResult<number>>(`http://localhost:5125/api/Planet/${id}`)
      .pipe(
        map((response) => response.data),
        catchError(this.handleError)
      );
  }
}
