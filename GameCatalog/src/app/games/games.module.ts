import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GamesRoutingModule } from './games-routing.module';
import { GameListComponent } from './pages/game-list/game-list.component';
import { GameDetailsComponent } from './pages/game-details/game-details.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { CarrouselComponent } from './components/carrousel/carrousel.component';


@NgModule({
  declarations: [
    GameListComponent,
    GameDetailsComponent,
    HomepageComponent,
    CarrouselComponent
  ],
  imports: [
    CommonModule,
    GamesRoutingModule
  ]
})
export class GamesModule { }
