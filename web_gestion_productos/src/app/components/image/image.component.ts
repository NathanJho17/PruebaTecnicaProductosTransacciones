import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-image',
  standalone: true,
  imports: [],
  templateUrl: './image.component.html',
  styleUrl: './image.component.css'
})
export class ImageComponent implements OnInit {
   @Input() urlImage: string = '';
  availableFormats = [".jpg", ".png", ".jpeg"];
  imageUrl: string = '';

  ngOnInit(): void {

    const isValid = this.availableFormats.some(format => this.urlImage.toLowerCase().endsWith(format));
    this.validateImageFromUrl(isValid);
  }

  validateImageFromUrl(isValid: boolean) {
    if (this.urlImage.startsWith("http") && isValid) {
      this.imageUrl = this.urlImage;
    } else {
      this.imageUrl = 'assets/Image-not-found.png';
    }
  }


}
