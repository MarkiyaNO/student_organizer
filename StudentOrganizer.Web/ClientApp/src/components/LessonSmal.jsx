import React, { Component } from 'react';

export class LessonSmall extends Component {
    constructor(props) {
        super(props);
        this.state = { lesson: this.props.lesson};
      }
    render() { 
        return ( 
            <div class="container">
                <div class="my-5 p-3 rounded bg-light">
                <button type="button" class="btn btn-close float-end" aria-label="Close"></button>
                <h2>Lesson: {this.props.lesson.name}</h2>
                <hr/>
                <div class="my-3">
                <h3>Teacher: {this.props.lesson.teacherFullName}</h3>
                </div>
                </div>
            </div>
         );
    }
}