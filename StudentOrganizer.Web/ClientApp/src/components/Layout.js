import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { SearchBar} from './SearchBar';
import {Footer} from './Footer';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
      return (
          <div >
              <NavMenu />
              <Container style={{minHeight: 578}}>
                  {this.props.children}
              </Container>
              <Footer />
          </div>
      );
  }
}
