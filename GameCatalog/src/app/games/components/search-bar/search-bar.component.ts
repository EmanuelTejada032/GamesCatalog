import { Component, OnInit, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styles: [
  ]
})
export class SearchBarComponent implements OnInit {

  @Output() onSearch: EventEmitter<string> = new EventEmitter()
  searchTerm: string = "";

  constructor() { }

  ngOnInit(): void {
  }

  search(){
    this.onSearch.emit(this.searchTerm);
  }

}
