import { Component, OnInit } from '@angular/core';
import { IChassis } from 'src/app/models/IChassis';
import { IVehicle } from 'src/app/models/IVehicle';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-find',
  templateUrl: './find.component.html',
  styleUrls: ['./find.component.scss']
})
export class FindComponent implements OnInit {

  vehicleId: number = 0;
  chassisId: number| null = 0;
  chassisseries: string| null = "";
  chassisnumber: number| null = 0;
  customStylesSearchValidated = false;
  
  vehicle?: IVehicle;
  
  constructor(private vehicleService : VehicleService ) { }

  ngOnInit(): void {
  }

  onSearch() {
    if(this.chassisnumber != 0 && this.chassisseries != "")
    {
      let chassis = {
        series: this.chassisseries,
        number: this.chassisnumber
      }
      
      this.vehicleService.GetVehicleByChassis(chassis as unknown as IChassis).subscribe(result => {
        this.vehicle = result;

        if(this.vehicle != null && this.vehicle?.id != null && this.vehicle?.id > 0)
        {
          this.vehicleId = this.vehicle.id;
        }
        else
        {
          alert("Vehicle not found");
        }
      }, error => console.error(error));
    }
    else
    {
      this.customStylesSearchValidated = true;
    }
  }
}
