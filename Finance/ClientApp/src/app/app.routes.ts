import { Routes } from '@angular/router';

import { GoalsComponent } from './components/goals/goals.component';


export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'goals', component: GoalsComponent },
];
