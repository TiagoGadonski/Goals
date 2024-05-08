import { Component, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';
import * as feather from 'feather-icons';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [MatSidenavModule, MatToolbarModule, MatIconModule, MatListModule, RouterModule, CommonModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent implements AfterViewInit{
  opened = true;  // Inicializa como verdadeiro para o sidebar começar aberto

  constructor() { }

  // Função para alternar o estado do sidebar
  toggleSidebar() {
    this.opened = !this.opened;
  }

  ngAfterViewInit() {
    if (typeof window !== 'undefined') {
      feather.replace();
    }
  }
}