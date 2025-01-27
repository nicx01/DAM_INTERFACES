import { Injectable } from '@angular/core';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  productList: Product[];
  readonly baseUrl = 'https://example.com/assets/images/products';

  constructor() {
    this.productList = [
      {
        id: 0,
        name: 'Shark Hoodie',
        startingPrice: 200,
        marketPrice: 500,
        releaseDate: new Date('2023-01-15'),
        imageUrl: `${this.baseUrl}/shark-hoodie.jpg`,
        description: 'An iconic hoodie with a shark design.',
        isAuctionOpen: true,
        endDate: new Date('2025-02-01T18:00:00'),
      },
      {
        id: 1,
        name: 'BAPESTA Sneakers',
        startingPrice: 150,
        marketPrice: 400,
        releaseDate: new Date('2023-02-10'),
        imageUrl: `${this.baseUrl}/bapesta-sneakers.jpg`,
        description: 'Legendary sneakers inspired by Air Force 1.',
        isAuctionOpen: true,
        endDate: new Date('2025-02-03T20:00:00'),
      },
      {
        id: 2,
        name: 'Human Made T-Shirt',
        startingPrice: 50,
        marketPrice: 120,
        releaseDate: new Date('2023-03-20'),
        imageUrl: `${this.baseUrl}/human-made-tshirt.jpg`,
        description: 'A timeless t-shirt with a vintage design.',
        isAuctionOpen: true,
        endDate: new Date('2025-02-05T15:00:00'),
      },
      {
        id: 3,
        name: 'LV² Monogram Bag',
        startingPrice: 800,
        marketPrice: 1500,
        releaseDate: new Date('2023-05-01'),
        imageUrl: `${this.baseUrl}/lv2-monogram-bag.jpg`,
        description: 'A luxury bag from the LV² collaboration.',
        isAuctionOpen: false,
        endDate: new Date('2025-01-25T10:00:00'),
      },
      {
        id: 4,
        name: 'Human Made Coffee Mug',
        startingPrice: 20,
        marketPrice: 50,
        releaseDate: new Date('2023-07-18'),
        imageUrl: `${this.baseUrl}/human-made-mug.jpg`,
        description: 'A ceramic mug with a vintage style.',
        isAuctionOpen: true,
        endDate: new Date('2025-02-07T09:00:00'),
      }
    ];
  }

  getAllProducts(): Product[] {
    return this.productList;
  }

  getProductById(id: number): Product | undefined {
    return this.productList.find((product) => product.id === id);
  }
}
