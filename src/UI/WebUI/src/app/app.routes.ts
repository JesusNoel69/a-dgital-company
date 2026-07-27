import { Routes } from '@angular/router';
import { PageLayout } from './layout/page-layout/page-layout';
import { Badge } from './shared/components/badge/badge';
import { Login } from './features/auth/pages/login/login';

export const routes: Routes = [
  {
    path: '',
    component: PageLayout,
    children: [{ path: 'dashboard/badge', component: Badge }],
  },
  { path: 'badge', component: Badge },
  { path: '', component: PageLayout },
  { path: 'login', component: Login },
  //  { path: '**', component: NotFoundComponent }, //
];
