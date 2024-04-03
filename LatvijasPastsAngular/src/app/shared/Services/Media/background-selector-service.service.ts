import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BackgroundSelectorServiceService {
  selectedBackgroundUrl: string = '';
  backgroundUrl: string[] = [
    'https://www.bootdey.com/image/340x120/FFB6C1/000000',
    'https://www.bootdey.com/image/340x120/87CEFA/000000',
    'https://www.bootdey.com/image/340x120/20B2AA/000000',
    'https://www.bootdey.com/image/340x120/FFA07A/000000',
    'https://www.bootdey.com/image/340x120/7B68EE/000000',
    'https://www.bootdey.com/image/340x120/BA55D3/000000',
    'https://www.bootdey.com/image/340x120/FF4500/000000',
    'https://www.bootdey.com/image/340x120/191970/000000',
    'https://www.bootdey.com/image/340x120/DDA0DD/000000',
    'https://www.bootdey.com/image/340x120/DB7093/000000',
    'https://www.bootdey.com/image/340x120/663399/000000',
    'https://www.bootdey.com/image/340x120/FF8C00/000000'
  ];

  private selectedBackgroundSource = new BehaviorSubject<string>('');
  selectedBackground$ = this.selectedBackgroundSource.asObservable();

  constructor() { }

  setSelectedBackground(backgroungUrl: string) {
    this.selectedBackgroundSource.next(backgroungUrl);
  }
}
