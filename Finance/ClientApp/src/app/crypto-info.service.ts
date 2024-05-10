// crypto-info.service.ts
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CryptoInfoService {
  private apiUrl = 'https://api.exemplo.com/crypto';  // Substitua pela URL real da API

  constructor(private http: HttpClient) { }

  getCryptoInfo(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
