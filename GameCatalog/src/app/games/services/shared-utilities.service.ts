import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CatalogItem } from '../interfaces/GamesInterfaces';
import { APIURL } from 'src/app/shared/apiUrls';

@Injectable({
  providedIn: 'root'
})
export class SharedUtilitiesService {

  constructor(private http: HttpClient) { }


  GetGameGenresCatalog(){
    return this.http.get<CatalogItem[]>(APIURL.SharedUtilities.gamesGenresCata);
  }
  GetGameTagsCatalog(){
    return this.http.get<CatalogItem[]>(APIURL.SharedUtilities.gamesTagsCata);
  }
  GetLanguagesCatalog(){
    return this.http.get<CatalogItem[]>(APIURL.SharedUtilities.languagesCata);
  }
  

}
