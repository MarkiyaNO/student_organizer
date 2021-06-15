import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Schedule} from './components/Schedule';
import {ScheduleAddForm} from './components/ScheduleAddForm';

import './custom.css'
import { Schedules } from './components/Schedules';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/counter' component={Counter} />
        <Route exact path='/fetch-data' component={FetchData} />
        <Route exact path='/schedules/create' component = {ScheduleAddForm}/>
        <Route exact path='/schedules/get/:id' component={Schedule}/>
        <Route exact path='/schedules' component={Schedules} />
        
      </Layout>
    );
  }
}
