import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http"
import { GameCard, GamePost, Pagination, GameDetail } from '../interfaces/GamesInterfaces';
import { APIURL } from '../../shared/apiUrls';

@Injectable({
  providedIn: 'root'
})
export class GamesService {

  constructor(private http: HttpClient) { }

  getGamesList(paginationData: Pagination){
    return this.http.get<GameCard[]>(APIURL.Games.gameList +
      `?PageIndex=${paginationData.currentPage}&PageSize=${paginationData.itemsPerPage}&SearchTerm=${paginationData.searchTerm}`);
  }

  gamePost(game: GamePost){
    return this.http.post<GameCard[]>(APIURL.Games.gamePost, game);
  }

  getGameById(gameId: number){
    return this.http.get<GameDetail>(`${APIURL.Games.gameById}${gameId}`);
  }
}
