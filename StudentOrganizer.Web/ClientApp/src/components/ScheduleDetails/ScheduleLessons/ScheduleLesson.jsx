import React, { Component } from 'react';
import { Assignment } from '../../Assignments/Assignment';
import { Link } from "react-router-dom";
import authService from '../../api-authorization/AuthorizeService';

export default class ScheduleLesson extends Component {
  constructor(props) {
    super(props);
    this.state = { lesson: this.props.lesson };
    this.handleClick = this.handleClick.bind(this);
  }
  static Types = {
    0: 'Lecture',
    1: 'Practice',
    2: 'Lab',
    3: 'Other',
  }
  async handleClick(event) {
    event.preventDefault();
    try {
      const token = await authService.getAccessToken();
      await fetch(`api/schedulelesson/${this.props.lesson.id}`,
        {
          method: 'Delete',
          headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        })
        .then(res => res.text())
        .then(console.log('Schedule deleted'));
      this.props.parentCallback(this.props.lesson);
    } catch (error) {
      console.error('Ошибка:', error);
    }
  }
  handleUpdateCallBack = (childData) => {
    const index = this.state.lesson.assignments.indexOf(childData);
    if (index > -1) {
      this.state.lesson.assignments[index] = childData;
    }
    this.setState({ lesson: this.state.lesson })
  }

  handleDeleteCallback = (childData) => {
    const index = this.state.lesson.assignments.indexOf(childData);
    if (index > -1) {
      this.state.lesson.assignments.splice(index, 1);
    }
    this.setState({ lesson: this.state.lesson });
  }

  render() {

    return (
      <div className="my-5 p-3 rounded bg-light">
        <button type="button" className="btn btn-close float-end" aria-label="Close" onClick={this.handleClick}></button>
        <h1>{this.props.lesson.lesson.name}</h1>
        <hr />
        <div className="my-3">
          <h4>Type: {ScheduleLesson.Types[this.props.lesson.lessonType]}</h4>
          <h5>Place: {this.props.lesson.place}</h5>
          <h5><a href={this.props.lesson.link}>Lesson link</a></h5>
        </div>
        <h4>Assignments:</h4>
        {this.props.lesson.assignments.map(assignment => <Assignment key={assignment.id} assignment={assignment}
          parentCallback={this.handleDeleteCallback} updateCallBack={this.handleUpdateCallBack}></Assignment>)}
        <div className="text-center">
          <Link to={{
            pathname: "/assignments/create",
            state: {
              lesson: this.props.lesson,
              scheduleId: this.props.schedule.id,
              day: this.props.day
            }
          }}><button type="button" className="btn btn-secondary text">New assignment</button></Link>
        </div>
      </div>
    );
  }
}
