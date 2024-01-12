import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BaseCrudService<Type> {
  constructor(
    public httpClient: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {}

  get(id?: number): Observable<Type[]> {
    return this.httpClient.get<Type[]>(this.baseUrl);
  }

  post(model: Type): Observable<Type> {
    return this.httpClient.post<Type>(this.baseUrl, model);
  }

  // put()

  // delete()
}
