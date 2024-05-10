import { Component } from '@angular/core';
import { DailyQuoteComponent } from '../daily-quote/daily-quote.component';
import { StockInfoComponent } from '../stock-info/stock-info.component';
import { CryptoInfoComponent } from '../crypto-info/crypto-info.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    DailyQuoteComponent,
    StockInfoComponent,
    CryptoInfoComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
