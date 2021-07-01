import React, { Component } from 'react';
import authService from '../api-authorization/AuthorizeService';

function convertDate(stringDate) {
    var date = new Date(stringDate);
    var options = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit', hour12: false };
    return date.toLocaleDateString([], options);

}

export class Assignment extends Component {
    constructor(props) {
        super(props);
        this.state = { assignment: this.props.assignment };
        this.handleClick = this.handleClick.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
    }
    async handleDelete(event) {
        event.preventDefault();
        try {
            const token = await authService.getAccessToken();
            await fetch(`api/assignment/${this.props.assignment.id}`,
                {
                    method: 'Delete',
                    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
                })
                .then(res => res.text())
                .then(console.log('Schedule deleted'));
            this.props.parentCallback(this.props.assignment);
        } catch (error) {
            console.error('Ошибка:', error);
        }
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
        this.props.updateCallBack(this.props.assignment);
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
                    <h5 className="float-start">State: {Assignment.States[this.props.assignment.state]}</h5>
                    <button type="button" className="btn btn-close float-end" aria-label="Close" onClick={this.handleDelete}></button>
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
                    <h5 className="float-end">Deadline: {convertDate(this.props.assignment.deadline)}</h5>
                </footer>
            </div>
        );
    }
}
