import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/ApiResponse';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BaseCrudService<Type> {
  baseUrl: string;

  constructor(
    public httpClient: HttpClient,
    @Inject('BASE_URL') public endpointExtension: string
  ) {
    this.baseUrl = environment.apiUrl + '/' + endpointExtension;
  }

  get(id?: number): Observable<ApiResponse<Type[]>> {
    return this.httpClient.get<ApiResponse<Type[]>>(this.baseUrl);
  }

  post(model: Type): Observable<Type> {
    return this.httpClient.post<Type>(this.baseUrl, model);
  }

  // put()

  //   delete(model: Type): Observable<void> {
  //     return this.httpClient.delete(this.baseUrl, model);
  //   }
}
