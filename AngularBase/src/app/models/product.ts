export interface Product {
    id: number;
    name: string;
    startingPrice: number;
    marketPrice: number;
    releaseDate: Date;
    imageUrl: string;
    description: string;
    isAuctionOpen: boolean;
    endDate: Date;
  }