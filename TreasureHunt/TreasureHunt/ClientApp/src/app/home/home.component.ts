import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Quiz } from '../_models/Quiz';
import { QuizService } from '../_services/quiz.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  quizzes: Array<Quiz> = [];
  constructor(
    private quizService: QuizService,
    private router: Router) {

    this.initialize();
  }

  async initialize() {
    try {
      this.quizzes = await this.quizService.getActiveQuizzes().toPromise();
    } catch (e) {

    }
  }

  canParticipate(quiz: Quiz) {
    const date = new Date(Date.now());
    if (quiz && new Date(quiz.startTime) < date && new Date(quiz.endTime) > date) {
      return true;
    }
  }

  participate(quizId: number) {
    this.router.navigate(['/quiz/' + quizId]);
  }
}
