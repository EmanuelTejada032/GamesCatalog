import { Component, OnInit } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GamesService } from '../../services/games.service';
import { SharedUtilitiesService } from '../../services/shared-utilities.service';
import { GamePost, CatalogItem } from '../../interfaces/GamesInterfaces';
import {Router} from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';

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

  files: any = [];
  previewImage: string = "";

  newGameForm: FormGroup = this.formBuilder.group({
     title: ["", Validators.required],
     description: ["", Validators.required],
     images: [, Validators.required],
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
              private router: Router,
              private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.loadCatalogs();
  }


  sendGameData(){

    const game: GamePost = this.formatFormData();
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

  
  formatFormData(){
    return {
      ...this.newGameForm.value,
      image: this.files[0] as File,
      status: "5",
      studio: "1",
      genres: this.selectedGenres ,
      languages: this.selectedLanguages ,
      tags: this.selectedTags 
    }
  }


  captureFile(event: any){
    const incomingFiles = event.target.files[0]; 
    this.files.push(incomingFiles);
    this.extract64Base(incomingFiles).then( (files:any) => {
      console.log(files);
      this.previewImage = files.base;
    });
  }


  extract64Base = async ($event: any) => new Promise((resolve, reject) => {
    try {
      const unsafeImg = window.URL.createObjectURL($event);
      const image = this.sanitizer.bypassSecurityTrustUrl(unsafeImg);
      const reader = new FileReader();
      reader.readAsDataURL($event);
      reader.onload = () => {
        resolve({
          blob: $event,
          base: reader.result
        });
      };
      reader.onerror = error => {
        resolve({
          blob: $event,
          base: null
        });
      };

    } catch (e) {
      return resolve(null);
    }
  })
  
  
  loadCatalogs(){
    this.GetGameGenresCatalog();
    this.GetGameTagsCatalog();
    this.GetLanguageCatalog();
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
