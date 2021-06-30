import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class AssignmentAddForm extends Component {
  constructor(props) {
    super(props);
    this.state = { lesson: this.props.location.state.lesson, loading: true, describtion: '', deadline: '' };
    this.handleDescriptionChange = this.handleDescriptionChange.bind(this);
    this.handleDeadlineChange = this.handleDeadlineChange.bind(this);
    this.renderForm = this.renderForm.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleDeadlineChange(event) {
    this.setState({ deadline: event.target.value });
  }
  handleDescriptionChange(event) {
    this.setState({ describtion: event.target.value });
  }

  async handleSubmit(event) {
    event.preventDefault();
    try {
      const token = await authService.getAccessToken();
      var model = {
        assignment: {
          state: 1,
          deadline: this.state.deadline,
          describtion: this.state.describtion
        },
        id: this.state.lesson.id
      };
      await fetch('api/assignment',
        {
          method: 'POST',
          body: JSON.stringify(model),
          headers: !token ? {} : {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
          }
        })
        .then(res => res.text())
        .then(console.log('Schedule added'))
    } catch (error) {
      console.error('Ошибка:', error);
    }
    this.props.history.push(`/schedules/${this.props.location.state.scheduleId}/${this.props.location.state.day}`);
  }

  renderForm() {
    return (
      <div className="container padding-x-xs">
        <div className="row">
          <div className="panel panel-primary">
            <div className="panel-body">
              <form onSubmit={this.handleSubmit}>
                <div className="form-group w-50 mx-auto">
                  <h2 className="pt-5 text-center">Add assignment to {this.state.lesson.lesson.name}</h2>
                </div>
                <div className="form-group my-3">
                  <label className="control-label" htmlFor="lessonPlace">Description:</label>
                  <textarea type="text" id="lessonPlace" className="form-control" required onChange={this.handleDescriptionChange}></textarea>
                </div>
                <div className="form-group my-2">
                  <label className="control-label" htmlFor="lessonTime">Deadline:</label>
                  <input type="datetime-local" id="lessonTime" className="form-control" required onChange={this.handleDeadlineChange} />
                </div>
                <div className="text-center">
                  <div className="form-group my-3">
                    <button id="signupSubmit" type="submit" className="btn btn-success">Create assignment</button>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    );
  }
  render() {
    let contents = this.renderForm();

    return (
      <div>
        {contents}
      </div>
    );
  }
}