import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/Services/user.service';
import { isConstructorDeclaration } from 'typescript';

@Injectable({
  providedIn: 'root'
})

export class PageGuard implements CanActivate {
  constructor(private router: Router, private service: UserService){

  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
      if(localStorage.getItem('token')!=null)
      {
        let roles = next.data['permittedRoles'] as Array<string>;
        if(roles)
        {
          if(this.service.roleMatch(roles)) return true;
          else 
          {
            this.router.navigate(['/home']);
            return false;
          }
        }
        return true;
      }
      else 
      { 
        this.router.navigate(['/login']);
        return false;
      }
  }
}
