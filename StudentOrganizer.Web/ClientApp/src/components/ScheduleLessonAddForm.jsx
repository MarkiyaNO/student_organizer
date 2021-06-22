import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class ScheduleLessonAddForm extends Component {
    constructor(props) {
        super(props);
        this.state = { lessons: [], activeLessonId: 0, lessonNumber: 1, link: '', place: '', time: '', lectureType: 0, schedule: this.props.location.state.schedule, loading: true, day: this.props.location.state.day };
        this.handlePlaceChange = this.handlePlaceChange.bind(this);
        this.handleLinkChange = this.handleLinkChange.bind(this);
        this.handleLessonNumberChange = this.handleLessonNumberChange.bind(this);
        this.handleTimeChange = this.handleTimeChange.bind(this);
        this.handleTypeChange = this.handleTypeChange.bind(this);
        this.handleLessonChange = this.handleLessonChange.bind(this);
        this.renderForm = this.renderForm.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
      }
      static Days = {
        0:'Monday',
        1:'Tuesday',
        2:'Wednesday',
        3:'Thursday',
        4:'Friday',
        5:'Saturday',
        6:'Sunday'
    }
      handlePlaceChange(event) {
        this.setState({place: event.target.value});
      }
      handleLinkChange(event){
        this.setState({link: event.target.value});
      }
      handleLessonNumberChange(event){
        this.setState({lessonNumber: event.target.value});
      }
      handleTimeChange(event){
        this.setState({time: event.target.value});
      }
      handleTypeChange(event){
        this.setState({lectureType: event.target.value});
      }
      handleLessonChange(event){
        this.setState({activeLessonId: event.target.value});
      }
    
      componentDidMount() {
        this.populateWeatherData();
      }
      async populateWeatherData() {
        const token = await authService.getAccessToken();
        const response = await fetch('api/lesson', {
          headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ lessons: data, loading: false});
        this.setState({activeLessonId:data[0].id});
      }

    async handleSubmit(event) {
        event.preventDefault();
        try {
            const token = await authService.getAccessToken();
            var scheduleLesson = {
                    lessonNumber:this.state.lessonNumber,
                    dayOfTheWeek:this.state.day,
                    scheduleId:this.state.schedule.id,
                    lessonId:this.state.activeLessonId,
                    place:this.state.place,
                    link:this.state.link,
                    lessonType:this.state.lectureType,
                    time:this.state.time
                  };
            fetch('api/scheduleLesson',
            {
             method: 'POST', 
             body: JSON.stringify(scheduleLesson),
             headers: !token ? {} : { 'Authorization': `Bearer ${token}`,
             'Content-Type': 'application/json' }
             })
               .then(res => res.text())
               .then(console.log('Schedule added'))
          } catch (error) {
            console.error('Ошибка:', error);
        }
        this.props.history.push(`/schedules/${this.state.schedule.id}`);
      }

    renderForm()
    {
        return (
            <div className="container padding-x-xs">
            <div className="row">
              <div className="panel panel-primary">
                <div className="panel-body">
                  <form onSubmit={this.handleSubmit}>
                    <div className="form-group w-50 mx-auto">
                      <h2 className="pt-5 text-center">Add lesson to {ScheduleLessonAddForm.Days[this.state.day]}</h2>
                    </div>
                    <div className="form-group my-2">
                      <label className="control-label" htmlFor="lessonDetails">Lesson details:</label>
                      <select id="lessonDetails" className="form-select" aria-label="SelectLessonType" required onChange = {this.handleLessonChange}>
                        {this.state.lessons.map(x=><option key={x.id} value={x.id}>{x.name} | {x.teacherFullName}</option>)}
                      </select>
                    </div>
                    <div className="form-group my-2">
                      <label className="control-label" htmlFor="lessonNumber">Lesson number:</label>
                      <select defaultValue="1" id="lessonNumber" className="form-select" aria-label="SelectLessonNumber"  required onChange= {this.handleLessonNumberChange}>
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                      </select>
                    </div>
                    <div className="form-group my-3">
                      <label className="control-label" htmlFor="lessonLink">Link:</label>
                      <input type="text" id="lessonLink" className="form-control" onChange={this.handleLinkChange}/>
                    </div>
                    <div className="form-group my-3">
                      <label className="control-label" htmlFor="lessonPlace">Place:</label>
                      <input type="text" id="lessonPlace" className="form-control" onChange={this.handlePlaceChange}/>
                    </div>
                    <div className="form-group my-2">
                      <label className="control-label" htmlFor="lessonTime">Time:</label>
                      <input type="time" id="lessonTime" className="form-control" required onChange={this.handleTimeChange}/>
                    </div>
                    <div className="form-group my-2">
                      <label className="control-label" htmlFor="lessonNumber">Lesson type:</label>
                      <select id="lessonType" className="form-select" aria-label="SelectLessonType" required onChange={this.handleTypeChange}>
                        <option value="0">Lecture</option>
                        <option value="1">Practice</option>
                        <option value="2">Lab</option>
                        <option value="3">Other</option>
                      </select>
                    </div>
                    <div className="text-center"> 
                      <div className="form-group my-3">
                        <button id="signupSubmit" type="submit" className="btn btn-success">Create lesson</button>
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
        let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : this.renderForm();
  
      return (
        <div>
          {contents}
        </div>
      );
    }
}