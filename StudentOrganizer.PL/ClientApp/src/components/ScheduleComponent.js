import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class ScheduleComponent extends Component {
    static displayName = ScheduleComponent.name;

    constructor(props) {
        super(props);
        this.state = { schedule: this.props.parentData}
    }

    render() {
       return( 
            <div className="col mx-1 p-3 rounded bg-light">
                <button type="button" className="btn btn-close float-end" aria-label="Close"></button>
                <h1>{this.state.schedule.name}</h1>
               <p>{this.state.schedule.description}</p>
               <Link to={`/schedules/${this.state.schedule.id}`}>
                   <button type="button" className="btn btn-secondary">View</button>
               </Link>
            </div>
        );
    }
}
