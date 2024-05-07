import { Routes } from '@angular/router';
import { KanbanComponent } from './kanban/kanban.component'; // Ajuste o caminho conforme necessário
import { DashboardTestComponent } from './dashboard-test/dashboard-test.component';

export const routes: Routes = [
  {
    path: 'kanban',
    component: KanbanComponent
  },
  {
    path: 'dashboard',
    component: DashboardTestComponent
  }
];
