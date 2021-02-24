import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gmap',
  templateUrl: './gmap.component.html',
  styleUrls: ['./gmap.component.css']
})
export class GmapComponent implements OnInit {

  title = 'Gmap in my application';
  lat = 12.9716;
  lng = 77.5946;
  constructor() { }

  ngOnInit(): void {

  }

}
