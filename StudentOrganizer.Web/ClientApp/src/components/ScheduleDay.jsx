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
            return a.dayOfTheWeek- b.dayOfTheWeek;
        })
    }
    render()
    {
        const location = {
            pathname: 'lessons/create',
            state: {
                day:this.state.day,
                schedule:this.state.schedule 
            }
        }
    return(
        
        <div className="my-3 p-3 rounded bg-light">
        <button type="button" className="close" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
        <h1>{ScheduleDay.Days[this.state.day]}</h1>
        <div className="my-3">
        <ul className="list-group">
                    {this.lessons.map(lesson =>
                        <li key={lesson.id} className="list-group-item">{lesson.lesson.name}</li>)
            }
        </ul>
        </div>
            <button type="button" className="btn btn-secondary mx-1">View details</button>
            
            <Link to={location}><button type="button" className="btn btn-secondary mx-1" onClick = {this.handleAdd}>Add lesson</button></Link>
      </div>
        );
    }
}
 