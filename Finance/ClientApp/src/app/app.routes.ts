import { Routes } from '@angular/router';

import { GoalsComponent } from './components/goals/goals.component';


export const routes: Routes = [
  { path: '', redirectTo: '/goals', pathMatch: 'full' },
  { path: 'goals', component: GoalsComponent },
];
