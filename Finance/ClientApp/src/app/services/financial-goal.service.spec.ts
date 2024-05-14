import { TestBed } from '@angular/core/testing';

import { FinancialGoalsService } from './financial-goal.service';

describe('FinancialGoalService', () => {
  let service: FinancialGoalsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FinancialGoalsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
