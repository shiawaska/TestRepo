import { Component, inject, Inject, OnInit } from '@angular/core';
import { DiscoveryService } from '../../services/discovery.service';
import { DiscoveryFormDto } from '../../interfaces/DiscoveryFormDto_model';
import { DiscoveryTypeDto } from '../../interfaces/DiscoveryTypeDto_model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DiscoveryDropDownDto } from '../../interfaces/DiscoveryDropDownDto_model';
import { get } from 'http';
import { MissionService } from '../../services/mission.service';
import { MissionFormDto } from '../../interfaces/MissionFormDto_model';
import { catchError, map, Observable, of } from 'rxjs';
import { MissionDropDownDto } from '../../interfaces/MissionDropDownDto_model';

@Component({
  selector: 'app-discoveries',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './discoveries.component.html',
  styleUrl: './discoveries.component.css',
})
export class DiscoveriesComponent implements OnInit {
  // injected services
  discoveryService = inject(DiscoveryService);
  missionService = inject(MissionService);

  // discovery objects and variables
  discoveryTypes: DiscoveryTypeDto[] = [];
  discoveriesDropDown: DiscoveryDropDownDto[] = [];
  discoveries: DiscoveryFormDto[] = [];
  discovery: DiscoveryFormDto = {
    missionId: 0,
    discoveryTypeId: 0,
    name: '',
    description: '',
    location: '',
  };
  discoveryType: DiscoveryTypeDto = {
    id: 0,
    name: '',
    description: '',
  };

  // mission objects and variables
  mission: MissionFormDto = {
    name: '',
    date: new Date(),
    planetId: 0,
    description: '',
  };
  missions: MissionDropDownDto[] = [];

  // variables to show or hide elements
  SelectedDiscovery: number = 1; // really should be a singleton service
  selectedMission: number = 1; // really should be a singleton service
  showDiscoveryDetails: boolean = false;
  updateDiscoveryform: boolean = false;
  discoverySelector: boolean = true;
  createDiscoveryForm: boolean = false;

  ngOnInit(): void {
    this.getDiscoveryTypes();
    this.getDiscoveries();
    this.getDiscoveriesDropDownDto();
    this.getMissionDropdown();
  }
  // query functions
  getMission(id: number): Observable<string> {
    return this.missionService.getMission(id).pipe(
      map((mission) => mission.name),
      catchError(() => of('Mission not found'))
    );
  }

  getMissionDropdown(): void {
    this.missionService
      .getMissionDropDownDto()
      .subscribe((missions: MissionDropDownDto[]) => {
        // console.log('missions', missions);
        this.missions = missions;
      });
  }

  getDiscoveryTypes(): void {
    this.discoveryService
      .getDiscoveryTypes()
      .subscribe((types: DiscoveryTypeDto[]) => {
        this.discoveryTypes = types;
        // console.log('Discovery types: ', this.discoveryTypes);
      });
  }

  getDiscoveries(): void {
    this.discoveryService
      .getDiscoveries()
      .subscribe((discoveries: DiscoveryFormDto[]) => {
        this.discoveries = discoveries;
      });
  }
  getDiscoveriesDropDownDto(): void {
    this.discoveryService
      .getDiscoveriesDropDownDto()
      .subscribe((discoveriesDropDown: DiscoveryDropDownDto[]) => {
        this.discoveriesDropDown = discoveriesDropDown;
      });
  }

  getDiscovery(id: number): void {
    this.discoveryService
      .getDiscovery(id)
      .subscribe((discovery: DiscoveryFormDto) => {
        this.discovery = discovery;
        // console.log('discovery', this.discovery);
        this.getDiscoveryTypeName(this.SelectedDiscovery);
        this.getDiscoveryTypeDescription(this.SelectedDiscovery);
        this.showDiscoveryDetails = true;
      });
  }

  getDiscoveryTypeName(id: number): string {
    for (let type of this.discoveryTypes) {
      if (type.id === id) {
        // console.log('name', type.name);
        return type.name;
      }
    }
    return 'Name not found';
  }

  getDiscoveryTypeDescription(id: number): string {
    for (let type of this.discoveryTypes) {
      if (type.id === id) {
        // console.log('description', type.description);
        return type.description;
      }
    }
    return 'Description not found';
  }

  // command functions
  deleteDiscovery(id: number): void {
    this.discoveryService.deleteDiscovery(id).subscribe(() => {
      this.getDiscoveries();
      this.getDiscoveriesDropDownDto();
      this.showDiscoveryDetails = false;
    });
  }

  updateDiscovery(): void {
    this.discoveryService
      .updateDiscovery(this.discovery, this.SelectedDiscovery)
      .subscribe(() => {
        this.getDiscoveries();
        this.updateDiscoveryToggle(false);
      });
  }

  createDiscovery(): void {
    this.discovery.missionId = this.selectedMission;
    this.discoveryService.createDiscovery(this.discovery).subscribe(() => {
      this.getDiscoveries();
      this.createDiscoveryToggle(false);
      this.getDiscoveriesDropDownDto();
    });
  }

  // toggles for elements visaibility
  updateDiscoveryToggle(bool: boolean): void {
    this.updateDiscoveryform = bool;
    this.showDiscoveryDetails = false;
    this.discoverySelector = !bool;
  }

  createDiscoveryToggle(bool: boolean): void {
    this.createDiscoveryForm = bool;
    this.discoverySelector = !bool;
    this.showDiscoveryDetails = false;
    this.discovery = {
      missionId: 0,
      discoveryTypeId: 0,
      name: '',
      description: '',
      location: '',
    };
  }
}
