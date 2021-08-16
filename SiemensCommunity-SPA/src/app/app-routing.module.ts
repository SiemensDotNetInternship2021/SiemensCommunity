import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './Pages/add-product/add-product.component';
import { AdminPanelComponent } from './Pages/admin-panel/admin-panel.component';
import { BorrowedProductsPageComponent } from './Pages/borrowed-products-page/borrowed-products-page.component';
import { ForgotPasswordComponent } from './Pages/forgot-password/forgot-password.component';
import { HomePageComponent } from './Pages/home-page/home-page.component';
import { LentProductsPageComponent } from './Pages/lent-products-page/lent-products-page.component';
import { LoginPageComponent } from './Pages/login-page/login-page.component';
import { LogsPageComponent } from './Pages/logs-page/logs-page.component';
import { MycatalogPageComponent } from './Pages/mycatalog-page/mycatalog-page.component';
import { RegisterPageComponent } from './Pages/register-page/register-page.component';
import { ResetPasswordComponent } from './Pages/reset-password/reset-password.component';
import { UserEditorComponent } from './Pages/user-editor/user-editor.component';
import { WelcomePageComponent } from './Pages/welcome-page/welcome-page.component';
import { PageGuard } from './Shared/page-guard/page.guard';

const routes: Routes = [
  {path: '',component: WelcomePageComponent},
  {path: 'register', component: RegisterPageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'home', component: HomePageComponent, canActivate:[PageGuard]},
  {path: 'borrowed', component: BorrowedProductsPageComponent, canActivate:[PageGuard]},
  {path: 'mycatalog', component: MycatalogPageComponent, canActivate:[PageGuard]},
  {path: 'forgotpassword', component: ForgotPasswordComponent},
  {path: 'addproduct/:id', component: AddProductComponent, canActivate: [PageGuard] },
  {path: 'logs', component: LogsPageComponent, canActivate: [PageGuard], data:{permittedRoles:['Admin']} },
  {path: 'resetpassword', component: ResetPasswordComponent},
  {path: 'addproduct', component: AddProductComponent, canActivate: [PageGuard]},
  {path: 'admin', component: AdminPanelComponent, canActivate: [PageGuard], data: {permittedRoles:['Admin']}},
  {path: 'usereditor/:userId', component: UserEditorComponent, canActivate: [PageGuard], data: {permittedRoles:['Admin']}},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
