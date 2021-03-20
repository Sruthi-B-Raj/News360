import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FavouriteComponent } from './favourite/favourite.component';
import { HeaderComponent } from './header/header.component';
import { NewsComponent } from './news/news.component';
import { RecommendComponent } from './recommend/recommend.component';
import { SearchComponent } from './search/search.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';


const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'news', component: NewsComponent, canActivate: [AuthGuard] },
  { path: 'favourite', component: FavouriteComponent, canActivate: [AuthGuard] },
  { path: 'search', component: SearchComponent },
  { path: 'recommend', component: RecommendComponent, canActivate: [AuthGuard] },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }


    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
