import { Component, OnInit } from '@angular/core';
import { IVehicle } from 'src/app/models/IVehicle';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  forecasts?: IVehicle[];
  constructor(private vehicleService : VehicleService ) { }

  ngOnInit(): void {
    this.vehicleService.getVehicles().subscribe(result => {
      this.forecasts = result;
	  }, error => console.error(error));
  }

}
