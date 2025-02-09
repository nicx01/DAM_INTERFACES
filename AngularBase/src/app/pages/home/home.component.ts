import { Component, OnInit } from '@angular/core';
import { ProductComponent } from '../../components/product/product.component';
import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-home',
  imports: [CommonModule, ProductComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  productList: Product[] = [];
  filteredProductList: Product[] = [];
  errorMessage: string = '';

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.login('nico', 'Nico1234!')
      .subscribe(
        (response: any) => {
          this.loadProducts(); 
        },
        (error) => {
          this.errorMessage = 'Login failed';
          console.error('Login error:', error); 
        }
      );
  }
  

  loadProducts(): void {
    this.productService.getAllProducts()
      .subscribe(
        (data: Product[]) => {
          this.productList = data;
          this.filteredProductList = data;
        },
        (error) => {
          this.errorMessage = 'Failed to load products';
        }
      );
  }

  filterResults(text: string) {
    if (!text) {
      this.filteredProductList = this.productList;
      return;
    }
    this.filteredProductList = this.productList.filter((product) =>
      product?.name.toLowerCase().includes(text.toLowerCase())
    );
  }
}
