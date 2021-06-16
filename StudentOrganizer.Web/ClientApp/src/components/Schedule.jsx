import React, { Component } from 'react';
import {ScheduleDay} from './ScheduleDay';
import authService from './api-authorization/AuthorizeService';

export class Schedule extends Component {
    constructor(props) {
        super(props);
        this.state = { schedule : {} , isLoading: true};
    }
    
    render()
    {
        var days = [0,1,2,3,4,5,6];
        return(
                this.state.isLoading?
                <p>Page is loading...</p>
                :
                <div className="container">
                    {days.map(day =>
                        <ScheduleDay key = {day}
                            parentData={{ schedule: this.state.schedule, day: day }}>
                        </ScheduleDay>
                    )}
                </div>
        )
    } 

    componentWillMount() {
        this.populateScheduleData();
    }
    componentDidMount()
    {
    }

    async populateScheduleData() {
        const token = await authService.getAccessToken();
        const response = await fetch(`api/schedule/${this.props.match.params.id}`, {
          headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ schedule: data});
        this.setState({ isLoading: false });
    }
}
