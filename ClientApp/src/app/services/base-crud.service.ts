import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/ApiResponse';

import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root',
})
export class BaseCrudService<T> {
    baseUrl: string;

    constructor(
        public httpClient: HttpClient,
        @Inject('BASE_URL') public endpointExtension: string
    ) {
        this.baseUrl = environment.apiUrl + '/' + endpointExtension;
    }

    get(id?: number): Observable<ApiResponse<T[]>> {
        let url = this.baseUrl;

        if (id) {
            url = url + `/${id}`;
        }

        return this.httpClient.get<ApiResponse<T[]>>(url);
    }

    post(model: T): Observable<ApiResponse<T>> {
        return this.httpClient.post<ApiResponse<T>>(this.baseUrl, model);
    }

    put(model: T): Observable<ApiResponse<T>> {
        return this.httpClient.put<ApiResponse<T>>(this.baseUrl, model);
    }

    delete(id?: number): Observable<any> {
        return this.httpClient.delete(`${this.baseUrl}/${id}`);
    }
}
