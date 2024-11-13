import { Component, inject, OnInit } from '@angular/core';
import { PlanetsService } from '../../services/planets.service';
import { PlanetDropDownDto } from '../../interfaces/PlanetDropDownDto_model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent implements OnInit {
  planets: PlanetDropDownDto[] = []; 
  planetsService = inject(PlanetsService);

  ngOnInit(): void {
    this.getPlanetsDropdown();    
  }

  getPlanetsDropdown(): void {
    this.planetsService.getPlanetsDropdown().subscribe(planets => {
      this.planets = planets;
    });
  } 
}
