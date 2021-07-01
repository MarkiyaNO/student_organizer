import React, { Component } from 'react';

import './AssignmentList.css'

export class AssignmentList extends Component {
    static States = {
        0: 'failed',
        1: 'inProcess',
        2: 'done'
    };
    constructor(props) {
        super(props);
        this.state = { assignments: this.props.assignments };
    }


    render() {
        return (
            <div>
                <ul className="list-group list-group-flush">
                    {this.props.assignments.map(assignment =>
                        <li key={assignment.id} className="list-group-item">
                            <div className={`crop ${AssignmentList.States[assignment.state]}`}>
                                <input className="form-check-input me-1" type="checkbox" value="" disabled={true}
                                    checked={AssignmentList.States[assignment.state] === 'done'} />
                                {assignment.describtion}
                            </div>
                        </li>
                    )}
                </ul>
            </div>
        );
    }

}
