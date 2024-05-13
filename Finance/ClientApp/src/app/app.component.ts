import { Component, AfterViewInit, Inject, PLATFORM_ID } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';  // Importe o RouterModule

import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';

import { SidebarComponent } from './components/sidebar/sidebar.component';
import { FooterComponent } from './components/footer/footer.component';

import { isPlatformBrowser } from '@angular/common';
import * as feather from 'feather-icons';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule, // For common directives like NgIf, NgFor
    HttpClientModule,
    RouterModule, // Import RouterModule to use RouterOutlet
    MatSlideToggleModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatListModule,
    SidebarComponent, // Ensure SidebarComponent is standalone or part of another imported NgModule
    FooterComponent  // Ensure FooterComponent is standalone or part of another imported NgModule
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  title = 'ClientApp';

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

  ngAfterViewInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      feather.replace(); // Initialize Feather icons once the platform is confirmed to be a browser
    }
  }
}
