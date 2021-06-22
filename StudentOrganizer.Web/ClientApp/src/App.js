import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Schedule } from './components/Schedule';
import { ScheduleAddForm } from './components/ScheduleAddForm';
import {ScheduleLessonAddForm} from './components/ScheduleLessonAddForm';
import { Schedules } from './components/Schedules';
import { Lessons } from './components/Lessons';
import { AssignmentAddForm } from './components/AssignmentAddForm';
import { LessonAddForm} from './components/LessonAddForm';

import './custom.css'
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import { LessonsSmall } from './components/LessonsSmall';



export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Switch>
                <Route exact path='/' component={Home} />
                <AuthorizeRoute exact path='/assignments/create' component={AssignmentAddForm} />
                <AuthorizeRoute exact path='/subjects' component={LessonsSmall} />
                <AuthorizeRoute exact path='/subjects/create' component={LessonAddForm} />
                <AuthorizeRoute exact path='/lessons/create' component={ScheduleLessonAddForm} />
                <AuthorizeRoute exact path='/schedules/create' component={ScheduleAddForm} />
                <AuthorizeRoute exact path='/schedules/:id/:day' component={Lessons} />
                <AuthorizeRoute exact path='/schedules/:id' component={Schedule} />
                <AuthorizeRoute exact path='/schedules' component={Schedules} /> 
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
                <Route component={Home} />
                </Switch>
            </Layout>
        );
    }
}
