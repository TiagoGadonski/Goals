// crypto-info.component.ts
import { OnInit } from '@angular/core';
import { CryptoInfoService } from '../crypto-info.service';
import { HttpClientModule } from '@angular/common/http';
import { NgModule, Component } from '@angular/core';

@Component({
  selector: 'app-crypto-info',
  standalone: true,
  templateUrl: './crypto-info.component.html',
  styleUrls: ['./crypto-info.component.css'],
  imports: [HttpClientModule]
})
export class CryptoInfoComponent implements OnInit {
  cryptoInfo: any;

  constructor(private cryptoInfoService: CryptoInfoService) { }

  ngOnInit() {
    this.cryptoInfoService.getCryptoInfo().subscribe(data => {
      this.cryptoInfo = data;
    });
  }
}
