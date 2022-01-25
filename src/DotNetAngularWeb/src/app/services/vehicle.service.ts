import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IChassis } from '../models/IChassis';
import { IVehicle } from '../models/IVehicle';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private apiUrl = environment.apiUrl + '/vehicles';
  constructor(private http: HttpClient) { }

  getVehicles() : Observable<IVehicle[]>{
    return this.http.get<IVehicle[]> (this.apiUrl);
  }

  getVehicleById(id:number) : Observable<IVehicle>{
    return this.http.get<IVehicle> (this.apiUrl + "/" + id);
  }

  GetVehicleByChassis(chassis: IChassis) : Observable<IVehicle>{
    return this.http.post<IVehicle> (this.apiUrl + "/GetVehicleByChassis", chassis);
  }

  postVehicle(vehicle: IVehicle) : Observable<IVehicle>{
    return this.http.post<IVehicle> (this.apiUrl, vehicle);
  }
}
