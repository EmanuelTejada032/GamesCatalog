
export interface GameCard {
     id:            number;
     title:         string;
     image:         string;
     price:         number;
     releaseDate:   string;
     studio:        string;
}

export interface GamePost {
     title:              string;
     image:              string;
     description:        string;
     price:              number;
     studio:             number;
     releasedate:        Date;
     genres:             number[];
     languages:          number[];
     tags:               number[];
     status:             number;
     systemRequirements: string;
}

export interface CatalogItem{
     id: number;
     name: string;
     description: string;
} 

export interface CatalogItemCheckOption{
     id: number;
     name: string;
     selected: boolean;
} 