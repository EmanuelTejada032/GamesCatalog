import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GamesRoutingModule } from './games-routing.module';
import { GameListComponent } from './pages/game-list/game-list.component';
import { GameDetailsComponent } from './pages/game-details/game-details.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { CarrouselComponent } from './components/carrousel/carrousel.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';


@NgModule({
  declarations: [
    GameListComponent,
    GameDetailsComponent,
    HomepageComponent,
    CarrouselComponent,
    SearchBarComponent
  ],
  imports: [
    CommonModule,
    GamesRoutingModule
  ]
})
export class GamesModule { }
