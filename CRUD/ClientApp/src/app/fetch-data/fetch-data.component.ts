import { Component, Inject } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public productList: Array<any> = [];
  private myAppUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(this);
    this.myAppUrl = baseUrl;
    this.getProductList();

  }

  getProductList() {
    let self = this;
    this.http.get(environment.baseUrl + 'Products/')
      .subscribe((res : any) => {self.productList = res;
      });
    console.log(self.productList)
  }

  delete(productId: number, code: string) {
    if (confirm("Do you want to delete Product with Code: " + code)) {
      let self = this;
      let headers = new Headers();
      let httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json; charset=utf-8'
        })
      }
      headers.append('Content-Type', 'application/json; charset=utf-8');
      this.http.delete(environment.baseUrl + "Products/" + productId, httpOptions)
        .subscribe((res: any) => {
          self.getProductList();

        });
    }
}}
