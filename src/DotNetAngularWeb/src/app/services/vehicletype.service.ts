import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {IVehicleType} from '../models/IVehicleType';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VehicletypeService {
  private apiUrl = environment.apiUrl + '/vehicletypes';
  constructor(private http: HttpClient) { }

  getVehicleTypes() : Observable<IVehicleType[]>{
    return this.http.get<IVehicleType[]> (this.apiUrl);
  }

  getVehicleTypeById(id:number) : Observable<IVehicleType>{
    return this.http.get<IVehicleType> (this.apiUrl + "/" + id);
  }

  postVehicleType(vehicleType: IVehicleType) : Observable<IVehicleType>{
    return this.http.post<IVehicleType> (this.apiUrl, vehicleType);
  }
}
