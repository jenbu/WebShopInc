import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BaseCrudService {
  constructor(
    public httpClient: HttpClient,
    @Inject('BASE_URL') public baseUrl: string
  ) {
    console.log(baseUrl);
  }

  get(id?: number): Observable<any> {
    return this.httpClient.get<any[]>(this.baseUrl);
  }

  // post()

  // put()

  // delete()
}
