import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { TitleComponent } from './title/title.component';
import { SortByComponent } from './sort-by/sort-by.component';
import { PortalModule } from '@angular/cdk/portal';
import { OverlayModule } from '@angular/cdk/overlay';



@NgModule({
  declarations: [
    HeaderComponent,
    TitleComponent,
    SortByComponent
  ],
  imports: [
    CommonModule,
    PortalModule,
    OverlayModule
  ],
  exports: [
    HeaderComponent,
    TitleComponent,
    SortByComponent,
    PortalModule,
    OverlayModule
  ]
})
export class SharedModule { }
