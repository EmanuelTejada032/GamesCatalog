import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GamesService } from '../../services/games.service';
import { GameDetail } from '../../interfaces/GamesInterfaces';

@Component({
  selector: 'app-game-details',
  templateUrl: './game-details.component.html',
  styles: [
  ]
})
export class GameDetailsComponent implements OnInit {

  gameId: number = 28;
  game!: GameDetail;
  constructor(private route: ActivatedRoute,private gameService: GamesService ) { }

  ngOnInit(): void {
    this.route.params.subscribe(({id}) => {
      console.log(id);
      
      this.gameId = id;
    }
    )
    this.getGameById();
  }

  getGameById(){
    this.gameService.getGameById(this.gameId)
    .subscribe( game => {
      console.log(game);
      
      this.game = game;
    })
  }

  

}
