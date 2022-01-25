import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IChassis } from 'src/app/models/IChassis';
import { IVehicle } from 'src/app/models/IVehicle';
import { IVehicleType } from 'src/app/models/IVehicleType';
import { VehicleService } from 'src/app/services/vehicle.service';
import { VehicletypeService } from 'src/app/services/vehicletype.service';

@Component({
  selector: 'app-form-controls',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit {
  customStylesValidated = false;
  passengersNumber: number = 0;
  chassisseries: string = "";
  chassisnumber: number = 0;
  vehicleTypeId: number = 0;
  color: string = "";
  
  forecasts?: IVehicleType[];
  type?: IVehicleType;
  vehicle?: IVehicle;
  	
  constructor(private vehicleTypeService : VehicletypeService, private vehicleService : VehicleService ) { }

  ngOnInit(): void {
  		this.vehicleTypeService.getVehicleTypes().subscribe(result => {
			this.forecasts = result;
	  }, error => console.error(error));
  }

  onSubmit1() {
    if(this.chassisnumber != 0 && this.chassisseries != "" && this.vehicleTypeId != 0 && this.color != "" && this.passengersNumber != 0)
    {
      let chassis = {
        series: this.chassisseries,
        number: this.chassisnumber,
      }
      
      let vehicle = {
        color: this.color,
        vehicleTypeId: this.vehicleTypeId,
        numberPassengers: this.passengersNumber,
        chassis: chassis
      }
      
      this.vehicleService.GetVehicleByChassis(chassis as unknown as IChassis).subscribe(result => {
        this.vehicle = result;

        if(this.vehicle != null && this.vehicle?.id != null && this.vehicle?.id > 0)
        {
          alert("Vehicle already exists");
        }
        else
        {
          this.vehicleService.postVehicle(vehicle as unknown as IVehicle).subscribe(result => {
            window.location.href = "#/vehicles/list";
          }, error => console.error(error));
        }
      }, error => console.error(error));
    }
    else
    {
      this.customStylesValidated = true;
    }
  }

  onChange(event: any) {
    this.vehicleTypeId = event.target.value;
    
    this.vehicleTypeService.getVehicleTypeById(event.target.value).subscribe(result => {
      this.type = result;
      this.passengersNumber = this.type?.numberOfPassengers;
      }, error => console.error(error));
    }
}
