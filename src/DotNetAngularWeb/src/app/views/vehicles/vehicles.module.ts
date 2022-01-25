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
  SharedModule
} from '@coreui/angular';

import { ComponentsModule } from '../../../components/components.module';

import { VehiclesRoutingModule } from './vehicles-routing.module';
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list/list.component';

@NgModule({
  declarations: [
    AddComponent,
    ListComponent
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
    ListGroupModule
  ]
})
export class VehiclesModule {
}
