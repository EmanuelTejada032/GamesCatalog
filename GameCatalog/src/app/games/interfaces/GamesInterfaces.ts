
export interface GameCard {
     id: number;
     title: string;
     image: string;
     price: number;
     releaseDate: string;
     studio: string;
     totalItems?: number;
     startLine?: number;
     lastLine?: number;
}

export interface GamePost {
     title: string;
     image: File;
     description: string;
     price: number;
     studio: number;
     releasedate: Date;
     genres: number[];
     languages: number[];
     tags: number[];
     status: number;
     systemRequirements: string;
}

export interface ImageFile {
     name: string;
     size: string;
     type: string;
}


export interface GameDetail {
     id:                      number;         
     title :                  string;
     image:                   string;
     description :            string;
     Price:                   number;
     studioName :             string;
     releaseDate:             string;
     genres :                 string[];
     languages:               string[];
     tags :                   string[];
     status:                  string;
     systemRequirements :     string;
}

export interface CatalogItem {
     id: number;
     name: string;
     description: string;
}

export interface CatalogItemCheckOption {
     id: number;
     name: string;
     selected: boolean;
}

export interface Pagination {
     id?: string;
     itemsPerPage: number;
     currentPage: number;
     totalItems?: number;
     searchTerm?: string;
     startLine?: number;
     lastLine?: number;
}

