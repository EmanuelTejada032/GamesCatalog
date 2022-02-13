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
    const formData: FormData = new FormData();
    formData.append('title', game.title);
    formData.append('description', game.description);
    formData.append('image', game.image);
    formData.append('price', game.price.toString());
    formData.append('studio', game.studio.toString());
    formData.append('releaseDate', game.releasedate.toString());
    formData.append('status', game.status.toString());
    game.genres.forEach(( genre ) => {
      formData.append("genres", genre.toString());
    })
    game.languages.forEach(( language ) => {
      formData.append("languages", language.toString());
    })
    game.tags.forEach(( tag ) => {
      formData.append("tags", tag.toString());
    })
    // formData.append('genres', JSON.stringify(game.genres));
    // formData.append('languages', JSON.stringify(game.languages));
    // formData.append('tags', JSON.stringify(game.tags));
    formData.append('systemRequirements', game.systemRequirements);
    
    return this.http.post<any>(APIURL.Games.gamePost, formData);
  }

  getGameById(gameId: number){
    return this.http.get<GameDetail>(`${APIURL.Games.gameById}${gameId}`);
  }
}
