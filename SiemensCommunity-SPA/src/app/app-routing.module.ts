import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BorrowedProductsPageComponent } from './Pages/borrowed-products-page/borrowed-products-page.component';
import { ForgotPasswordComponent } from './Pages/forgot-password/forgot-password.component';
import { HomePageComponent } from './Pages/home-page/home-page.component';
import { LentProductsPageComponent } from './Pages/lent-products-page/lent-products-page.component';
import { LoginPageComponent } from './Pages/login-page/login-page.component';
import { MycatalogPageComponent } from './Pages/mycatalog-page/mycatalog-page.component';
import { RegisterPageComponent } from './Pages/register-page/register-page.component';
import { ResetPasswordComponent } from './Pages/reset-password/reset-password.component';
import { WelcomePageComponent } from './Pages/welcome-page/welcome-page.component';

const routes: Routes = [
  {path: '',component: WelcomePageComponent},
  {path: 'register', component: RegisterPageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'home', component: HomePageComponent},
  {path: 'lent', component: LentProductsPageComponent},
  {path: 'borrowed', component: BorrowedProductsPageComponent},
  {path: 'mycatalog', component: MycatalogPageComponent},
  {path: 'forgotpassword', component: ForgotPasswordComponent},
  {path: 'resetpassword', component: ResetPasswordComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
