import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { FinancialGoalsService } from '../../services/financial-goal.service';
import { FinancialGoal } from '../../ts/FinancialGoal';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-goals',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule], // Importação do ReactiveFormsModule
  templateUrl: './goals.component.html',
  styleUrls: ['./goals.component.css'] // Correto é styleUrls e deve ser um array
})
export class GoalsComponent implements OnInit {
  formulario!: FormGroup; // Correção de tipo de 'any' para 'FormGroup'
  tituloFormulario: string = '';

  constructor(private financialGoalsService: FinancialGoalsService) { }
  
  ngOnInit(): void {
    this.tituloFormulario = 'Novo Carro';
    this.formulario = new FormGroup({
      id: new FormControl(null),
      amount: new FormControl(null),
      name: new FormControl(null),
      createdOn: new FormControl(null),
      estimatedCompletion: new FormControl(null),
      status: new FormControl(null),
      parcelas: new FormControl(null),
      parcelaAtual: new FormControl(null),
      check: new FormControl(null),
      description: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    const financialGoal: FinancialGoal = this.formulario.value;
    this.financialGoalsService.cadastrar(financialGoal).subscribe({
      next: (result) => alert('FinancialGoal inserido com sucesso.'),
      error: (error) => alert('Erro ao inserir FinancialGoal.')
    });
  }
}
