import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-bid-page',
  standalone: true, 
  templateUrl: './bid-page.component.html',
  styleUrls: ['./bid-page.component.css'],
  imports: [FormsModule] 
})
export class BidPageComponent implements OnInit {
  productId: number | undefined;
  product: Product | undefined;
  bidAmount: number = 0.0;
  highestBid: number=0.0;

  private route = inject(ActivatedRoute);
  private productService = inject(ProductService);

  ngOnInit(): void {
    this.productId = parseInt(this.route.snapshot.paramMap.get('id')!, 10);

    if (this.productId) {
      this.productService.getProductById(this.productId).subscribe(
        (product: Product) => {
          this.product = product;
          this.bidAmount = this.product.resellPrice;
          this.loadHighestBid();
        },
        (error) => {
          console.error('Error al obtener el producto:', error);
        }
      );
    }
  }
  loadHighestBid(): void {
    if (this.productId) {
      this.productService.getHighestBidForProduct(this.productId).subscribe(
        (highestBid) => {
            this.highestBid = highestBid.price;
        },
        (error) => {
          console.error('Error al obtener la puja más alta:', error);
        }
      );
    }
  }
  submitBid(event: Event): void {
    event.preventDefault(); 
    console.log(this.bidAmount, this.highestBid)
    if (!this.productId || !this.product || this.bidAmount <= this.product.resellPrice || this.bidAmount <= this.highestBid) {
      alert('Introduce una cantidad válida para pujar.');
      return;
    }

    const bidData = {
      price: this.bidAmount,
      productId: this.productId
    };

    this.productService.placeBid(bidData).subscribe(
      () => {
        alert('Puja realizada con éxito.');
        this.loadHighestBid();
      },
      (error) => {
        console.error('Error al enviar la puja:', error);
        alert('Hubo un error al realizar la puja.');
      }
    );
  }
}
