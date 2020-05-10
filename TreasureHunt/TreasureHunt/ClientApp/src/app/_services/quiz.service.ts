import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StorageService } from './storage.service';
import { User } from '../_models/User';
import { AuthenticateResponse } from '../_models/AuthenticateResponse';
import { Observable } from 'rxjs';
import { BaseApiService } from './baseApi.service';
import { Quiz } from '../_models/Quiz';
import { Question } from '../_models/Question';
import { Answer } from '../_models/Answer';
import { Result } from '../_models/Result';

@Injectable()
export class QuizService extends BaseApiService {
  constructor(
    private httpClient: HttpClient) {
    super();
  }

  getActiveQuizzes(): Observable<Array<Quiz>> {
    return this.httpClient.get<Array<Quiz>>(this.baseUrl + 'api/quiz/getAll');
  }

  getNextQuestion(quiz: Quiz): Observable<Question> {
    return this.httpClient.post<Question>(this.baseUrl + 'api/quiz/nextQuestion', quiz);
  }

  submitAnswer(answer: Answer): Observable<Question> {
    return this.httpClient.post<Question>(this.baseUrl + 'api/quiz/answer', answer);
  }

  getLiveResult(quiz: Quiz): Observable<Array<Result>> {
    return this.httpClient.post<Array<Result>>(this.baseUrl + 'api/result/live', quiz);
  }
}
