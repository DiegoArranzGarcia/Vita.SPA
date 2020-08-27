import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { GoalService } from '../goal.service';
import { GoalDto } from '../goal.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'vita-goal-card-list',
  templateUrl: './goal-card-list.component.html',
  styleUrls: ['./goal-card-list.component.sass'],
})
export class GoalCardListComponent implements OnInit, OnDestroy {
  goals: GoalDto[];
  getGoalsSubscription: Subscription;

  @Input() canCreateGoal: boolean;
  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.getGoalsSubscription = this.goalService.getGoals().subscribe((x) => (this.goals = x));
  }

  ngOnDestroy() {
    if (!!this.getGoalsSubscription && !this.getGoalsSubscription.closed) this.getGoalsSubscription.unsubscribe();
  }

  handleOnCreated(goal: GoalDto) {
    this.goals.push(goal);
  }

  handleOnDelete(id: string) {
    this.goals = this.goals.filter((x) => x.id !== id);
  }

  get isLoading() {
    return this.getGoalsSubscription && !this.getGoalsSubscription.closed;
  }
}
