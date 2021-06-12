import React, { Component } from 'react';

export class ScheduleComponent extends Component {
    static displayName = ScheduleComponent.name;

    constructor(props) {
        super(props);
        this.state = { schedules: [], loading: false };
    }

    componentDidMount() {
        this.populateScheduleData();
    }

    static renderScheduleTables(schedules) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                    
                    </tr>
                </thead>
                <tbody>
                    {schedules.map(schedule =>
                        <tr key={schedule.id}>
                            <td>{schedule.name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ScheduleComponent.renderScheduleTables(this.state.schedules);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateScheduleData() {
        const response = await fetch('api/schedule');
        const data = await response.json();
        this.setState({ schedules: data, loading: false });
    }
}
