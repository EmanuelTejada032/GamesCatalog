import { Component, OnInit } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GamesService } from '../../services/games.service';
import { SharedUtilitiesService } from '../../services/shared-utilities.service';
import { GamePost, CatalogItem } from '../../interfaces/GamesInterfaces';
import {Router} from '@angular/router';

@Component({
  selector: 'app-new-game',
  templateUrl: './new-game.component.html',
  styles: [
  ]
})
export class NewGameComponent implements OnInit {

  genresCatalog: CatalogItem[] = [];
  tagsCatalog: CatalogItem[] = [];
  languagesCatalog: CatalogItem[] = [];

  selectedGenres: number[] = [];
  selectedTags: number[] = [];
  selectedLanguages: number[] = [];

  newGameForm: FormGroup = this.formBuilder.group({
     title: ["", Validators.required],
     description: ["", Validators.required],
     image: [, Validators.required],
     price:  [1.99,[ Validators.required, Validators.min(0)]],
     releasedate: ['2022-01-11',[ Validators.required, Validators.min(0)]],
     genres: [, Validators.required],
     languages: [, Validators.required],
     tags:[, Validators.required],
     systemRequirements: ["", Validators.required]
  })

  constructor(private formBuilder: FormBuilder, 
              private gamesServices: GamesService,
              private sharedUtilitiesService:SharedUtilitiesService,
              private router: Router) { }

  ngOnInit(): void {
    this.loadCatalogs();
  }


  sendGameData(){

    const game: GamePost = this.formatFormData();

    this.resetNewGameForm();
    this.gamesServices.gamePost(game)
    .subscribe( postResponse => {
      console.log("post response", postResponse);
      this.resetNewGameForm();
      this.router.navigateByUrl('/homepage');
    })
  }

  onGenresCheckBoxChange(event: any){
    const genreId = Number(event.target.value);
    if(!this.selectedGenres.includes(genreId)){  
      this.selectedGenres.push(genreId);           
    }else{
      this.selectedGenres.splice(this.selectedGenres.indexOf(genreId), 1); 
    }
  }

  onLanguagesCheckBoxChange(event: any){
    const languagesId = Number(event.target.value);
    if(!this.selectedLanguages.includes(languagesId)){  
      this.selectedLanguages.push(languagesId);           
    }else{
      this.selectedLanguages.splice(this.selectedLanguages.indexOf(languagesId), 1); 
    }
  }
  onTagsCheckboxChange(event: any){
    const tagId = Number(event.target.value);
    if(!this.selectedTags.includes(tagId)){  
      this.selectedTags.push(tagId);           
    }else{
      this.selectedTags.splice(this.selectedTags.indexOf(tagId), 1); 
    }
  }

  resetNewGameForm(){
    this.newGameForm.reset({
      releasedate: '2022-01-11',
      status: 5
    });
    this.selectedGenres = [];
    this.selectedTags = [];
    this.selectedLanguages = [];
  }

  loadCatalogs(){
    this.GetGameGenresCatalog();
    this.GetGameTagsCatalog();
    this.GetLanguageCatalog();
  }

  formatFormData(){
    return {
      ...this.newGameForm.value,
      status: 5,
      studio: 1,
      genres: this.selectedGenres ,
      languages: this.selectedLanguages ,
      tags: this.selectedTags 
    }
  }

  GetGameGenresCatalog(){
    this.sharedUtilitiesService.GetGameGenresCatalog()
    .subscribe( response => {
      this.genresCatalog = response;
    })
  }
  GetGameTagsCatalog(){
    this.sharedUtilitiesService.GetGameTagsCatalog()
    .subscribe( response => {
      this.tagsCatalog = response;
    })
  }
  GetLanguageCatalog(){
    this.sharedUtilitiesService.GetLanguagesCatalog()
    .subscribe( response => {
      this.languagesCatalog = response;
    })
  }

  
}
