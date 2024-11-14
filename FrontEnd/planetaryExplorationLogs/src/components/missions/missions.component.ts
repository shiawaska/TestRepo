import { Component, inject } from '@angular/core';
import { MissionService } from '../../services/mission.service';
import { PlanetsService } from '../../services/planets.service';
import { DiscoveryService } from '../../services/discovery.service';

@Component({
  selector: 'app-missions',
  standalone: true,
  imports: [],
  templateUrl: './missions.component.html',
  styleUrl: './missions.component.css',
})
export class MissionsComponent {
  planetsService = inject(PlanetsService);
  MissionService = inject(MissionService);
  discoveryService = inject(DiscoveryService);
}
