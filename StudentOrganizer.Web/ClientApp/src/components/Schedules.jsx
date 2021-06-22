import React, { Component } from 'react';
import {ScheduleComponent} from './ScheduleComponent'
import authService from './api-authorization/AuthorizeService'

export class Schedules extends Component {
    constructor(props) {
        super(props);
        this.state = { schedules : [] };
    }

    handleDeleteCallback = (childData) =>{
        const index = this.state.schedules.indexOf(childData);
        if(index>-1){
            this.state.schedules.splice(index,1);
        }
        this.setState({ schedules: this.state.schedules });
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
                        <ScheduleComponent key ={this.state.schedules[i].id}
                        parentData = {this.state.schedules[i]} parentCallback = {this.handleDeleteCallback}>
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
            <a href="schedules/create" className="btn btn-primary my-2 mx-1">Create new schedule</a>
                {indents}
            </div>
        );
    }
    
    async populateScheduleData() {           
        const token = await authService.getAccessToken();
        const response = await fetch('api/schedule', {
          headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ schedules: data});
    }
}
 



