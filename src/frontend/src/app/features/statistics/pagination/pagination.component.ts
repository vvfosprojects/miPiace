import { Component, EventEmitter, Output } from '@angular/core';

@Component({
    selector: 'app-pagination',
    templateUrl: './pagination.component.html',
    styleUrls: ['./pagination.component.css'],
})
export class PaginationComponent {

    @Output() pageChange = new EventEmitter<number>();

}
