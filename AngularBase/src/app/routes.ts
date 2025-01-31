import { Routes } from '@angular/router';
import { HomeComponent } from '../app/pages/home/home.component';
import { DetailsComponent } from '../app/pages/details/details.component';
import { BidPageComponent } from '../app/pages/bid-page/bid-page.component'; // Importar el nuevo componente
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';

const routeConfig: Routes = [
  {
    path: '',
    component: HomeComponent,
    title: 'Home page',
  },
  {
    path: 'details/:id',
    component: DetailsComponent,
    title: 'Home details',
  },
  {
    path: 'bid/:id',
    component: BidPageComponent,
    title: 'Bid Page',
  },
  {
    path: '**',
    component: PageNotFoundComponent,
  },
];

export default routeConfig;
