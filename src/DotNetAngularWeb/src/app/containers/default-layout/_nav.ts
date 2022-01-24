import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Home',
    url: '/dashboard',
    iconComponent: { name: 'cil-home' }
  },
  {
    title: true,
    name: 'Vehicles'
  },
  {
    name: 'Insert a new vehicle',
    url: '/vehicles/add',
    iconComponent: { name: 'cib-addthis' }
  },
  {
    name: 'Edit an existing vehicle',
    url: '/vehicles/edit',
    iconComponent: { name: 'cil-pencil' }
  },
  {
    name: 'Delete an existing vehicle',
    url: '/vehicles/delete',
    iconComponent: { name: 'cil-trash' }
  },
  {
    name: 'List all vehicles',
    url: '/vehicles/list',
    iconComponent: { name: 'cil-truck' }
  },
  {
    name: 'Find a vehicle by chassi id',
    url: '/vehicles/find',
    iconComponent: { name: 'cil-search' }
  }
];
