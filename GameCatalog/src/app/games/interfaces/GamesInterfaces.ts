
export interface GameCard {
     id:            number;
     title:         string;
     price:         number;
     releaseDate:   string;
     studio:        string;
}

export interface GamePost {
     title:              string;
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