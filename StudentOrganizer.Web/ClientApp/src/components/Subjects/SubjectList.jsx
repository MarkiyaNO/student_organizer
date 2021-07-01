import React, { Component } from 'react';
import authService from '../api-authorization/AuthorizeService'
import Subject from './Subject'

export class SubjectList extends Component {
  constructor(props) {
    super(props);
    this.state = { lessons: [], loading: true };
    this.renderLessons = this.renderLessons.bind(this);

  }
  handleDeleteCallback = (childData) => {
    const index = this.state.lessons.indexOf(childData);
    if (index > -1) {
      this.state.lessons.splice(index, 1);
    }
    this.setState({ lessons: this.state.lessons });
  }

  componentDidMount() {
    this.populateScheduleData();
  }
  async populateScheduleData() {
    const token = await authService.getAccessToken();
    const response = await fetch('api/lesson', {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const data = await response.json();
    this.setState({ lessons: data });
    this.setState({ loading: false });
  }
  renderLessons() {
    var lesson = this.state.lessons;
    return (
      <div>
        {lesson.map(lesson => (<Subject key={lesson.id} lesson={lesson} parentCallback={this.handleDeleteCallback}></Subject>))}
      </div>
    );
  }
  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderLessons();

    return (
      <div>
        <a href="subjects/create" className="btn btn-primary my-2 mx-1">Create new subject</a>
        {contents}
      </div>
    );
  }
}
