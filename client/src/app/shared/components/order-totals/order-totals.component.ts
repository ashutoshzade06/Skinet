import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket, IBasketTotals } from '../../models/basket';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent implements OnInit {

  // basketTotal$!: Observable<IBasketTotals>;

  @Input() shippingPrice:number=0;
  @Input() subtotal:number=0;
  @Input() total:number=0;

  constructor() { }

  ngOnInit() {
    // this.basketTotal$=this.basketService.basketTotal$;
  }

}
