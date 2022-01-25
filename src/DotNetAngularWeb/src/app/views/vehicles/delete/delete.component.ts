import { Component, OnInit } from '@angular/core';
import { IChassis } from 'src/app/models/IChassis';
import { IVehicle } from 'src/app/models/IVehicle';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.scss']
})
export class DeleteComponent implements OnInit {

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
    if(this.chassisnumber != null && this.chassisseries != "")
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
    else if (this.chassisnumber == 0)
    {
      alert("Chassis number should be greater than 0");
      this.customStylesSearchValidated = true;
    }
    else
    {
      this.customStylesSearchValidated = true;
    }
  }

  public visible = false;

  toggleConfirm() {
    this.visible = !this.visible;
  }

  handleConfirmChange(event: any) {
    this.visible = event;
  }

  confirmDelete() {
    if(this.vehicle != null)
    {
      this.vehicleService.deleteVehicle(this.vehicle.id).subscribe(result => {
        window.location.href = "#/vehicles/list";
      }, error => console.error(error));
    }
    else
    {
      this.toggleConfirm();
      alert("Vehicle not found");
    }
  }
}
