import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:7777/api/Bape';
  private authUrl = 'https://localhost:7777/api/users/login';
  private pujaUrl= 'https://localhost:7777/api/Puja'
  private token: string | null = null;

  constructor() {
    // Recuperar el token desde localStorage al inicializar el servicio
    this.token = localStorage.getItem('authToken');
  }

  login(userName: string, password: string): Observable<any> {
    const credentials = { userName, password };
    return new Observable<any>(observer => {
      fetch(this.authUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(credentials)
      })
      .then(response => response.json())
      .then(data => {
        console.log('Login response:', data);
        if (data?.result?.token) {
          this.setToken(data.result.token);
        }
        observer.next(data);
      })
      .catch(error => {
        observer.error(error);
      });
    });
  }
  
  setToken(token: string): void {
    this.token = token;
    localStorage.setItem('authToken', token);
  }

  getToken(): string | null {
    return this.token || localStorage.getItem('authToken');
  }

  logout(): void {
    this.token = null;
    localStorage.removeItem('authToken');
  }

  getAllProducts(): Observable<Product[]> {
    return new Observable<Product[]>(observer => {
      const headers = this.createAuthHeaders();
      fetch(this.apiUrl, {
        method: 'GET',
        headers: headers
      })
      .then(response => response.json())
      .then(data => {
        console.log('Response from getAllProducts:', data);
        observer.next(data);
      })
      .catch(error => {
        console.error('Error in getAllProducts:', error);
        observer.error(error);
      });
    });
  }
  
  getProductById(id: number): Observable<Product> {
    console.log(id, this.token);
    return new Observable<Product>(observer => {
      const headers = this.createAuthHeaders();
      console.log(headers);
      fetch(`${this.apiUrl}/${id}`, {
        method: 'GET',
        headers: headers
      })
      .then(response => response.json())
      .then(data => {
        observer.next(data);
      })
      .catch(error => {
        observer.error(error);
      });
    });
  }

  private createAuthHeaders(): { [key: string]: string } {
    return {
      'Authorization': `Bearer ${this.getToken()}`,
      'Content-Type': 'application/json',
    };
  }
  placeBid(bidData: { price: number; productId: number }): Observable<any> {
    return new Observable<any>(observer => {
      const headers = this.createAuthHeaders();
  
      fetch(this.pujaUrl, {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(bidData)
      })
      .then(response => response.json())
      .then(data => {
        observer.next(data);
      })
      .catch(error => {
        observer.error(error);
      });
    });
  }
  
  getHighestBidForProduct(productId: number): Observable<any> {
    return new Observable<any>(observer => {
      const headers = this.createAuthHeaders();
      fetch(this.pujaUrl, {
        method: 'GET',
        headers: headers
      })
      .then(response => response.json())
      .then((bids: any[]) => {
        const filteredBids = bids.filter(bid => bid.productId === productId);
  
        if (filteredBids.length === 0) {
          observer.next(null); 
        } else {
          const highestBid = filteredBids.reduce((prev, current) => (prev.price > current.price ? prev : current));
          observer.next(highestBid);
        }
      })
      .catch(error => {
        observer.error(error);
      });
    });
  }
  
}
