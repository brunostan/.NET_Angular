import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [
    {
      Tema: 'Angular',
      Local: 'Belo Horizonte',
    },
    {
      Tema: '.Net',
      Local: 'São Paulo',
    },
    {
      Tema: 'Angular + .NET',
      Local: 'Rio de Janeiro',
    },
  ];

  constructor() {}

  ngOnInit() {}
}
