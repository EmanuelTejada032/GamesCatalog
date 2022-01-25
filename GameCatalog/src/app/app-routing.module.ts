import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'games',
    loadChildren: () => import('./games/games.module').then(module => module.GamesModule)
  },
  {
    path:'**',
    redirectTo: 'games'
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class AppRoutingModule { }
