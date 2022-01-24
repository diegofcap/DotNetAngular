import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
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

  postVehicle(vehicleType: IVehicle) : Observable<IVehicle>{
    return this.http.post<IVehicle> (this.apiUrl, vehicleType);
  }
}
