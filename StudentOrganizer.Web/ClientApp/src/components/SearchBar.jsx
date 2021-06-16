import React, { Component } from 'react';
export class SearchBar extends Component {
    state = {  }
    render() { 
        return ( 
            <div className="bg-secondary">
            <div className="input-group mb-3">
            <div className="input-group-prepend">
            <button className="btn btn-outline-secondary text-light" type="button">Search</button>
            </div>
              <input type="text" className="form-control" placeholder="Find" aria-label="Find" aria-describedby="basic-addon2"/>
              <div className="input-group-append">
                <button className="btn btn-outline-secondary text-light" type="button">Add</button>
              </div>
            </div>
            </div>
         );
    }
}