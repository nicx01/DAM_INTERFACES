import { Injectable } from '@angular/core';
import { HousingLocation } from '../models/housinglocation';

@Injectable({
  providedIn: 'root'
})
export class HousingService {
  housingLocationList: HousingLocation[];

  constructor() {
    // Datos simulados localmente
    this.housingLocationList = [
      {
        id: 1,
        name: 'Apartamento Central',
        city: 'Ciudad A',
        state: 'Estado A',
        photo: 'photo1.jpg',
        availableUnits: 5,
        wifi: true,
        laundry: true
      },
      {
        id: 2,
        name: 'Vivienda en la Playa',
        city: 'Ciudad B',
        state: 'Estado B',
        photo: 'photo2.jpg',
        availableUnits: 3,
        wifi: true,
        laundry: false
      },
      {
        id: 3,
        name: 'Casa de Campo',
        city: 'Ciudad C',
        state: 'Estado C',
        photo: 'photo3.jpg',
        availableUnits: 7,
        wifi: false,
        laundry: true
      }
    ];
  }

  // Método para obtener todas las ubicaciones de vivienda localmente
  getAllHousingLocations(): Promise<HousingLocation[]> {
    return Promise.resolve(this.housingLocationList);
  }

  // Método para obtener una ubicación de vivienda por ID localmente
  getHousingLocationById(id: number): Promise<HousingLocation | undefined> {
    const housingLocation = this.housingLocationList.find(loc => loc.id === id);
    return Promise.resolve(housingLocation);
  }

  submitApplication(firstName: string, lastName: string, email: string) {
    console.log(
      `Homes application received: firstName: ${firstName}, lastName: ${lastName}, email: ${email}.`
    );
  }
}
