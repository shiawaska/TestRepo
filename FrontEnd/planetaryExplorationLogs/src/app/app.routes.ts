import { Routes } from '@angular/router';
import { HomepageComponent } from '../layout/homepage/homepage.component';

export const routes: Routes = [
    {path:'', pathMatch:'full', redirectTo:'home'},
    {path:'home', component: HomepageComponent},
    {path:'**', redirectTo:'home'},
    // {path:'Planet', component: PlanetComponent},
    // {path:'Mission', component: MissionComponent}
];
