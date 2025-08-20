import { Pipe, PipeTransform } from '@angular/core';
import { formatDate } from '@angular/common';

@Pipe({
  name: 'createDate',
  standalone: true
})
export class CreateDatePipe implements PipeTransform {

  transform(value: string | Date): string {
    const date = new Date(value);
    return formatDate(date, 'yyyy-MM-dd HH:mm:ss', 'en-US');
  }

}
