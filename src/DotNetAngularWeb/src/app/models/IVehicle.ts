import { IChassis } from "./IChassis";
import { IVehicleType } from "./IVehicleType";

export interface IVehicle {
    id: number | null;
    color: string | null;
    createAt: Date | null,
    updateAt: Date | null,
    chassisId: number | null;
    vehicleTypeId: number | null;
    numberPassengers: number | null;
    vehicleType: IVehicleType | null;
}