import React, { Component } from 'react';
import { Link } from "react-router-dom"; 

export class ScheduleDay extends Component {
    static Days = {
        0:'Monday',
        1:'Tuesday',
        2:'Wednesday',
        3:'Thursday',
        4:'Friday',
        5:'Saturday',
        6:'Sunday'
    }
    constructor(props) {
        super(props);
        this.state = { schedule: this.props.parentData.schedule, day: this.props.parentData.day };
        this.lessons = [];
        this.handleAdd = this.handleAdd.bind(this);   
    }
    handleAdd()
    {
        //this.props.history.location.pathname = 'schedules';       
    }
    componentWillMount() 
    {
        this.populateDayData(); 
    }
    populateDayData() 
    {
        for (let i = 0; i < this.state.schedule.scheduleLessons.length; i++) {
            if (this.state.schedule.scheduleLessons[i].dayOfTheWeek === this.state.day)
                this.lessons.push(this.state.schedule.scheduleLessons[i]);
        }
        this.lessons.sort(function(a,b)
        {
            return a.lessonNumber- b.lessonNumber;
        })
    }
    render()
    {
        const location = {
            pathname: '/lessons/create',
            state: {
                day:this.state.day,
                schedule:this.state.schedule 
            }
        }

    return(
        <div className="my-3 p-3 rounded bg-light">
        <button type="button" className="btn btn-close float-end" aria-label="Close"></button>
        <h1>{ScheduleDay.Days[this.state.day]}</h1>
        <div className="card  my-3">
          <div className="card-header">
            Lessons
          </div>
          <ul className="list-group list-group-flush">
          {this.lessons.map(lesson =>
                        <li key={lesson.id} className="list-group-item">
                            <h5>Subject: {lesson.lesson.name}</h5>
                            <h5 className="float-start">Teacher: {lesson.lesson.teacherFullName}</h5>
                            <h5 className="float-end">{lesson.time}</h5>
                        </li>
                        )
            }
          </ul>
        </div>
        <div className="text-center">
          <Link to={`${this.props.parentData.schedule.id}/${this.props.parentData.day}`}><button type="button" className="btn btn-secondary">View details</button></Link>
          <Link to={location}><button type="button" className="btn btn-secondary mx-1" onClick = {this.handleAdd}>Add lesson</button></Link>
        </div>
      </div>);
    }
}
 