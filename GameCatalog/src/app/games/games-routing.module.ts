import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GameDetailsComponent } from './pages/game-details/game-details.component';
import { GameListComponent } from './pages/game-list/game-list.component';
import { HomepageComponent } from './pages/homepage/homepage.component';

const routes: Routes = [
  {
    path:'',
    children: [
      {
      path: 'homepage',
        component: HomepageComponent
      },
      {
      path: 'gamelist',
        component: GameListComponent
      },
      {
      path: 'gamelist/:id',
        component: GameDetailsComponent
      },
      {
        path: '**',
        redirectTo: 'homepage'
      }
    ]
  }
];

@NgModule({
 
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GamesRoutingModule { }
