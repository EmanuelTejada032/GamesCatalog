import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GameDetailsComponent } from './pages/game-details/game-details.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { NewGameComponent } from './pages/new-game/new-game.component';

const routes: Routes = [
  {
    path:'',
    children: [
      {
      path: 'homepage',
        component: HomepageComponent
      },
      {
        path: 'newGame',
        component: NewGameComponent
      },

      {
      path: ':id',
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
