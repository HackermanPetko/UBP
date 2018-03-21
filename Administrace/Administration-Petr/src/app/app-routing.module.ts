import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent } from './login-form/login-form.component';
import { AdminComponent } from './admin/admin.component';
import { PlaygroundComponent } from './playground/playground.component';
import { ApiTestComponent} from './apitest/apitest.component'

const routes: Routes = [
  {   path: '',
      component: LoginFormComponent,
  },
  {   path: 'admin',
      component: AdminComponent
  },
  {
    path: 'playground',
    component: PlaygroundComponent
  },
  {
    path: 'apitest',
    component: ApiTestComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

