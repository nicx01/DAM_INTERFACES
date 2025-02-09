import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';  // Importar Router
import { Product } from 'src/app/models/product'; 
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
  router: Router = inject(Router); 
  product: Product | undefined;

  productService: ProductService = inject(ProductService);

  constructor() {
    const productId = parseInt(this.route.snapshot.params['id'], 10);

    this.productService.getProductById(productId).subscribe(
      (product: Product) => {
        this.product = product;  
      },
      (error) => {
        console.error('Error al obtener el producto:', error);
      }
    );
  }

  navigateToBidPage() {
    if (this.product?.id) {
      this.router.navigate([`/bid/${this.product.id}`]);
    }
  }
}
