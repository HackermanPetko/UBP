import { TestBed, inject } from '@angular/core/testing';

import { DaemonsService } from './daemonsService.service';

describe('DaemonsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DaemonsService]
    });
  });

  it('should be created', inject([DaemonsService], (service: DaemonsService) => {
    expect(service).toBeTruthy();
  }));
});
