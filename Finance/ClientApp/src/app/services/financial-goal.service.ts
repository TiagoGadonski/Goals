import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FinancialGoal } from '../ts/FinancialGoal';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root' // Registra o serviço como um provedor no módulo raiz
})
export class FinancialGoalsService {
  apiUrl = 'http://localhost:5000/FinancialGoal';

  constructor(private http: HttpClient) { }

  listar(): Observable<FinancialGoal[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<FinancialGoal[]>(url);
  }

  buscar(placa: string): Observable<FinancialGoal> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.get<FinancialGoal>(url);
  }

  cadastrar(financialGoal: FinancialGoal): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<FinancialGoal>(url, financialGoal, httpOptions);
  }

  alterar(financialGoal: FinancialGoal): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<FinancialGoal>(url, financialGoal, httpOptions);
  }

  excluir(placa: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
