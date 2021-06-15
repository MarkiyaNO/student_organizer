import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div сlass="mt-10">
      <section class="xy-5 py-5 text-center container">
        <div class="row py-lg-5">
          <div class="col-lg-6 col-md-8 mx-auto">
            <h1 class="fw-light">Student organizer</h1>
            <p class="lead text-muted">Student organizer provides service to create and manage your schedule, lessons and assignments.</p>
            <p>
              <a href="#" class="btn btn-primary my-2 mx-1">Create your schedule</a>
              <a href="#" class="btn btn-secondary my-2 mx-1">View your schedules</a>
            </p>
          </div>
        </div>
      </section>
    </div>
    );
  }
}
