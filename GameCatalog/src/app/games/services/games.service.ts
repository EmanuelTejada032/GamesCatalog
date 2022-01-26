import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http"
import { GameCard } from '../interfaces/GamesInterfaces';

@Injectable({
  providedIn: 'root'
})
export class GamesService {

  constructor(private http: HttpClient) { }

  getGamesList(){
    return this.http.get<GameCard[]>('https://localhost:44303/api/Games/GameList');
  }
}
