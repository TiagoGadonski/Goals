import { Routes } from '@angular/router';
import { KanbanComponent } from './kanban/kanban.component'; 
import { DashboardTestComponent } from './dashboard-test/dashboard-test.component';
import { BlogComponent } from './blog/blog.component';
import { FinancesComponent } from './finances/finances.component';
import { GoalsComponent } from './goals/goals.component';
import { NotesComponent } from './notes/notes.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
  {
    path: 'kanban',
    component: KanbanComponent
  },
  {
    path: 'dashboard',
    component: DashboardTestComponent
  },
  {
    path: 'blog',
    component: BlogComponent
  },
  {
    path: 'finances',
    component: FinancesComponent
  },
  {
    path: 'goals',
    component: GoalsComponent
  },
  {
    path: 'notes',
    component: NotesComponent
  },
  {
    path: 'home',
    component: HomeComponent
  },

];
