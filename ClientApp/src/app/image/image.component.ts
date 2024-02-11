import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-image',
    templateUrl: './image.component.html',
})
export class ImageComponent {
    @Input() public set src(imageSrc: string) {
        this.source = imageSrc;
        this.loading = true;
    }

    error = false;
    loading = false;
    source: string;

    constructor() {}

    onError() {
        this.error = true;
        this.loading = false;
    }

    load() {
        this.error = false;
        this.loading = false;
    }

    imageStyle() {
        if (this.loading || this.error) {
            return 'd-none';
        }

        return 'd-inline';
    }
}
