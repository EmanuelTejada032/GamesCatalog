import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {NgxPaginationModule} from 'ngx-pagination';

import { GamesRoutingModule } from './games-routing.module';
import { GameListComponent } from './pages/game-list/game-list.component';
import { GameDetailsComponent } from './pages/game-details/game-details.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { CarrouselComponent } from './components/carrousel/carrousel.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { NewGameComponent } from './pages/new-game/new-game.component';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [
    GameListComponent,
    GameDetailsComponent,
    HomepageComponent,
    CarrouselComponent,
    SearchBarComponent,
    NewGameComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    GamesRoutingModule,
    ReactiveFormsModule,
    NgxPaginationModule
  ]
})
export class GamesModule { }
