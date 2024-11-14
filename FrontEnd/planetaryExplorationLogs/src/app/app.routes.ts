import { Routes } from '@angular/router';
import { HomepageComponent } from '../layout/homepage/homepage.component';
import { PlanetsComponent } from '../components/planets/planets.component';
import { MissionsComponent } from '../components/missions/missions.component';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomepageComponent },
  { path: 'planets', component: PlanetsComponent },
  { path: 'missions', component: MissionsComponent },
  { path: '**', redirectTo: 'home' },
];
