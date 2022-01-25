import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddComponent } from './add/add.component';
import { DeleteComponent } from './delete/delete.component';
import { EditComponent } from './edit/edit.component';
import { FindComponent } from './find/find.component';
import { ListComponent } from './list/list.component';

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
      },
      {
        path: 'edit',
        component: EditComponent,
        data: {
          title: 'Edit a Vehicle'
        }
      },
      {
        path: 'delete',
        component: DeleteComponent,
        data: {
          title: 'Delete a Vehicle'
        }
      },
      {
        path: 'find',
        component: FindComponent,
        data: {
          title: 'Delete a Vehicle'
        }
      },
      {
        path: 'list',
        component: ListComponent,
        data: {
          title: 'List all Vehicles'
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
