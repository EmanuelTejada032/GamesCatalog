import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../services/games.service';
import { GameCard, Pagination } from '../../interfaces/GamesInterfaces';

@Component({
  selector: 'app-game-list',
  templateUrl: './game-list.component.html',
  styles: [
  ]
})
export class GameListComponent implements OnInit {

  gameList: GameCard[] = [];
  previousSearchTerm: string = "";
  totalItems: number = 0;

  isResponsive: boolean = true;
  maxSize: number = 9;

  paginationData: Pagination = {
    currentPage:   1,
    itemsPerPage:  12,
    searchTerm:"",
    totalItems: 0,
    lastLine: 0,
    startLine: 0
  };

  constructor(private gamesService: GamesService) { }

  ngOnInit(): void {
    this.getGamesList();
  }

  search(searchTerm: string){
    this.paginationData.searchTerm = searchTerm;
    if(searchTerm != this.previousSearchTerm){
      this.getGamesList();
      this.previousSearchTerm = this.paginationData.searchTerm;
    }
  }

  getGamesList(){    
    this.gamesService.getGamesList(this.paginationData)
    .subscribe( response => {
      this.gameList = response;
      this.paginationData.startLine = this.gameList[0].startLine
      this.paginationData.lastLine = this.gameList[0].lastLine
      this.paginationData.totalItems = this.gameList[0].totalItems
    })
  }


  pageChanged(newPage: number){
    this.paginationData.currentPage = newPage;
    this.getGamesList();
  }


}
