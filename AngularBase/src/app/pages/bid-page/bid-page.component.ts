import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-bid-page',
  templateUrl: './bid-page.component.html',
  styleUrls: ['./bid-page.component.css']
})
export class BidPageComponent implements OnInit {

  productId: number | undefined;
  product: Product | undefined;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
  ) {}

  async ngOnInit(): Promise<void> {
    this.productId = parseInt(this.route.snapshot.paramMap.get('id')!, 10);

    if (this.productId) {
      this.product = await this.productService.getProductById(this.productId);
    }
  }
}
