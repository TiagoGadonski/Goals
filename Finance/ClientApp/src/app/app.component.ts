import { Component, AfterViewInit, Inject, PLATFORM_ID } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { HttpClientModule } from '@angular/common/http';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { WisdomComponent } from './wisdom/wisdom.component';
import { DailyQuoteComponent } from './daily-quote/daily-quote.component';
import { CryptoInfoComponent } from './crypto-info/crypto-info.component';
import { StockInfoComponent } from './stock-info/stock-info.component';
import { isPlatformBrowser } from '@angular/common';
import * as feather from 'feather-icons';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    // Angular modules
    RouterOutlet,
    HttpClientModule,

    // Angular Material modules
    MatSlideToggleModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatListModule,

    // Custom components
    SidebarComponent,
    FooterComponent,
    WisdomComponent,
    DailyQuoteComponent,
    CryptoInfoComponent,
    StockInfoComponent,
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  title = 'ClientApp';

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

  ngAfterViewInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      feather.replace();  // Initialize Feather icons once the platform is confirmed to be a browser
    }
  }
}
