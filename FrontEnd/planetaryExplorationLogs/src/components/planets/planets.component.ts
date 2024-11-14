import { Component, inject, NgModule, OnInit } from '@angular/core';
import { PlanetsService } from '../../services/planets.service';
import { PlanetDropDownDto } from '../../interfaces/PlanetDropDownDto_model';
import { CommonModule } from '@angular/common';
import {
  PlanetFormDto,
  PlanetFormDtoModel,
} from '../../interfaces/PlanetFormDto_model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-planets',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './planets.component.html',
  styleUrl: './planets.component.css',
})
export class PlanetsComponent implements OnInit {
  // injected service
  planetsService = inject(PlanetsService);

  // global variables
  planets: PlanetDropDownDto[] = [];

  planetlist: PlanetFormDto[] = [];
  planet: PlanetFormDto = {
    name: '',
    type: '',
    climate: '',
    terrain: '',
    population: '',
  };
  planetDto: PlanetFormDto = {
    name: '',
    type: '',
    climate: '',
    terrain: '',
    population: '',
  };

  // booleans for showing elements
  showSelector: boolean = true;
  showPlanet: boolean = false;
  showPlanetList: boolean = false;
  main: boolean = true;
  createplanet: boolean = false;

  // selected planet from dropdown
  selectedPlanet: number = 1;

  // error message
  errorMessage: any;

  ngOnInit(): void {
    this.getPlanetsDropdown();
    this.getPlanets();
  }

  // element toggle functions
  selectorToggle(): void {
    this.showSelector = !this.showSelector;
  }
  showPlanetToggle(): void {
    this.showPlanet = !this.showPlanet;
  }
  listToggle(): void {
    this.showPlanetList = !this.showPlanetList;
  }

  // function to get all planet names and ids
  getPlanetsDropdown(): void {
    this.planetsService.getPlanetsDropdown().subscribe((planets) => {
      this.planets = planets;
    });
  }
  // function to get all planets and their details
  getPlanets(): void {
    this.planetsService.getPlanets().subscribe((planets) => {
      this.planetlist = planets;
    });
  }
  // function to get a planet by id
  getPlanet(id: number): void {
    this.planetsService.getPlanet(id).subscribe(
      (planet) => {
        this.planet = planet;
        console.log(planet);
      },
      (error) => {
        this.errorMessage = error;
        console.error('Error fetching planet:', error);
      }
    );
  }
  // function to select a planet from the dropdown and show the planet details
  selectPlanet(id: number): void {
    this.getPlanet(id);
    this.showPlanet = true;
  }
  // function to delete a planet and update the planet list and dropdown
  deletePlanet(id: number): void {
    this.planetsService.deletePlanet(id).subscribe(
      (response) => {
        console.log('Planet deleted:', response);
        this.getPlanets();
      },
      (error) => {
        this.errorMessage = error;
        console.error('Error deleting planet:', error);
      }
    );
    this.showPlanetToggle();
    this.getPlanets();
    this.getPlanetsDropdown();
  }
  // function to show the form to create a planet and hide the main page
  createplanetToggle(): void {
    this.main = false;
    this.createplanet = true;
  }
  // fucntion to cancel the creation of a planet
  createplanetCancel(): void {
    this.createplanet = false;
    this.main = true;
  }
  // create a planet object and send it to the service with the form data
  // update the planet list and dropdown
  // hide the form and show the main page
  createPlanet(event: Event): void {
    event.preventDefault();

    this.planetsService.addPlanet(this.planetDto).subscribe(
      (response) => {
        console.log('Planet created:', response);
      },
      (error) => {
        this.errorMessage = error;
        console.error('Error creating planet:', error);
      }
    );
    this.createplanet = false;
    this.getPlanets();
    this.getPlanetsDropdown();
    this.showPlanetToggle();
    this.main = true;
  }
}
