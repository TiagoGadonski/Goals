export  class FinancialGoal {
    id: number; // Chave primária
    amount: number; // Valor da meta financeira
    name: string; // Nome da meta
    createdOn: Date; // Data de criação da meta
    estimatedCompletion?: Date; // Previsão de término (opcional)
    status: string; // Status da meta (ex: Active, Completed, Cancelled)
    parcelas: string; // Representação das parcelas, presumivelmente como uma string
    parcelaAtual: string; // Indicador da parcela atual
    check: boolean; // Uma marcação de checkbox, por exemplo
    description: string; // Descrição da meta financeira

    constructor(
        id: number,
        amount: number,
        name: string,
        createdOn: Date,
        status: string,
        parcelas: string,
        parcelaAtual: string,
        check: boolean,
        description: string,
        estimatedCompletion?: Date
    ) {
        this.id = id;
        this.amount = amount;
        this.name = name;
        this.createdOn = createdOn;
        this.estimatedCompletion = estimatedCompletion;
        this.status = status;
        this.parcelas = parcelas;
        this.parcelaAtual = parcelaAtual;
        this.check = check;
        this.description = description;
    }
}