import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../services/games.service';
import { GameCard } from '../../interfaces/GamesInterfaces';

@Component({
  selector: 'app-game-list',
  templateUrl: './game-list.component.html',
  styles: [
  ]
})
export class GameListComponent implements OnInit {

  gameList: GameCard[] = [];

  constructor(private gamesService: GamesService) { }

  ngOnInit(): void {
    this.getGamesList();
  }

  getGamesList(){
    this.gamesService.getGamesList()
    .subscribe( response => {
      this.gameList = response;
    })
  }

}
