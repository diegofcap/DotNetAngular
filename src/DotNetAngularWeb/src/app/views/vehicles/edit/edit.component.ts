import { Component, OnInit } from '@angular/core';
import { IChassis } from 'src/app/models/IChassis';
import { IVehicle } from 'src/app/models/IVehicle';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  vehicleId: number = 0;
  customStylesValidated = false;
  customStylesSearchValidated = false;
  passengersNumber: number| null = 0;
  chassisId: number| null = 0;
  chassisseries: string| null = "";
  chassisnumber: number| null = 0;
  vehicleTypeId: number| null = 0;
  vehicleTypeName: string | undefined = "";
  color: string | null = "";
  
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
          this.color = this.vehicle.color;
          this.passengersNumber = this.vehicle.numberPassengers;
          this.chassisId = this.vehicle.chassisId;
          this.vehicleTypeId = this.vehicle.vehicleTypeId;
          this.vehicleTypeName = this.vehicle.vehicleType?.name;
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

  onSubmit() {
    if(this.chassisnumber != 0 && this.chassisseries != "")
    {
      if(this.vehicle != null)
      {
        this.vehicle.color = this.color;
      }
      
      this.vehicleService.putVehicle(this.vehicle as IVehicle).subscribe(result => {
        window.location.href = "#/vehicles/list";
      }, error => console.error(error));
    }
    else
    {
      this.customStylesSearchValidated = true;
    }
  }
}
