import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class ScheduleAddForm extends Component {
    constructor(props) {
        super(props);
        this.state = { name: '', scheduleType: 0, description: '' };
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleDescriptionChange = this.handleDescriptionChange.bind(this);
        this.handleTypeChange = this.handleTypeChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleNameChange(event) {
        this.setState({ name: event.target.value });
    }
    handleDescriptionChange(event) {
        this.setState({ description: event.target.value });
    }
    handleTypeChange(event) {
        this.setState({ scheduleType: event.target.value });
    }

    async handleSubmit(event) {
        event.preventDefault();
        try {
            const token = await authService.getAccessToken();
            await fetch('api/schedule',
                {
                    method: 'POST',
                    body: JSON.stringify(this.state),
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
        this.props.history.push('/schedules');
    }
    render() {
        return (
            <div className="container padding-x-xs">
                <div className="row">
                    <div className="panel panel-primary">
                        <div className="panel-body">
                            <form onSubmit={this.handleSubmit}>
                                <div className="form-group w-50 mx-auto">
                                    <h2 className="pt-5 text-center">Add new Schedule</h2>
                                </div>
                                <div className="form-group my-2">
                                    <label className="control-label" htmlFor="scheduleName">Schedule name:</label>
                                    <input value={this.state.name} id="scheduleName" type="text" maxLength="50" className="form-control" onChange={this.handleNameChange} />
                                </div>
                                <div className="form-group my-3">
                                    <label className="control-label" htmlFor="scheduleName">Schedule description:</label>
                                    <textarea value={this.state.description} id="scheduleDescribtion" type="text" maxLength="300" className="form-control" style={{ minHeight: 250 }} onChange={this.handleDescriptionChange}></textarea>
                                </div>
                                <div className="form-group my-2">
                                    <select defaultValue="0" className="form-select" aria-label="SelectSheduleType" onChange={this.handleTypeChange}>
                                        <option value="0">Personal</option>
                                        <option value="1">Work</option>
                                        <option value="2">Studing</option>
                                    </select>
                                </div>
                                <div className="form-group my-3 text-center">
                                    <button id="signupSubmit" type="submit" className="btn btn-success">Create schedule</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}