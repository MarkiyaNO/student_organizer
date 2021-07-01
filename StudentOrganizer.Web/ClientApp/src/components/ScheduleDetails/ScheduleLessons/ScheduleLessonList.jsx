import React, { Component } from 'react';
import ScheduleLesson from './ScheduleLesson'
import authService from '../../api-authorization/AuthorizeService';

export default class ScheduleLessonAddForm extends Component {
  constructor(props) {
    super(props);
    this.state = { lessons: [], schedule: {}, day: 0, loading: true };
    this.state.day = this.props.match.params.day;
    this.renderLessons = this.renderLessons.bind(this);
    this.getLessons = this.getLessons.bind(this);

  }
  handleDeleteCallback = (childData) => {
    const index = this.state.lessons.indexOf(childData);
    if (index > -1) {
      this.state.lessons.splice(index, 1);
    }
    this.setState({ lesson: this.state.lessons });
  }

  componentDidMount() {
    this.populateScheduleData();
  }
  getLessons() {
    for (let i = 0; i < this.state.schedule.scheduleLessons.length; i++) {
      if (this.state.schedule.scheduleLessons[i].dayOfTheWeek == this.state.day)
        this.state.lessons.push(this.state.schedule.scheduleLessons[i]);
    }
    this.state.lessons.sort(function (a, b) {
      return a.lessonNumber - b.lessonNumber;
    })
  }

  async populateScheduleData() {
    const token = await authService.getAccessToken();
    const response = await fetch(`api/schedule/${this.props.match.params.id}`, {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const data = await response.json();
    this.setState({ schedule: data });
    this.getLessons();
    this.setState({ loading: false });
  }

  renderLessons() {
    return (
      this.state.lessons.map(lesson => <ScheduleLesson key={lesson.id} lesson={lesson}
        schedule={this.state.schedule} day={this.state.day} parentCallback={this.handleDeleteCallback}
        updateCallBack={this.handleUpdateCallBack}></ScheduleLesson>)
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderLessons();

    return (
      <div>
        {contents}
      </div>
    );
  }
}
