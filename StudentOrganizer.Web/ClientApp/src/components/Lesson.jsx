import React, { Component } from 'react';
import { Assignment } from './Assignment';
import { Link } from "react-router-dom"; 

export class Lesson extends Component {
    constructor(props) {
        super(props);
        this.state = { lesson: this.props.lesson};
      }
      static Types = {
        0:'Lecture',
        1:'Practice',
        2:'Lab',
        3:'Other',
    }
    render() {

        return (
            <div className="my-5 p-3 rounded bg-light">
        <button type="button" className="btn btn-close float-end" aria-label="Close"></button>
        <h1>{this.props.lesson.lesson.name}</h1>
        <hr/>
        <div className="my-3">
          <h4>Type: {Lesson.Types[this.props.lesson.lessonType]}</h4>
          <h5>Place: {this.props.lesson.place}</h5>
          <h5><a href = {this.props.lesson.link}>Lesson link</a></h5>
        </div>
        <h4>Assignments:</h4>
            {this.props.lesson.assignments.map(assignment=><Assignment key={assignment.id} assignment={assignment}></Assignment>)}
        <div className="text-center">
          <Link to={{
            pathname: "/assignments/create",
            state: { lesson: this.props.lesson,
                      scheduleId: this.props.schedule.id,
                      day:this.props.day        
            }
        }}><button type="button" className="btn btn-secondary text">New assignment</button></Link>
        </div>
      </div>
          );
    }
}
