import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddComponent } from './add/add.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Vehicles'
    },
    children: [
      {
        path: '',
        redirectTo: 'vehicles'
      },
      {
        path: 'add',
        component: AddComponent,
        data: {
          title: 'Add new Vehicle'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehiclesRoutingModule {
}
