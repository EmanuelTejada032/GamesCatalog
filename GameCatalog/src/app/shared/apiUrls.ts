import { environment } from '../../environments/environment';

export let SERVER = environment.servername;

let Api = environment.api;

export let APIURL = {

  Games:{
    gameList: Api+"Games/GameList",
    gamePost: Api+"Games/GamePost",
    gameById: Api+"Games/"
  },
  SharedUtilities:{
    gamesGenresCata: Api+'SharedUtilities/GetGenresCata',
    gamesTagsCata: Api+'SharedUtilities/GetTagsCata',
    languagesCata: Api+'SharedUtilities/GetLanguagesCata',
    ratingsCata: Api+'SharedUtilities/GetRaatingsCata',
    userRolesCata: Api+'SharedUtilities/GetRolesCata'
  }

};
