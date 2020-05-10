import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { LoginAuthGuard } from './_guards/loginAuth.guard';
import { LoginComponent } from './login/login.component';
import { TokenInterceptor } from './_interceptors/TokenInterceptor';
import { StorageService } from './_services/storage.service';
import { UsersService } from './_services/users.service';
import { QuizComponent } from './quiz/quiz.component';
import { QuizService } from './_services/quiz.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    QuizComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate: [LoginAuthGuard] },
      { path: 'quiz/:id', component: QuizComponent, canActivate: [LoginAuthGuard] },
      { path: 'counter', component: CounterComponent, canActivate: [LoginAuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: '**', component: HomeComponent, canActivate: [LoginAuthGuard] },
    ])
  ],
  providers: [
    LoginAuthGuard,
    TokenInterceptor,
    StorageService,
    UsersService,
    QuizService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
