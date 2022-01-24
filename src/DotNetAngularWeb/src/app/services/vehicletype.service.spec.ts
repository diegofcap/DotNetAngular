import { TestBed } from '@angular/core/testing';

import { VehicletypeService } from './vehicletype.service';

describe('VehicletypeService', () => {
  let service: VehicletypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehicletypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
