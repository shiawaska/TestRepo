import { Component, inject } from '@angular/core';
import { MissionService } from '../../services/mission.service';
import { PlanetsService } from '../../services/planets.service';
import { DiscoveryService } from '../../services/discovery.service';
import { MissionDropDownDto } from '../../interfaces/MissionDropDownDto_model';
import { MissionFormDto } from '../../interfaces/MissionFormDto_model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-missions',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './missions.component.html',
  styleUrl: './missions.component.css',
})
export class MissionsComponent {
  // injected servies
  planetsService = inject(PlanetsService);
  MissionService = inject(MissionService);
  discoveryService = inject(DiscoveryService);

  // objects
  missions: MissionDropDownDto[] = [];
  mission: MissionFormDto = {
    name: '',
    date: new Date(),
    planetId: 0,
    description: '',
  };
  selectedMission: any;
  selectMission(id: number): void {
    this.MissionService.getMission(id).subscribe((mission: MissionFormDto) => {
      this.mission = mission;
    });
  }
}
