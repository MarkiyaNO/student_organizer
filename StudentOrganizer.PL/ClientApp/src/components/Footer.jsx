import React, { Component } from 'react';

export class Footer extends Component {
  static displayName = Footer.name;

  render () {
    return (
        <footer className="text-center text-lg-start bg-light text-muted mt-auto">
        <section className="d-flex justify-content-center justify-content-lg-between p-4 border-bottom bg-white">
          <div className="container p-4 pb-0">
            <section className="">
              <p className="d-flex justify-content-center align-items-center">
                <span className="mx-3">Illia Prytula</span>
                <span className="mx-3">Markiyan Cherniha</span>
                <span className="mx-3">Vladyslav Zavorotny</span>
              </p>
            </section>
          </div>
        </section>
        <div className="text-center p-4" style={{backgroundColor: `rgba(${0}, ${0}, ${0}, ${0.9})`}}>
          ©2021 Copyright: All rights reserved.
        </div>
      </footer>
    );
  }
}
