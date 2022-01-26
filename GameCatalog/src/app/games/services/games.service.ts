import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http"
import { GameCard, GamePost } from '../interfaces/GamesInterfaces';
import { APIURL } from '../../shared/apiUrls';

@Injectable({
  providedIn: 'root'
})
export class GamesService {

  constructor(private http: HttpClient) { }

  getGamesList(){
    return this.http.get<GameCard[]>(APIURL.Games.gameList);
  }

  gamePost(game: GamePost){
    return this.http.post<GameCard[]>(APIURL.Games.gamePost, game);
  }




}
