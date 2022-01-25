import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-carrousel',
  templateUrl: './carrousel.component.html',
  styles: [
    `
    .carousel-item,
    .carousel.slide{
      height: 600px;
      
    }

    img {
      object-fit: center;
    }

    `
  ]
})
export class CarrouselComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
