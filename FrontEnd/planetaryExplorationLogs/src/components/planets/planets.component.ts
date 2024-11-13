import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { PlanetsService } from '../../services/planets.service';
import { FormsModule } from '@angular/forms';
import { PlanetFormDto } from '../../interfaces/PlanetFormDto_model';

@Component({
  selector: 'app-planets',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './planets.component.html',
  styleUrl: './planets.component.css'
})
export class PlanetsComponent {
  planetsService = inject(PlanetsService);
  showHistory: boolean = true;
  showForm: boolean = false;
  planets: PlanetFormDto[] = []
  planet: PlanetFormDto = { name: '', type: '', climate: '', terrain: '', population: '' };

  toggleForm(): void {
    this.showForm = !this.showForm;
  }
  toggleHistory(): void {
    this.showHistory = !this.showHistory;
  }

  getPlanets(): void {
    this.planetsService.getPlanets().subscribe(planets => {
      this.planets = planets;
    });
  }

  addPlanet(event: Event): void {
    event.preventDefault();
    this.planetsService.addPlanet(this.planet).subscribe(planet => {
      planet = this.planet;
      console.log('Planet created:', this.planet);    
    console.log('Submitting planet:', this.planet);
    this.planets.push(this.planet);
    this.planets = [];
    this.showForm = false;
    this.showHistory = true;
  }
}
}
