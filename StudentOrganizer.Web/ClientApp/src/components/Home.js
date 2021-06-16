import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
      return (
          <div className="mt-10">
              <section className="xy-5 py-5 text-center container">
                  <div className="row py-lg-5">
                      <div className="col-lg-6 col-md-8 mx-auto">
                          <h1 className="fw-light">Student organizer</h1>
                          <p className="lead text-muted">Student organizer provides service to create and manage your schedule, lessons and assignments.</p>
                          <p>
                              <a href="schedules/create" className="btn btn-primary my-2 mx-1">Create your schedule</a>
                              <a href="schedules" className="btn btn-secondary my-2 mx-1">View your schedules</a>
                          </p>
                      </div>
                  </div>
              </section>
          </div>
    );
  }
}
