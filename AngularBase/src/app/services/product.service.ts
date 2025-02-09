import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:7777/api/Bape';
  private authUrl = 'https://localhost:7777/api/users/login';
  private token: string = '';

  constructor() {}

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
        if (data && data.result && data.result.token) {
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
    console.log(token)
    this.token = token;
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
        console.log('Response from getAllProducts:', data);  // Log para ver la respuesta
        observer.next(data);
      })
      .catch(error => {
        console.error('Error in getAllProducts:', error);  // Log de error si algo falla
        observer.error(error);
      });
    });
  }
  

  getProductById(id: number): Observable<Product> {
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
      'Authorization': `Bearer ${this.token}`,
      'Content-Type': 'application/json',
    };
  }
}
