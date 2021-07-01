import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Schedule } from './components/ScheduleDetails/Schedule';
import { ScheduleAddForm } from './components/Schedules/ScheduleAddForm';
import { ScheduleLessonAddForm } from './components/ScheduleDetails/ScheduleLessons/ScheduleLessonAddForm';
import { ScheduleList } from './components/Schedules/ScheduleList';
import { SubjectList } from './components/Subjects/SubjectList';
import { AssignmentAddForm } from './components/Assignments/AssignmentAddForm';
import { SubjectAddForm } from './components/Subjects/SubjectAddForm';
import ScheduleLessonList from './components/ScheduleDetails/ScheduleLessons/ScheduleLessonList'

import './custom.css'
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';



export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Switch>
                    <Route exact path='/' component={Home} />
                    <AuthorizeRoute exact path='/assignments/create' component={AssignmentAddForm} />
                    <AuthorizeRoute exact path='/subjects' component={SubjectList} />
                    <AuthorizeRoute exact path='/subjects/create' component={SubjectAddForm} />
                    <AuthorizeRoute exact path='/lessons/create' component={ScheduleLessonAddForm} />
                    <AuthorizeRoute exact path='/schedules/create' component={ScheduleAddForm} />
                    <AuthorizeRoute exact path='/schedules/:id/:day' component={ScheduleLessonList} />
                    <AuthorizeRoute exact path='/schedules/:id' component={Schedule} />
                    <AuthorizeRoute exact path='/schedules' component={ScheduleList} />
                    <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />

                </Switch>
            </Layout>
        );
    }
}
