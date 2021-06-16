import React, { Component } from 'react';
import {ScheduleComponent} from './ScheduleComponent'

export class Schedules extends Component {
    constructor(props) {
        super(props);
        this.state = { schedules : [] };
    }
    componentDidMount() {
        this.populateScheduleData();
    }
    
    render() {
        var indents = [];

        for (var i = 0; i < this.state.schedules.length;) {
            let innerindents =[];
            if(i%3===0)
            {
                let count =0;
                while(i<this.state.schedules.length && count<3)
                {
                    innerindents.push(
                        <ScheduleComponent
                        parentData = {this.state.schedules[i]}>
                        </ScheduleComponent >
                    )
                    count++;
                    i++;
                }
                indents.push(<div className="row mt-3">
                    {innerindents}
                </div>);
            }
    
        }  
       return( 
            <div className = "container">
                {indents}
            </div>
        );
    }
    
    async populateScheduleData() {
        const response = await fetch('api/schedule');
        const data = await response.json();
        this.setState({ schedules: data});
    }
}
 



