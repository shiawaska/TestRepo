import { Component, inject, NgModule, OnInit } from '@angular/core';
import { PlanetsService } from '../../services/planets.service';
import { PlanetDropDownDto } from '../../interfaces/PlanetDropDownDto_model';
import { CommonModule } from '@angular/common';
import { PlanetFormDto } from '../../interfaces/PlanetFormDto_model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent implements OnInit {
  planets: PlanetDropDownDto[] = []; 
  planetsService = inject(PlanetsService);
  planetlist: PlanetFormDto[] = [];
  showSelector: boolean = true;
  selectedPlanet:number = 1;
  showPlanet: boolean = false;
  planet: PlanetFormDto = { name: '', type: '', climate: '', terrain: '',  population: '',};
  main: boolean = true;
  showPlanetList: boolean = false;
  errorMessage: any;
  

  ngOnInit(): void {
    this.getPlanetsDropdown(); 
    this.getPlanets();   
  }
  selectorToggle(): void {
    this.showSelector = !this.showSelector;
  }
  showPlanetToggle(): void {
    this.showPlanet = !this.showPlanet;
  }
  mainToggle(): void {
    this.main = !this.main;
this.showPlanetList = !this.showPlanetList;
  }
  

  getPlanetsDropdown(): void {
    this.planetsService.getPlanetsDropdown().subscribe(planets => {
      this.planets = planets;
    });
  } 
  getPlanets(): void {  
    this.planetsService.getPlanets().subscribe(planets => {
      this.planetlist = planets;
    });
  }
  getPlanet(id: number): void {
    this.planetsService.getPlanet(id).subscribe(planet => {
      this.planet = planet;
      console.log(planet);
    }, error => {
      this.errorMessage = error;
      console.error('Error fetching planet:', error);
    });
    this.selectorToggle();
    this.showPlanetToggle();

  }

  
}
