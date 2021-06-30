import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class LessonAddForm extends Component {
  constructor(props) {
    super(props);
    this.state = { name: '', teacher: '' };
    this.handleTeacherChange = this.handleTeacherChange.bind(this);
    this.handleNameChange = this.handleNameChange.bind(this);
    this.renderForm = this.renderForm.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleNameChange(event) {
    this.setState({ name: event.target.value });
  }
  handleTeacherChange(event) {
    this.setState({ teacher: event.target.value });
  }

  async handleSubmit(event) {
    event.preventDefault();
    try {
      const token = await authService.getAccessToken();
      var model = {
        name: this.state.name,
        teacherFullName: this.state.teacher
      };
      await fetch('api/lesson',
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
    this.props.history.push('/subjects');
  }

  renderForm() {
    return (
      <div class="container padding-x-xs">
        <div class="row">
          <div class="panel panel-primary">
            <div class="panel-body">
              <form onSubmit={this.handleSubmit}>
                <div class="form-group w-50 mx-auto">
                  <h2 class="pt-5 text-center">Add lesson</h2>
                </div>
                <div class="form-group my-3">
                  <label class="control-label" for="name">Lesson name:</label>
                  <input type="text" id="name" class="form-control" onChange={this.handleNameChange} />
                </div>
                <div class="form-group my-3">
                  <label class="control-label" for="teacher">Lesson teacher:</label>
                  <input type="text" id="teacher" class="form-control" onChange={this.handleTeacherChange} />
                </div>
                <div class="text-center">
                  <div class="form-group my-3">
                    <button id="signupSubmit" type="submit" class="btn btn-success">Create lesson</button>
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