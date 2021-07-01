import React, { Component } from 'react';
import authService from '../api-authorization/AuthorizeService'

export default class Subject extends Component {
    constructor(props) {
        super(props);
        this.state = { lesson: this.props.lesson };
        this.handleClick = this.handleClick.bind(this);
    }


    async handleClick(event) {
        event.preventDefault();
        try {
            const token = await authService.getAccessToken();
            await fetch(`api/lesson/${this.props.lesson.id}`,
                {
                    method: 'Delete',
                    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
                })
                .then(res => res.text())
                .then(console.log('Lesson deleted'));
            this.props.parentCallback(this.props.lesson);
        } catch (error) {
            console.error('Ошибка:', error);
        }
    }

    render() {
        return (
            <div className="container">
                <div className="my-5 p-3 rounded bg-light">
                    <button type="button" className="btn btn-close float-end" aria-label="Close" onClick={this.handleClick}></button>
                    <h2>Lesson: {this.props.lesson.name}</h2>
                    <hr />
                    <div className="my-3">
                        <h3>Teacher: {this.props.lesson.teacherFullName}</h3>
                    </div>
                </div>
            </div>
        );
    }
}