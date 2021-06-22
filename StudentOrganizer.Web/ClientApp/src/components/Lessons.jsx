import React, { Component } from 'react';
import {Lesson} from './Lesson'
import authService from './api-authorization/AuthorizeService'

export class Lessons extends Component {
    constructor(props) {
        super(props);
        this.state = { schedule: {}, day: 0, loading:true};
        this.lessons=[];
        this.state.day = this.props.match.params.day;
        this.renderLessons = this.renderLessons.bind(this);
        this.getLessons = this.getLessons.bind(this);
        
      }

    componentDidMount()
    {
        this.populateScheduleData();
    }
    getLessons()
    {
        for (let i = 0; i < this.state.schedule.scheduleLessons.length; i++) {
            if (this.state.schedule.scheduleLessons[i].dayOfTheWeek == this.state.day)
                this.lessons.push(this.state.schedule.scheduleLessons[i]);
        }
        this.lessons.sort(function(a,b)
        {
            return a.lessonNumber- b.lessonNumber;
        })
    }

    async populateScheduleData() {
        const token = await authService.getAccessToken();
        const response = await fetch(`api/schedule/${this.props.match.params.id}`, {
          headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ schedule: data});
        this.getLessons();
        this.setState({ loading: false });
    }

    renderLessons() {
        return ( 
            this.lessons.map(lesson=><Lesson key={lesson.id} lesson={lesson} schedule = {this.state.schedule} day = {this.state.day}></Lesson>)
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
