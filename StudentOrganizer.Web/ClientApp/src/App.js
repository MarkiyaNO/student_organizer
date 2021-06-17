import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Schedule } from './components/Schedule';
import { ScheduleAddForm } from './components/ScheduleAddForm';
import {ScheduleLessonAddForm} from './components/ScheduleLessonAddForm';
import { Schedules } from './components/Schedules';

import './custom.css'
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route exact path='/counter' component={Counter} />
                <AuthorizeRoute exact path='/fetch-data' component={FetchData} />
                <AuthorizeRoute exact path='/schedules/get/lessons/create' component={ScheduleLessonAddForm} />
                <AuthorizeRoute exact path='/schedules/create' component={ScheduleAddForm} />
                <AuthorizeRoute exact path='/schedules/get/:id' component={Schedule} />
                <AuthorizeRoute exact path='/schedules' component={Schedules} />
                
                
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
                
            </Layout>
        );
    }
}
