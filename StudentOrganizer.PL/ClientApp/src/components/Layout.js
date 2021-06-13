import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { SearchBar } from './SearchBar';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <SearchBar/>
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
