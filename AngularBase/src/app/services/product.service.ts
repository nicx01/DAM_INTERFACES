import { Injectable } from '@angular/core';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  productList: Product[];

  constructor() {
    this.productList = [
      {
        id: 1,
        name: 'BAPE Shark Hoodie',
        photo: 'https://eu.bape.com/cdn/shop/files/001ZPK801001_NYE_A.jpg?v=1722620168&width=1200',
        retail_price: 500.00,
        resell_price: 700.00,
        year: 2024
      },
      {
        id: 2,
        name: 'BAPE Camo Pattern T-shirt',
        photo: 'https://eu.bape.com/cdn/shop/files/001CSK803004_GRN_A.jpg?v=1721305721&width=1200',
        retail_price: 150.00,
        resell_price: 250.00,
        year: 2023
      },
      {
        id: 3,
        name: 'BAPE Sta Sneakers',
        photo: 'https://eu.bape.com/cdn/shop/files/001FWK801303M_BLK_B.jpg?v=1732288409&width=700',
        retail_price: 200.00,
        resell_price: 300.00,
        year: 2024
      },
      {
        id: 4,
        name: 'BAPE Ape Head T-shirt',
        photo: 'https://eu.bape.com/cdn/shop/files/001TEK201001_BLK_A_1.jpg?v=1715336378&width=1200',
        retail_price: 120.00,
        resell_price: 180.00,
        year: 2024
      },
      {
        id: 5,
        name: 'BAPE Bapesta Sneakers x Kanye West',
        photo: 'https://images.stockx.com/images/A-Bathing-Ape-Bapesta-College-Dropout-Product.jpg?fit=fill&bg=FFFFFF&w=700&h=500&fm=webp&auto=compress&q=90&dpr=2&trim=color&updated_at=1738193358',
        retail_price: 220.00,
        resell_price: 350.00,
        year: 2023
      },
      {
        id: 6,
        name: 'BAPE x Adidas NMD',
        photo: 'https://images.stockx.com/images/Adidas-NMD-R1-Bape-Olive-Camo-Product.jpg?fit=fill&bg=FFFFFF&w=700&h=500&fm=webp&auto=compress&q=90&dpr=2&trim=color&updated_at=1606322837',
        retail_price: 250.00,
        resell_price: 400.00,
        year: 2024
      },
      {
        id: 7,
        name: 'BAPE x Coca-Cola Collection T-shirt',
        photo: 'https://images.stockx.com/images/BAPE-x-Coca-Cola-Ape-Head-Tee-Red.jpg?fit=fill&bg=FFFFFF&w=700&h=500&fm=webp&auto=compress&q=90&dpr=2&trim=color&updated_at=1696866085',
        retail_price: 130.00,
        resell_price: 200.00,
        year: 2023
      },
      {
        id: 8,
        name: 'BAPE x Star Wars Stormtrooper T-shirt',
        photo: 'https://images.stockx.com/images/BAPE-x-Star-Wars-Republic-Tee-White.jpg?fit=fill&bg=FFFFFF&w=700&h=500&fm=webp&auto=compress&q=90&dpr=2&trim=color&updated_at=1637706369',
        retail_price: 150.00,
        resell_price: 250.00,
        year: 2024
      },
      {
        id: 9,
        name: 'BAPE x Hello Kitty Hoodie',
        photo: 'https://eu.bape.com/cdn/shop/files/002TEK731909_WHT_A.jpg?v=1734091237&width=2400',
        retail_price: 180.00,
        resell_price: 270.00,
        year: 2024
      },
      {
        id: 10,
        name: 'BAPE x Undefeated Collaboration T-shirt',
        photo: 'https://images.stockx.com/images/Bape-x-Undefeated-Sport-Is-War-Ape-Head-Tee-Black.jpg?fit=fill&bg=FFFFFF&w=700&h=500&fm=webp&auto=compress&q=90&dpr=2&trim=color&updated_at=1614885339',
        retail_price: 160.00,
        resell_price: 220.00,
        year: 2023
      }
    ];
  }
  

  getAllProducts(): Promise<Product[]> {
    return Promise.resolve(this.productList);
  }

  getProductById(id: number): Promise<Product | undefined> {
    const product = this.productList.find(p => p.id === id);
    return Promise.resolve(product);
  }
  submitApplication(firstName: string, lastName: string, email: string) {
    console.log(
      `Application received: firstName: ${firstName}, lastName: ${lastName}, email: ${email}`
    );
  }
}
