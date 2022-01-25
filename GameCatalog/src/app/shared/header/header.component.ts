import { Component, OnInit } from '@angular/core';

interface navItem {
  path: string;
  text: string;
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: [
  ]
})
export class HeaderComponent implements OnInit {

  navigationItems: navItem[] = [
    {
      path: 'games/homepage',
      text: 'Home'
    },
    {
      path: 'games/gamelist',
      text: 'Games List'
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
