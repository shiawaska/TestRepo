import { Component, inject, OnInit } from '@angular/core';
import { MissionService } from '../../services/mission.service';
import { PlanetsService } from '../../services/planets.service';
import { DiscoveryService } from '../../services/discovery.service';
import { MissionDropDownDto } from '../../interfaces/MissionDropDownDto_model';
import { MissionFormDto } from '../../interfaces/MissionFormDto_model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PlanetFormDto } from '../../interfaces/PlanetFormDto_model';
import { PlanetDropDownDto } from '../../interfaces/PlanetDropDownDto_model';
import { DiscoveryFormDto } from '../../interfaces/DiscoveryFormDto_model';
import { DiscoveryTypeDto } from '../../interfaces/DiscoveryTypeDto_model';

@Component({
  selector: 'app-missions',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './missions.component.html',
  styleUrl: './missions.component.css',
})
export class MissionsComponent implements OnInit {
  // injected servies
  planetsService = inject(PlanetsService);
  MissionService = inject(MissionService);
  discoveryService = inject(DiscoveryService);

  // mission objects and variables
  missions: MissionDropDownDto[] = [];
  mission: MissionFormDto = {
    name: '',
    date: new Date(),
    planetId: 0,
    description: '',
  };

  // selected mission use to handle the id field of the mission object
  selectedMission: number = 1;

  // planet object
  planets: PlanetDropDownDto[] = [];
  planet: PlanetFormDto = {
    name: '',
    type: '',
    climate: '',
    terrain: '',
    population: '',
  };

  // discovery objects and variables
  discoveries: DiscoveryFormDto[] = [];
  discoveryTypes: DiscoveryTypeDto[] = [];
  discoverType: DiscoveryTypeDto = {
    id: 0,
    name: '',
    description: '',
  };

  // variable to show or hide elements
  showMissionDetails: boolean = false;
  createMissionForm: boolean = false;
  updateMissionForm: boolean = false;
  main: boolean = true;

  ngOnInit(): void {
    this.getMissionDropdown();
    this.getDiscoveryTypes();
    this.getPlanetDropdownDto();
  }

  selectMission(id: number): void {
    this.MissionService.getMission(id).subscribe((mission: MissionFormDto) => {
      this.mission = mission;
      console.log('mission', this.mission, id);
      this.planetsService.getPlanet(mission.planetId).subscribe((planet) => {
        this.planet = planet;
        this.getDiscoveriesForMission(id);
      });
      this.showMissionDetails = true;
    });
  }

  getMissionDropdown(): void {
    this.MissionService.getMissionDropDownDto().subscribe(
      (missions: MissionDropDownDto[]) => {
        console.log('missions', missions);
        this.missions = missions;
      }
    );
  }

  getDiscoveriesForMission(missionId: number): void {
    this.discoveryService
      .getDiscoveriesForMission(missionId)
      .subscribe((discoveries) => {
        this.discoveries = discoveries;
        console.log('discoveries', discoveries);
      });
  }

  getDiscoveryTypes(): void {
    this.discoveryService.getDiscoveryTypes().subscribe((types) => {
      this.discoveryTypes = types;
      console.log('types', types);
    });
  }

  getDiscoveryTypeName(id: number): string {
    for (let type of this.discoveryTypes) {
      if (type.id === id) {
        console.log('name', type.name);
        return type.name;
      }
    }
    return 'Name not found';
  }

  getDiscoveryTypeDescription(id: number): string {
    for (let type of this.discoveryTypes) {
      if (type.id === id) {
        console.log('description', type.description);
        return type.description;
      }
    }
    return 'Description not found';
  }

  deleteMission(id: number): void {
    this.MissionService.deleteMission(id).subscribe((result) => {
      console.log('result', result);
      this.getMissionDropdown();
      this.showMissionDetails = false;
    });
  }

  createMissionToggle(bool: boolean): void {
    this.createMissionForm = bool;
    this.showMissionDetails = false;
    this.main = !bool;
    this.mission = {
      name: '',
      date: new Date(),
      planetId: 0,
      description: '',
    };
  }

  getPlanetDropdownDto(): void {
    this.planetsService.getPlanetsDropdown().subscribe((planets) => {
      this.planets = planets;
      console.log('planets', planets);
    });
  }

  createMission(): void {
    this.MissionService.createMission(this.mission).subscribe((result) => {
      console.log('result', result);
      this.getMissionDropdown();
      this.createMissionToggle(false);
    });
  }

  updateMissionToggle(bool: boolean): void {
    this.updateMissionForm = bool;
    this.createMissionForm = false;
    this.showMissionDetails = false;
    this.main = !bool;
  }

  updateMission(): void {
    this.MissionService.updateMission(
      this.mission,
      this.selectedMission
    ).subscribe((result) => {
      console.log('result', result);
      this.getMissionDropdown();
      this.updateMissionToggle(false);
    });
  }
}
