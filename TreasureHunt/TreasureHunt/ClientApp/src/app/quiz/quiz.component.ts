import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { interval, Subscription } from 'rxjs';

import { Answer } from '../_models/Answer';
import { Question } from '../_models/Question';
import { Quiz } from '../_models/Quiz';
import { Result } from '../_models/Result';
import { QuizService } from '../_services/quiz.service';
import { StorageService } from '../_services/storage.service';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent implements OnInit, OnDestroy {

  quizId: number;
  question: Question;
  answer: Answer;
  noMoreQuestions = false;
  resultSub: Subscription;
  results: Array<Result>;
  constructor(
    private storageService: StorageService,
    private route: ActivatedRoute,
    private quizService: QuizService) {
  }

  ngOnInit() {
    this.quizId = +this.route.snapshot.params.id;
    this.intitialize(this.quizId);
    this.resultSub = interval(10000)
      .subscribe((val) => {
        this.getResults();
      });
  }

  async getResults() {
    try {
      const quiz = new Quiz();
      quiz.id = this.quizId;
      this.results = await this.quizService.getLiveResult(quiz).toPromise();
    } catch (e) {
      console.error(e);
    }
  }

  async intitialize(quizId: number) {
    const quiz = new Quiz();
    quiz.id = quizId;
    const question = await this.quizService.getNextQuestion(quiz).toPromise();
    this.loadQuestion(question);
    this.getResults();
  }

  loadQuestion(question: Question) {
    try {
      this.question = question;
      if (this.question && this.question !== null) {
        this.answer = new Answer();
        this.answer.question = this.question;
      } else {
        this.noMoreQuestions = true;
      }
    } catch (e) {
      console.error(e);
    }
  }

  getMyPosition() {
    const pos = this.results.find(x => x.user.id === this.storageService.userId);
    if (pos) {
      return pos.rank;
    }
  }

  async submitAnswer() {
    try {
      const question = await this.quizService.submitAnswer(this.answer).toPromise();
      this.loadQuestion(question);
      this.getResults();
    } catch (e) {
      if (e.error && e.error.error) {
        alert(e.error.error);
      }
      console.error(e);
    }
  }

  ngOnDestroy(): void {
    this.resultSub.unsubscribe();
  }
}
