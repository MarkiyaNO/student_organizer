import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import authService from '../api-authorization/AuthorizeService'

export class ScheduleComponent extends Component {
    static displayName = ScheduleComponent.name;

    constructor(props) {
        super(props);
        this.state = { schedule: this.props.parentData }
        this.handleClick = this.handleClick.bind(this);
    }

    async handleClick(event) {
        event.preventDefault();
        try {
            const token = await authService.getAccessToken();
            await fetch(`api/schedule/${this.props.parentData.id}`,
                {
                    method: 'Delete',
                    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
                })
                .then(res => res.text())
                .then(console.log('Schedule deleted'));
            this.props.parentCallback(this.props.parentData);
        } catch (error) {
            console.error('Ошибка:', error);
        }
    }

    render() {
        return (
            <div className="col mx-1 p-3 rounded bg-light">
                <button type="button" className="btn btn-close float-end" aria-label="Close" onClick={this.handleClick}></button>
                <h1>{this.props.parentData.name}</h1>
                <p>{this.props.parentData.description}</p>
                <Link to={`/schedules/${this.props.parentData.id}`}>
                    <button type="button" className="btn btn-secondary">View</button>
                </Link>
            </div>
        );
    }
}
