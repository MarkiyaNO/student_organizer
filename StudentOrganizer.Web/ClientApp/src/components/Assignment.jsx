import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class Assignment extends Component {
    constructor(props) {
        super(props);
        this.state = { assignment: this.props.assignment };
        this.handleClick = this.handleClick.bind(this);
    }
    async handleClick(state) {
        var tempAssignment = this.props.assignment;
        tempAssignment.state = state
        this.setState({ assignment: tempAssignment })
        try {
            const token = await authService.getAccessToken();
            await fetch(`api/assignment/${this.props.assignment.id}?state=${state}`,
                {
                    method: 'PUT',
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
    }
    static States = {
        0: 'Failed',
        1: 'InProccess',
        2: 'Done',
    }
    render() {
        return (
            <div className="card my-2">
                <div className="card-header">
                    <h5 className="float-start">State: {Assignment.States[this.state.assignment.state]}</h5>
                    <button type="button" className="btn btn-close float-end" aria-label="Close"></button>
                </div>
                <div className="card-body">
                    <blockquote className="blockquote mb-0">
                        <p>{this.props.assignment.describtion}</p>
                    </blockquote>
                </div>
                <footer className="card-footer">
                    <div className="btn-group" role="group" aria-label="Basic mixed styles example">
                        <button type="button" className="btn btn-dark" onClick={() => this.handleClick(0)}>Failed</button>
                        <button type="button" className="btn btn-secondary" onClick={() => this.handleClick(1)}>In proccess</button>
                        <button type="button" className="btn btn-dark" onClick={() => this.handleClick(2)}>Done</button>
                    </div>
                    <h5 className="float-end">Deadline: {this.state.assignment.deadline}</h5>
                </footer>
            </div>
        );
    }
}
