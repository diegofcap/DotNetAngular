import { TestBed } from '@angular/core/testing';

import { VehicletypeService } from './vehicletype.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('VehicletypeService', () => {
  let service: VehicletypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(VehicletypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
