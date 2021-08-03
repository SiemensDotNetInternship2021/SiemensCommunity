import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './Pages/login-page/login-page.component';
import { RegisterPageComponent } from './Pages/register-page/register-page.component';
import { WelcomePageComponent } from './Pages/welcome-page/welcome-page.component';
import { AbstractControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomePageComponent } from './Pages/home-page/home-page.component';
import { NavBarComponent } from './Shared/nav-bar/nav-bar.component';
import { MycatalogPageComponent } from './Pages/mycatalog-page/mycatalog-page.component';
import { BorrowedProductsPageComponent } from './Pages/borrowed-products-page/borrowed-products-page.component';
import { LentProductsPageComponent } from './Pages/lent-products-page/lent-products-page.component';
import { ForgotPasswordComponent } from './Pages/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './Pages/reset-password/reset-password.component';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AddProductComponent } from './Pages/add-product/add-product.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AdminPanelComponent } from './Pages/admin-panel/admin-panel.component';

import { MatCheckboxModule } from '@angular/material/checkbox';
import { NgxStarRatingModule } from 'ngx-star-rating';


@NgModule({
  declarations: [
    AppComponent,
    WelcomePageComponent,
    RegisterPageComponent,
    LoginPageComponent,
    HomePageComponent,
    NavBarComponent,
    MycatalogPageComponent,
    BorrowedProductsPageComponent,
    LentProductsPageComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
        AddProductComponent,
        AdminPanelComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgxPaginationModule,
    MatDialogModule,
    MatIconModule,
    NgbModule,
    ToastrModule.forRoot(),
    MatCheckboxModule,
    NgxStarRatingModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

