import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AvatarSelectorService {
  selectedAvatarUrl: string = '';
  avatarUrls: string[] = [
    'https://bootdey.com/img/Content/avatar/avatar1.png',
    'https://bootdey.com/img/Content/avatar/avatar2.png',
    'https://bootdey.com/img/Content/avatar/avatar3.png',
    'https://bootdey.com/img/Content/avatar/avatar4.png'
  ];
  private selectedAvatarSource = new BehaviorSubject<string>('');
  selectedAvatar$ = this.selectedAvatarSource.asObservable();
  
  constructor() { }

  setSelectedAvatar(avatarUrl: string) {
    this.selectedAvatarSource.next(avatarUrl);
  }
}
