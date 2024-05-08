import { Component, OnInit, AfterViewInit  } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-wisdom',
  standalone: true,
  imports: [],
  templateUrl: './wisdom.component.html',
  styleUrl: './wisdom.component.css'
})
export class WisdomComponent  {
  advice = '';

  constructor(private http: HttpClient) {}

  ngOnInit() {
  
  }

  
}
