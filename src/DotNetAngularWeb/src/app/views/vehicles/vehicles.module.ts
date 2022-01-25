import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
  ButtonGroupModule,
  ButtonModule,
  CardModule,
  DropdownModule,
  FormModule,
  GridModule,
  ListGroupModule,
  TableModule,
  SharedModule,
  ModalModule
} from '@coreui/angular';

import { ComponentsModule } from '../../../components/components.module';

import { VehiclesRoutingModule } from './vehicles-routing.module';
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { DeleteComponent } from './delete/delete.component';
import { FindComponent } from './find/find.component';

@NgModule({
  declarations: [
    AddComponent,
    ListComponent,
    EditComponent,
    DeleteComponent,
    FindComponent
  ],
  imports: [
    CommonModule,
    VehiclesRoutingModule,
    ComponentsModule,
    CardModule,
    FormModule,
    GridModule,
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    FormModule,
    ButtonModule,
    ButtonGroupModule,
    DropdownModule,
    SharedModule,
    TableModule,
    ListGroupModule,
    ModalModule
  ]
})
export class VehiclesModule {
}
