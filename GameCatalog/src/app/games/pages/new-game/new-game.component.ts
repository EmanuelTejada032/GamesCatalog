import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-new-game',
  templateUrl: './new-game.component.html',
  styles: [
  ]
})
export class NewGameComponent implements OnInit {


  newGameForm: FormGroup = this.formBuilder.group({
     title: ["", Validators.required],
     description: ["", Validators.required],
     price:  [,[ Validators.required, Validators.min(0)]],
     studio: [,[ Validators.required, Validators.min(0)]],
     releasedate: [Date.now(),[ Validators.required, Validators.min(0)]],
     genres:  [,[ Validators.required, Validators.min(0)]],
     languages:  [,[ Validators.required, Validators.min(0)]],
     tags:  [,[ Validators.required, Validators.min(0)]],
     status:  [,[ Validators.required, Validators.min(0)]],
     systemRequirements: ["", Validators.required]
  })

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }


  sendGameData(){
    console.log(this.newGameForm.value);
    
  }
}
